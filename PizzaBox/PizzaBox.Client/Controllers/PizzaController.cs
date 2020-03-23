using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using PizzaBox.Storage.Repositories;
using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {

    [HttpGet]
    public IActionResult Create()
    {
      string str = this.HttpContext.Request.QueryString.Value.Substring(4, 16);
      TempData["oid"] = str;
      return View(new PizzaViewModel(){});
    }

    [HttpPost]
    public ActionResult Create(PizzaViewModel pvm)
    {
      
      string str = TempData["oid"] as string;
      long oid = Convert.ToInt64(str);
      pvm.SetToppings(pvm);
      pvm.Post(pvm, oid);

      OrderViewModel ovm = new OrderViewModel("", str);
      return View("~/Views/Shared/NewOrder.cshtml", ovm);
      
    }

    [HttpPut]
    public void Put()
    {

    }

    [HttpDelete]
    public void Delete()
    {

    }
  }
}