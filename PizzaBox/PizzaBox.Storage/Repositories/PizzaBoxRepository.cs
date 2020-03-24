using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
      return _db.Pizza.Where(p => p.OrderId == id).Include(c => c.Crust).Include(s => s.Size).Include(pt => pt.PizzaToppings).ToList();
    }

    public bool Post(Pizza pizza)
    {
      _db.Pizza.Add(pizza);
      return _db.SaveChanges() == 1;
    }
    

  }
}