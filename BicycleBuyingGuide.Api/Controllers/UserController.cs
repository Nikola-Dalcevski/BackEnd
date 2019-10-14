using BicycleBuyingGuide.Api.ViewModels;
using BusinessLayer;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using System.Collections.Generic;

namespace BicycleBuyingGuide.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("bbg/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserViewModel user)
        {
            _userServices.RegisterUser(user);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] LoginViewModel authorizateuser)
        {
            //var user = _userServices.Authenticate(authorizateuser.Email, authorizateuser.Password, out string token);
            //Response.Headers.Add("Authorization", token);
            //return Ok(user);
            return Ok("Its working");
        }

        [Authorize(Roles = "BaseAdmin")]
        [HttpPost("register-admin")]
        public IActionResult RegisterAdmin([FromBody] RegisterUserViewModel admin)
        {
            _userServices.RegisterAdmin(admin);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<UserViewModel> GetUser(int id)
        {
            var user = _userServices.GetUser(id);
            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("get-all-users/{role}")]
        public ActionResult<List<UserViewModel>> GetAllUsers(string role)
        {
            List<UserViewModel> users = _userServices.GetAllUser(role);
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