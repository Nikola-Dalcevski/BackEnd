using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts
{
    public interface IAdminServices
    {
        int AddBicycle(BicycleViewModel bicycle);
        int EditBicycle(BicycleViewModel bicycle);
        int RemoveBicycle(BicycleViewModel bicycle);
        int AddAdmin(AdminViewModel admin);
    }
}
