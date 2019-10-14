using DataAccess.Contracts;
using DomainModels.Models;
using System.Linq;

namespace DataAccess.Repositories
{
    public class BicycleRepository : BaseRepository<Bicycle> , IBicycleRepository
    {
        //TODO try to take _context from base class - like base._context
        //need to change in base class private property to protected
        private readonly BicycleDbContex _context;

        public BicycleRepository(BicycleDbContex context)
            :base(context)
        {
            _context = context;
        }

        public Bicycle GetByName(string name)
        {
           var bike = _context.Bicycles.SingleOrDefault(b => b.Model == name);
            return bike;
            
        } 
    }
}
