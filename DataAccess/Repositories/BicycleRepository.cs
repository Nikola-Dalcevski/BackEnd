using DataAccess.Contracts;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class BicycleRepository : BaseRepository<Bicycle> , IBicycleRepository
    {

        public BicycleRepository(BicycleDbContex context)
            :base(context)
        {
                    
        }
    }
}
