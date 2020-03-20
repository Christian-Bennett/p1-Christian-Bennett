using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Pizza
  {
    public long PizzaId { get; set; }
    public decimal Price { get; set; }

    #region NAVIGATIONAL PROPERTIES

    public Crust Crust { get; set; }
    public long CrustId { get; set; }
    public Size Size { get; set; }
    public long SizeId { get; set; }
    public List<PizzaToppings> PizzaToppings { get; set; }

    #endregion
  }
}