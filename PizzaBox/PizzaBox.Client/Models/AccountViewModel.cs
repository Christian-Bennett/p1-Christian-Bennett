using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Models
{
  public class AccountViewModel
  {
    private readonly UserRepository _ur = new UserRepository();
    private readonly StoreRepository _str = new StoreRepository();

    [Required]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public List<User> users { get; set; }
    public User user { get; set; }
    public long UserId { get; set; }
    public List<Store> Stores { get; set; }
    public Store store { get; set; }
    public string StoreAddress { get; set; }

    public bool CheckAccount(string un, string pass)
    {
      if(_ur.VerifyAccount(un, pass) != null)
      {
        return true;
      }
      return false;
      
    }

    public AccountViewModel GetByName(AccountViewModel avm)
    {
      var y = new List<User>();
      _ur.Read(avm.Username).ForEach(x => y.Add( new User(){UserName = x.UserName, Id = x.Id}));
      avm.users = y;
      avm.Stores = GetStores();
      
      return avm;
    }

    public User GetUser(AccountViewModel avm)
    {
      return _ur.VerifyAccount(avm.Username, avm.Password);
    }

    public List<Store> GetStores()
    {
      return _str.Read<Store>().ToList();
    }

  }
}