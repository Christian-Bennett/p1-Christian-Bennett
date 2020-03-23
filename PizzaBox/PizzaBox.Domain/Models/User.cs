using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class User : AInfoComponent
  {
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public bool isStore { get; set; }

    public User()
    {
      //Id = DateTime.Now.Ticks;
    }
  }
}