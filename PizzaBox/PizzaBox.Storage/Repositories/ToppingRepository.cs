using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using PizzaBox.Storage.Interfaces;

namespace PizzaBox.Storage.Repositories
{
  public class ToppingRepository : IRepository
  {
    private readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public IEnumerable<T> Read<T>() where T : class
    {
      return _db.Set<T>();
    }

    public bool Post(Topping Topping)
    {
      _db.Topping.Add(Topping);
      return _db.SaveChanges() == 1;
    }
    public Topping GetbyId(long id)
    {
      return _db.Topping.Single(t => t.Id == id);
    }

  }
}