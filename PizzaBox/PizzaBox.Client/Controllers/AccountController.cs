using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class AccountController : Controller
  {

    [HttpGet]
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Login(AccountViewModel account)
    {
      if(ModelState.IsValid)
      {

        if(account.CheckAccount(account.Username, account.Password))
        {
          User user = account.GetUser(account);
          if(!user.isStore)
            {
              return View("User");
            }
          return View("Store");
        }
      }
      return View("Login");
    }

    public IActionResult Logout()
    {
      return View();
    }


  }
}