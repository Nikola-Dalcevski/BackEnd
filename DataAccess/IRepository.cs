using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

