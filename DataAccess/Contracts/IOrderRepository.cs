using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
