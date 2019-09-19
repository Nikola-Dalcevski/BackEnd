using Models.ViewModels;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public interface IUserServices
    {
        void RegisterUser(RegisterUserViewModel user);
        UserViewModel Authenticate(string email, string password, out string token);
        void RegisterAdmin(RegisterUserViewModel user);
        void RemoveAdmin(int adminId);
        List<UserViewModel> GetAllUser(string role);
        UserViewModel GetUser(int id);

    }
}
