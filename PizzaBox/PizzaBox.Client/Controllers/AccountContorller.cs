using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class AccountController : Controller
  {
    private PizzaBoxRepository _pbr;

    public AccountController(PizzaBoxRepository repository)
    {
      _pbr = repository;
    }

    [HttpGet]
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Login(AccountViewModel account)
    {
      if(!ModelState.IsValid)
      {
        if(_pbr.CheckAccount(account.Username, account.Password))
        {
          if(account.User)
            {
              return View("User");
            }
          return View("Store");
        }
      }
      return View(account);
    }

    public IActionResult Logout()
    {
      return View();
    }


  }
}