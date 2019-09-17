using DomainModels.Models;

namespace BusinessLayer.Services
{
    public interface IUserServices
    {
        void RegisterUser(User user);
        User Authenticate(string email, string password, out string token);
        void RegisterAdmin(User user);

    }
}
