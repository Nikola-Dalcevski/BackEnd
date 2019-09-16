using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BicycleBuyingGuide.Api.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AddBike()
        {
            return View();
        }

        public IActionResult EditBicycle()
        {
            return View();
        }

        public IActionResult RemoveBicycle()
        {
            return View();
        }

        public IActionResult AddAdmin()
        {
            return View();
        }

        public IActionResult RemoveAdmin()
        {
            return View();
        }
    }
}