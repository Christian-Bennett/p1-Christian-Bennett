using System;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public long Id { get; set; }
    public DateTime TimeOfOrder { get; set; }
    public bool Confirmed { get; set; }

    #region NAVIGATIONAL PROPERTIES

    public Store Store { get; set; }
    public long StoreId { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }

    #endregion

    public Order()
    {
      Id = DateTime.Now.Ticks;
    }
    public Order(string username)
    {
      Id = DateTime.Now.Ticks;
    }

  }
}