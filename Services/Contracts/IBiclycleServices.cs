using DomainModels.Models;
using Models.ViewModels;
using System.Collections.Generic;

namespace BusinessLayer.Contracts
{
    public interface IBicycleServices
    {
        BicycleViewModel GetBicycle(int bicycleId);
        IEnumerable<BicycleViewModel> GetAllBicycles();
        void AddBicycle(Bicycle bicycle);
        int EditBicycle(Bicycle bicycle);
        int RemoveBicycle(int bicycleId);
    }
}
