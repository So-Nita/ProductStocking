using System;
using Microsoft.EntityFrameworkCore.Internal;
using ProductLib.DataConfiguration;

namespace ProductLib.Repository;

public class Repository<T> where T : class
{
    private readonly ProductContext _context;

    public Repository(ProductContext context)
    {
       // _context = context;
        var factory = new DbContextFactory();
        _context = factory.CreateDbContext(null!);
    }
    public IQueryable<T>? GetAll()
    {
        return _context.Set<T>().AsQueryable();
    }
    public T? GetById(string id)
    {
        return _context.Set<T>().Find(id);
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}

