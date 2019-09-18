using DomainModels.Models;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public interface IUserServices
    {
        void RegisterUser(User user);
        User Authenticate(string email, string password, out string token);
        void RegisterAdmin(User user);
        void RemoveAdmin(int adminId);
        List<User> GetAllUser(string role);
        User GetUser(int id);

    }
}
