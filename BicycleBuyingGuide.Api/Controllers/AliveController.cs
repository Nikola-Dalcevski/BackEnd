using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BicycleBuyingGuide.Api.Controllers
{
    [Authorize]
    public class AliveController : ControllerBase
    {

        [AllowAnonymous]
        [HttpGet]
        [Route("bbg/[Controller]")]
        public IActionResult Index()
        {
            return NoContent();
        }
    }
}