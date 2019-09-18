using BusinessLayer.Services;
using DomainModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BicycleBuyingGuide.Api.Controllers
{

    [ApiController]
    [Route("bbg/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            _userServices.RegisterUser(user);
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] string email, string password)
        {
            _userServices.Authenticate(email, password, out string token);           
            return Ok(token);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost("register-admin")]
        public IActionResult RegisterAdmin([FromBody] User admin)
        {                   
            _userServices.RegisterAdmin(admin);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userServices.GetUser(id);
            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("get-all-users/{role}")]
        public ActionResult<List<User>> GetAllUsers(string role)
        {
            List<User> users = _userServices.GetAllUser(role);
            return Ok(users);
        }

        [Authorize(Roles = "BaseAdmin")]
        [HttpPost("remove/{id}")]
        public IActionResult RemoveAdmin(int id)
        {
            _userServices.RemoveAdmin(id);
            return Ok();
        }

    }
}