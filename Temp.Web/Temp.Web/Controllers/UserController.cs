using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Temp.Common.Infrastructure;
using Temp.Service.Service;

namespace Temp.Web.Controllers
{
    /// <summary>
    /// User controller 
    /// </summary>
    [Authorize(Policy = Constants.Role.Admin)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        
        /// <summary>
        /// usercontroller constructor
        /// </summary>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        /// <summary>
        /// list user view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var users = _userService.GetAllIncluding();
            return View(users);
        }
        
        /// <summary>
        /// button for request approve
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ApproveRequest(int id)
        {
            var user = _userService.GetById(id);
            _userService.ApproveRequestExpired(user);
            return RedirectToAction("Index", "User");
        }
        
        /// <summary>
        /// button for request reject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult RejectRequest(int id)
        {
            var user = _userService.GetById(id);
            _userService.RejectRequestExpired(user);
            return RedirectToAction("Index", "User");
        }
        
        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index", "User");
        }
        
    }
}