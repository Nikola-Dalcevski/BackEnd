using DomainModels.Models;

namespace BusinessLayer.Contracts
{
    public interface IAdminServices
    {
        int GetAllAdmins();
        int Authenticate(string email, string password);
        int AddBicycle(Bicycle bicycle);
        int EditBicycle(Bicycle bicycle);
        int RemoveBicycle(int bicycleId);
        int AddAdmin(User admin);
        int RemuveAdmin(int adminId);
    }
}
