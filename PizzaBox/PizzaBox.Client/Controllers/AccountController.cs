using System.Collections.Generic;
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
          
          account.user = account.GetUser(account);
          account = account.GetByName(account);
          ViewData["Username"] = account.Username;
          TempData["Un"] = account.Username;
          TempData["oid"] = "x";

          if(account.user.isStore)
            {
              return View("Store", account);
            }

          return View("User", account);
        }
      }
      return View("Login");
    }

    public IActionResult Logout()
    {
      return View();
    }
    
    [HttpPost]
    public IActionResult NewOrder()
    {
      var x = Request.Form["Stores"];
      if("x" == TempData["oid"] as string)
      {
        return View(new OrderViewModel(TempData["Un"] as string, x[0]));
      }
      return View(new OrderViewModel(TempData["Un"] as string, TempData["oid"] as string));
    }

    [HttpGet]
    public IActionResult Confirm()
    {
      var x = this.HttpContext.Request.QueryString.Value.Substring(4, 16);

      OrderViewModel ovm = new OrderViewModel("", x);

      ovm.Update(ovm);

      return View("~/Views/Shared/Confirm.cshtml", ovm);
    }

    public IActionResult History()
    {
      
      OrderViewModel ovm = new OrderViewModel();
      return View("~/Views/Shared/history .cshtml", ovm);
    }
  }
}