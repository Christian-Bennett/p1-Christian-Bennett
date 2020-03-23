using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using PizzaBox.Storage.Interfaces;

namespace PizzaBox.Storage.Repositories
{
  public class StoreRepository : IRepository
  {
    private readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public IEnumerable<T> Read<T>() where T : class
    {
      return _db.Set<T>();
    }

    public Store GetByZip(string zip)
    {
      return _db.Store.Single(st => st.Zip == zip);
    }

    public Store SetStore()
    {
      return _db.Store.FirstOrDefault();
    }

  }
}