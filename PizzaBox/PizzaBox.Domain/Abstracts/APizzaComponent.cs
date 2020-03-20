using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class APizzaComponent
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
  }
}