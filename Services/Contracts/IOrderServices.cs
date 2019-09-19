using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts
{
    public interface IOrderServices
    {
        void createOrder();
        void submitOrder();
        void addBicycle();
    }
}
