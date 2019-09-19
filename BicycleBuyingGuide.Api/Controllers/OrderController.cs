using BicycleBuyingGuide.Api.ViewModels;
using BusinessLayer.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BicycleBuyingGuide.Api.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public IActionResult CreateOrder(ViewOrderModel order)
        {
            return null;
        }
    }
}