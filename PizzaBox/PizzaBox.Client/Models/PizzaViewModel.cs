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
    private readonly CrustRepository _cr = new CrustRepository();
    private readonly SizeRepository _sr = new SizeRepository();
    private readonly OrderRepository _or = new OrderRepository();
    private readonly StoreRepository _str = new StoreRepository();

    public List<Crust> CrustList { get; set; }
    public List<Size> SizeList { get; set; }
    public List<Topping> ToppingList { get; set; }

    public string Crust { get; set; }
    public string Size { get; set; }
    public List<Topping> SelectedToppings { get; set; }
    public List<Store> Stores { get; set; }
    public string Store { get; set; }
    public string OrderId { get; set; }
    public PizzaViewModel()
    {
      SizeList = _pr.Read<Size>().ToList();
      CrustList = _pr.Read<Crust>().ToList();
      ToppingList = _pr.Read<Topping>().ToList();
    }

    public void SetToppings(PizzaViewModel pvm)
    {
      List<Topping> x = new List<Topping>();
      foreach(var i in pvm.ToppingList)
      {
        if(i.Selected)
        {
          x.Add(i);
        }
      };
      pvm.SelectedToppings = x;
    }

    public bool Post(PizzaViewModel pvm, long oid)
    {

      Crust crust = _cr.Get(pvm.Crust);
      Size size = _sr.Get(pvm.Size);

      var p = new Pizza(){ CrustId = crust.Id, SizeId = size.Id, OrderId = oid };
      crust.Pizzas = new List<Pizza> { p };
      size.Pizzas = new List<Pizza> { p };
      List<PizzaToppings> pt = new List<PizzaToppings>();
      pvm.SelectedToppings.ForEach(x => pt.Add(new PizzaToppings(){ PizzaId = p.Id, ToppingId = x.Id}));
      p.Price = crust.Price + size.Price + SelectedToppings.Sum(x => x.Price);
      p.PizzaToppings = pt;

      return _pr.Post(p);

    }

  }   

}