using DomainModels.Models;
using System.Collections.Generic;

namespace BusinessLayer.Contracts
{
    public interface IBicycleServices
    {
        Bicycle GetBicycle(int bicycleId);
        IEnumerable<Bicycle> GetAllBicycles();
        void AddBicycle(Bicycle bicycle);
        int EditBicycle(Bicycle bicycle);
        int RemoveBicycle(int bicycleId);
    }
}
