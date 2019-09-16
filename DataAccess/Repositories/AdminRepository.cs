using DataAccess.Contracts;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class AdminRepository : BaseRepository<Admin> , IAdminRepository 
    {

        public AdminRepository(BicycleDbContex context)
            :base(context)
        {

        }
    }
}
