using System;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly TableContext _context;

    public GenericRepository(TableContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(Guid id)
    {
        return _context.Set<T>().Find(id);
    }

    //public T? GetByTableNumber(int tableNumber)
    //{
    //    return _context.Set<T>().FirstOrDefault(e => EF.Property<int>(e, "TableNumber") == tableNumber);
    //}

    public async Task<List<T>> AddBatch(List<T> entities)
    {
        foreach(T entity in entities)
        {
            _context.Set<T>().Add(entity);
        }
        
        await _context.SaveChangesAsync();

        return entities;
    }

    //public void Update(T entity)
    //{
    //    _context.Set<T>().Update(entity);
    //}

    //public void RemoveById(Guid id)
    //{
    //    var entity = _context.Set<T>().Find(id);
    //    if (entity != null)
    //    {
    //        _context.Set<T>().Remove(entity);
    //    } else
    //    {
    //        Console.WriteLine("Entitas tidak ditemukan");
    //    }
    //}

    //public void SaveChanges()
    //{
    //    _context.SaveChanges();
    //}
}