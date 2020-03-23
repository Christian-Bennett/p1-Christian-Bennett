using System;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public long Id { get; set; }
    public DateTime TimeOfOrder { get; set; }

    #region NAVIGATIONAL PROPERTIES

    public Store Store { get; set; }
    public long StoreId { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }

    #endregion

    public Order()
    {
      //Id = DateTime.Now.Ticks;
    }

  }
}