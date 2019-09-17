using BusinessLayer.Contracts;
using DomainModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BicycleBuyingGuide.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminServices _adminService;
      

        public AdminController(IAdminServices adminService)
        {
            _adminService = adminService;
          
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addbike")]
        public IActionResult AddBike([FromBody] Bicycle bicycle)
        {
            _adminService.AddBicycle(bicycle);
            return Ok(bicycle.Id);
        }

      
        [HttpPut("edit-bike")]
        public IActionResult EditBicycle([FromBody] Bicycle bicycle)
        {
            _adminService.EditBicycle(bicycle);
            return Ok(bicycle.Id);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("remuve-bike/{id}")]
        public IActionResult RemoveBicycle(int id)
        {
            var bicyce = _adminService.RemoveBicycle(id);
            return Ok(id);
        }

        [Authorize(Roles = "BaseAdmin")]
        [HttpPost("add-admin")]
        public IActionResult AddAdmin([FromBody] User admin)
        {
            _adminService.AddAdmin(admin);
            return Ok(admin.Id);
        }

        [Authorize(Roles = "BaseAdmin")]
        [HttpPost("remove-admin/{id}")]
        public IActionResult RemoveAdmin(int id)
        {
            _adminService.RemuveAdmin(id);
            return Ok(id);
        }
    }
}