using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel
  {
    private readonly PizzaBoxRepository _pr = new PizzaBoxRepository();

    public List<Crust> CrustList { get; set; }
    public List<Size> SizeList { get; set; }
    public List<Topping> ToppingList { get; set; }

    [Required]
    public Crust Crust { get; set; }
    [Required]
    public Size Size { get; set; }
    [Required]
    public List<Topping> Toppings { get; set; }

    public PizzaViewModel()
    {
      SizeList = _pr.Read<Size>().ToList();
      CrustList = _pr.Read<Crust>().ToList();
      ToppingList = _pr.Read<Topping>().ToList();
    }
  }   

}