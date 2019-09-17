using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);

    }
}
