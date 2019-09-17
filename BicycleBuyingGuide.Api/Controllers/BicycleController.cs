using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Contracts;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace BicycleBuyingGuide.Api.Controllers
{

    [Route("bbg/[controller]")]
    [ApiController]
    public class BicycleController : Controller
    {
        private readonly IBicycleServices _bicycleServices;

        public BicycleController(IBicycleServices bicycleServices)
        {
            _bicycleServices = bicycleServices;
        }

        [HttpGet("{id}")]
        public ActionResult<Bicycle> GetBicycle(int id)
        {
            var bicycle = _bicycleServices.GetBicycle(id);
            if (bicycle == null) return NotFound($"Bicycle with {id} is not found");
            return bicycle;

        }

        [HttpGet]
        public ActionResult<List<Bicycle>> GetAllBicycles()
        {
            List<Bicycle> bicycles = _bicycleServices.GetAllBicycles().ToList();
            if (bicycles.Count == 0) return NotFound("No Bicycles in dataBase");

            return bicycles;
        }
    }
}