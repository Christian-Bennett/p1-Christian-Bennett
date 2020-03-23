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

    public List<User> Read(string Name)
    {
      return _db.User.Where(x => x.UserName == Name).ToList();
    }

    public User GetById(long id)
    {
      return _db.User.Single(u => u.Id == id );
    }

    public User GetByName(string name)
    {
      return _db.User.Single(u => u.UserName == name);
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