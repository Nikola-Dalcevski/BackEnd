using DomainModels.Models;
using System.Collections.Generic;

namespace BusinessLayer.Contracts
{
    public interface IBiclycleServices
    {
        Bicycle GetBicycle(int bicycleId);
        IEnumerable<Bicycle> GetAllBicycles();
    }
}
