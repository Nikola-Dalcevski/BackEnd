using DataAccess.Contracts;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User> , IUserRepository
    {

        public UserRepository(BicycleDbContex context)
            :base(context)
        {

        }

        public User GetByEmail(string email)
        {
            
            throw new NotImplementedException();
        }
    }
}
