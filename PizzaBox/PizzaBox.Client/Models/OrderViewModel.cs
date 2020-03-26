using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
    private readonly OrderRepository _or = new OrderRepository();
    private readonly UserRepository _ur = new UserRepository();
    private readonly StoreRepository _str = new StoreRepository();
    private readonly PizzaBoxRepository _pr = new PizzaBoxRepository();

    public Order order { get; set; }
    public List<Store> Stores { get; set; }
    public string StoreName { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }
    public string Username { get; set; }
    public List<Pizza> pizzas { get; set; }

    public OrderViewModel(string username, string oid)
    {
      
      if(!long.TryParse(oid, out long num)){
        
        order = new Order(username){};
        Username = username;
        order.UserId = _ur.GetByName(username).Id;
        StoreName = oid;
        UserId = order.UserId;
        order.StoreId = _str.GetByName(oid).Id;

        if(!_ur.GetById(order.UserId).isStore){
        Post(order);
        }
      }
      else{
        
        order = new Order(){ Id = num };
        order = _or.GetById(order.Id);
        Username = _ur.GetById(order.UserId).UserName;  
        StoreName = _str.GetById(order.StoreId).StreetAddress;     
        pizzas = _pr.GetByOrder(order.Id);

               
      }
      
    }
    public OrderViewModel(){}
    public OrderViewModel(long uid)
    {
      order = _or.GetByUserId(uid);
      pizzas = _pr.GetByOrder(order.Id);
    }

    public bool Post(Order order)
    {
      
      Store store  = _str.GetById(order.StoreId);
      User user = _ur.GetById(order.UserId);
      
      var o = new Order(){Id = order.Id, UserId = user.Id, StoreId = store.Id};

      user.Orders = new List<Order> { o };
      store.Orders = new List<Order> { o };

      return _or.Post(o);
    }

    public bool Update(OrderViewModel ovm)
    {
      ovm.order.Confirmed = true;
      ovm.order.TimeOfOrder = DateTime.Now;
      ovm.order.Total = ovm.pizzas.Sum(p => p.Price);
      return _or.Put(ovm.order);
    }


    
  }
}