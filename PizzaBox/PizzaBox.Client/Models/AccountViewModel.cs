using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Models
{
  public class AccountViewModel
  {
    private readonly UserRepository _ur = new UserRepository();

    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }

    public bool CheckAccount(string un, string pass)
    {
      if(_ur.VerifyAccount(un, pass) != null)
      {
        return true;
      }
      return false;
      
    }

    public User GetUser(AccountViewModel avm)
    {
      return _ur.VerifyAccount(avm.Username, avm.Password);
    }
  }
}