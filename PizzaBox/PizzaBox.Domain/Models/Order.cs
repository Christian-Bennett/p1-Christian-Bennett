using System;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public long Id { get; set; }
    public DateTime TimeOfOrder { get; set; }
    public bool Confirmed { get; set; }
    public decimal Total { get; set; }

    #region NAVIGATIONAL PROPERTIES

    public Store Store { get; set; }
    public long StoreId { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }

    #endregion

    public Order(){ }
    public Order(string username)
    {
      Id = Int64.Parse(DateTime.Now.Ticks.ToString().Substring(0,16));
    }

  }
}