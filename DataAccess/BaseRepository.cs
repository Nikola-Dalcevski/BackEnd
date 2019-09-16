using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class BaseRepository<T> : IRepository<T>
        where T : Entity
    {
        private readonly BicycleDbContex _context;
        private readonly DbSet<T> _entity;

        public BaseRepository(BicycleDbContex context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }


        public int Delete(int id)
        {
            T item = _entity.SingleOrDefault(x => x.Id == id);
            _entity.Remove(item);
            return _context.SaveChanges();

        }

        public ICollection<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(int id)
        {
            return _entity.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(T item)
        {
            _entity.Add(item);
            return _context.SaveChanges();
        }

        public int Update(T item)
        {
            var baseItem = _entity.Attach(item);
            baseItem.State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
