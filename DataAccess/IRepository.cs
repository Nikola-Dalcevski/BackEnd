using DomainModels.Models;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository<T>
        where T : Entity
    {
        ICollection<T> GetAll();
        T GetById(int id);
        int Insert(T item);
        int Update(T item);
        int Delete(int id);
    }
}

