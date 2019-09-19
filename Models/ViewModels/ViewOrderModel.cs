using System.ComponentModel.DataAnnotations;

namespace BicycleBuyingGuide.Api.ViewModels
{
    public class ViewOrderModel
    {

        public string OrderUserName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
    }
}
