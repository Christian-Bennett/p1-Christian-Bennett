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
    public List<Store> Stores { get; set; }
    public string StoreName { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }
    public string Username { get; set; }
    public List<Pizza> pizzas { get; set; }

    public OrderViewModel(string username)
    {
      order = new Order(username){};
      Username = username;
    }
  }
}