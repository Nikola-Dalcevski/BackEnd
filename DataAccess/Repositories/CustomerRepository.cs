using DataAccess.Contracts;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class CustomerRepository : BaseRepository<BaseUser> , ICutomerRepository
    {

        public CustomerRepository(BicycleDbContex context)
            :base(context)
        {

        }
    }
}
