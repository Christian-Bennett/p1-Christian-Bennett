using System.Collections.Generic;

namespace PizzaBox.Storage.Interfaces
{
  public interface IRepository
  {
    IEnumerable<T> Read<T>();
  }
}