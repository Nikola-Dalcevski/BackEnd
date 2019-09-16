using Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public interface IUserServices
    {
        void RegisterUser(CustomerViewModel customer);
        int GetOrder(OrderViewModel order);
        int GetAllOrders();

    }
}
