using Microsoft.AspNetCore.Mvc;
using System.Net;
using webAppDemos.Business.Abstracts;
using webAppDemos.Business.Concretes;
using webAppDemos.Entities.Concretes;
using webAppDemos.Models;

namespace webAppDemos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService) { _userService = userService; }
        

        [HttpGet(Name = "getAll")]
        public ActionResult<List<User>> GetAll()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpPost(Name = "createUser")]
        public ActionResult<string> CreateUser([FromBody] CreateUserRequestDTO request)
        {
            return Ok(_userService.CreateUser(request));
        }
    }
}
