using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
    private readonly OrderRepository _or = new OrderRepository();
    public Order order { get; set; }
    public List<Pizza> pizzas { get; set; }
  }
}