using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using PizzaBox.Storage.Interfaces;

namespace PizzaBox.Storage.Repositories
{
  public class OrderRepository : IRepository
  {
    private readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public IEnumerable<T> Read<T>() where T : class
    {
      return _db.Set<T>();
    }

    public bool Post(Order order)
    {
      _db.Order.Add(order);
      return _db.SaveChanges() == 1;
    }

  }
}