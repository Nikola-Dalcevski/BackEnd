using DataAccess.Contracts;
using DomainModels.Models;
using System.Linq;

namespace DataAccess.Repositories
{
    public class BicycleRepository : BaseRepository<Bicycle> , IBicycleRepository
    {
        private readonly BicycleDbContex _context;

        public BicycleRepository(BicycleDbContex context)
            :base(context)
        {
            _context = context;
        }

        public Bicycle GetByName(string name)
        {
           var bike = _context.Bicycles.SingleOrDefault(b => b.FullName == name);
            return bike;
        } 
    }
}
