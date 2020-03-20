using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel
  {
    private PizzaBoxRepository _pr;
    public PizzaViewModel(PizzaBoxRepository repository)
    {
      _pr = repository;
    }
    public List<Crust> CrustList { get; set; }
    public List<Size> SizeList { get; set; }
    public List<Topping> ToppingList { get; set; }

    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public List<Topping> Toppings { get; set; }

    public PizzaViewModel()
    {
      SizeList = _pr.Read<Size>().ToList();
      CrustList = _pr.Read<Crust>().ToList();
      ToppingList = _pr.Read<Topping>().ToList();
    }
    

  }
}