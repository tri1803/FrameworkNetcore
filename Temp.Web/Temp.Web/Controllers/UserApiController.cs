using Microsoft.AspNetCore.Mvc;
using Temp.Service.Service;

namespace Temp.Web.Controllers
{
    /// <summary>
    /// api user
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : Controller
    {
        private readonly IUserService _service;
        private readonly IAccountService _accountService;
        
        public UserApiController(IUserService service, IAccountService accountService)
        {
            _service = service;
            _accountService = accountService;
        }
        
        /// <summary>
        /// api get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var users = _service.GetAll();
            return Ok(users);
        }   
    }
}