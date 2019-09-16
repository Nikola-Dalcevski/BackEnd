using DataAccess.Contracts;
using DomainModels.Models;

namespace DataAccess.Repositories
{
    public class OrderRepository : BaseRepository<Order> , IOrderRepository
    {
        public OrderRepository(BicycleDbContex context)
            : base(context)
        {

        }
    }
}
