using System;
using System.Collections.Generic;
using Persistence.Models;

namespace Persistence.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById(Guid id);
        Task<List<T>> AddBatch(List<T> entities);
        //T? GetByTableNumber(int tableNumber);
        //T? RemoveById(Guid id);
        //void Update(T entity);
        //void SaveChanges();
    }
}
