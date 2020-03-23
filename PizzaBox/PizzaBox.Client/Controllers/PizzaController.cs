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
      return View(new PizzaViewModel());
    }

    [HttpPost]
    public IActionResult Create(PizzaViewModel pvm)
    {
      pvm.SetToppings(pvm);
      pvm.Post(pvm);

      
      return View("Yay");
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