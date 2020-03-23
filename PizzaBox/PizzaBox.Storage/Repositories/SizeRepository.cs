using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using PizzaBox.Storage.Interfaces;

namespace PizzaBox.Storage.Repositories
{
  public class SizeRepository : IRepository
  {
    private readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public IEnumerable<T> Read<T>() where T : class
    {
      return _db.Set<T>();
    }

    public bool Post(Size size)
    {
      _db.Size.Add(size);
      return _db.SaveChanges() == 1;
    }

    public Size Get(string sizeName)
    {
      return _db.Size.SingleOrDefault(s => s.Name == sizeName);
    }
    

  }
}