using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using PizzaBox.Storage.Interfaces;

namespace PizzaBox.Storage.Repositories
{
  public class CrustRepository : IRepository
  {
    private readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public IEnumerable<T> Read<T>() where T : class
    {
      return _db.Set<T>();
    }

    public bool Post(Crust crust)
    {
      _db.Crust.Add(crust);
      return _db.SaveChanges() == 1;
    }
    public Crust Get(string crustName)
    {
      return _db.Crust.SingleOrDefault(c => c.Name == crustName);
    }

  }
}