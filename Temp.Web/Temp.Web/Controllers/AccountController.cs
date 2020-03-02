using Microsoft.AspNetCore.Mvc;
using Temp.Service.Service;
using Temp.Service.ViewModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Temp.Common.Infrastructure;
using Temp.Common.Resources;
using Serilog;

namespace Temp.Web.Controllers
{   
    /// <summary>
    /// Account controller
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IAccountService _account;
        

        public AccountController(IAccountService account)
        {
            _account = account;
            
        }
        
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult LogIn(string returnUrl = null)
        {
            var login = new LogInViewModel { ReturnUrl = returnUrl };
            return View(login);
        }
        
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInViewModel loginModel)
        {
            if (ModelState.IsValid)
            {              
                var user = _account.LogIn(loginModel);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, MessageResource.UserLoginFailed);
                    Log.Error(MessageResource.UserLoginFailed);
                    return View(loginModel);
                }
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim(Constants.ClaimName.AccountId, user.Id.ToString())
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Admin");          
                
            }                                     
            return View(loginModel);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LogOut()
        {
            Response.Cookies.Delete(ClaimTypes.Name);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LogIn","Account");
        }
        
        /// <summary>
        /// register
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAccViewModel accDto)
        {          
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, MessageResource.SignupFail);
                Log.Error(MessageResource.SignupFail);
                return View(accDto);                
            }
            _account.CreateAccount(accDto);
            return RedirectToAction("LogIn", "Account");            
        }
        
        /// <summary>
        /// Change password
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ChangePass()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePass(ChangePassViewModel passDto)
        {
            if (ModelState.IsValid)
            {
                if (!_account.CheckPass(passDto))
                {
                    ModelState.AddModelError("",MessageResource.InvalidCredentials);
                    return View(passDto);
                }                                    
                if (_account.ChangePass(passDto))
                {
                    return RedirectToAction("LogIn","Account");
                }               
            } 
            ModelState.AddModelError("",MessageResource.ChangePassFailed);
            return View(passDto);
        }
        
        /// <summary>
        /// user request expired date
        /// </summary>
        /// <returns></returns>
        public IActionResult RequestExpiredDate()
        {
            string name = HttpContext.User.Identity.Name;
            var user = _account.GetAccount(name);           
            _account.RequestExpired(user);                                 
            return RedirectToAction("Index","Admin");
        }               
    }
}