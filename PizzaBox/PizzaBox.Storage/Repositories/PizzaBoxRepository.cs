using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using PizzaBox.Storage.Interfaces;

namespace PizzaBox.Storage.Repositories
{
  public class PizzaBoxRepository : IRepository
  {
    private readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public IEnumerable<T> Read<T>() where T : class
    {
      return _db.Set<T>();
    }

    public List<Pizza> GetByOrder(long id)
    {
      return _db.Pizza.Where(p => p.OrderId == id).ToList();
    }

    public bool Post(Pizza pizza)
    {
      _db.Pizza.Add(pizza);
      return _db.SaveChanges() == 1;
    }
    

  }
}