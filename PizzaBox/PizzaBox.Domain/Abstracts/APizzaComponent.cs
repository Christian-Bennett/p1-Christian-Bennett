using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class APizzaComponent
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
  }
}