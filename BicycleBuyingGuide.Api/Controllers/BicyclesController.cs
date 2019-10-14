using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using DomainModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace BicycleBuyingGuide.Api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BicyclesController : ControllerBase
    {
        private readonly IBicycleServices _bicycleServices;

        public BicyclesController(IBicycleServices bicycleServices)
        {
            _bicycleServices = bicycleServices;
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<BicycleViewModel> GetBicycle(int id)
        {
            var bicycle = _bicycleServices.GetBicycle(id);
            if (bicycle == null) return NotFound($"Bicycle with {id} is not found");
            return bicycle;

        }




        [HttpGet("get")]
        [Route("bbg/[Controller]")]
        public IActionResult GetAllBicycles()
        {
            List<BicycleViewModel> bicycles = _bicycleServices.GetAllBicycles().ToList();


            return Ok();
        }


        [HttpPost("add")]
        public IActionResult AddBicycle([FromBody] Bicycle bicycle)
        {
            _bicycleServices.AddBicycle(bicycle);
            return Ok(bicycle);
        }


        [HttpPost("remove/{bicycleId}")]
        public IActionResult RemoveBicycle(int bicycleId)
        {
            _bicycleServices.RemoveBicycle(bicycleId);
            return Ok(bicycleId);
        }


        [HttpPut("edit")]
        public IActionResult EditBicycle([FromBody] Bicycle bicycle)
        {
            _bicycleServices.EditBicycle(bicycle);
            return Ok(bicycle);
        }
    }


}