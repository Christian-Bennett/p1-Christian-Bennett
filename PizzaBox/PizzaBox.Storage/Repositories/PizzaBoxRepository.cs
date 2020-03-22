using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;


namespace PizzaBox.Storage.Repositories
{
  public class PizzaBoxRepository
  {
    private readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public virtual IEnumerable<T> Read<T>() where T : class
    {
      return _db.Set<T>();
    }

    public bool CheckAccount(string user, string pass)
    {
      return true;
    }
  }
}