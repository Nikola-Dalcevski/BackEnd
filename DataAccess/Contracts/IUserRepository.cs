using DomainModels.Models;

namespace DataAccess.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);

    }
}
