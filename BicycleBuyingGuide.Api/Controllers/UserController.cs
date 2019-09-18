using BusinessLayer.Services;
using DomainModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    }
}