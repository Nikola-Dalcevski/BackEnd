using DataAccess.Contracts;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User> , IUserRepository
    {
        private readonly BicycleDbContex _context;

        public UserRepository(BicycleDbContex context)
            :base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
           var user = _context.Users.SingleOrDefault(u => u.Email == email);
            return user;
        }
    }
}
