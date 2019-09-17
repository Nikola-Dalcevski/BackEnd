using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts
{
    public interface IBicycleRepository : IRepository<Bicycle>
    {
        Bicycle GetByName(string name);
    }
}
