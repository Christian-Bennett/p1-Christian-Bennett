using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storage.Databases;
using PizzaBox.Storage.Repositories;
using System.Collections.Generic;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {

    [HttpGet]
    public IActionResult Get()
    {
      return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View(new PizzaViewModel());
    }

    [HttpPost]
    public IActionResult Add(PizzaViewModel pizzaViewModel)
    {

      if(ModelState.IsValid)
      {
        return RedirectToAction("Create");
      }
      return View();
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