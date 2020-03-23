using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Pizza : APizzaComponent
  {

    #region NAVIGATIONAL PROPERTIES

    public Order Order { get; set; }
    public long OrderId { get; set; }
    public Crust Crust { get; set; }
    public long CrustId { get; set; }
    public Size Size { get; set; }
    public long SizeId { get; set; }
    public List<PizzaToppings> PizzaToppings { get; set; }

    #endregion

    public Pizza()
    {
      Id = DateTime.Now.Ticks;
    }
  }
}