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

    public Order GetById(long id)
    {
      return _db.Order.Single(o => o.Id == id);
    }

    public Order GetByUserId(long id)
    {
      return _db.Order.First(o => o.UserId == id);
    }


    public bool Post(Order order)
    {
      _db.Order.Add(order);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Order Order)
    {
      Order o = GetById(Order.Id);

      o = Order;
      return _db.SaveChanges() == 1;
    }

  }
}