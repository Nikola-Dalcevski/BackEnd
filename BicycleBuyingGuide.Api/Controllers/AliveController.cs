using Microsoft.AspNetCore.Mvc;

namespace BicycleBuyingGuide.Api.Controllers
{
    public class AliveController : Controller
    {

        [HttpGet]
        [Route("bicycle/[Controller]")]
        public IActionResult Index()
        {
            return NoContent();
        }
    }
}