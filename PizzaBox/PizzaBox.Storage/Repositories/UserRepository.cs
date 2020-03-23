using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using PizzaBox.Storage.Interfaces;

namespace PizzaBox.Storage.Repositories
{
  public class UserRepository : IRepository
  {
    private readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public IEnumerable<T> Read<T>() where T : class
    {
      return _db.Set<T>();
    }

    public User VerifyAccount(string user, string pass)
    {
      if(_db.User.Single(u => u.UserName == user) != null)
      {
        if(_db.User.Single(u => u.UserName == user).Password == pass)
        {
          return _db.User.Single(u => u.UserName == user);
        }
      }
      return null;
    }
  }
}