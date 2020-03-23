using Microsoft.AspNetCore.Mvc;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    [HttpGet]
    public IActionResult NewOrder()
    {
      return View("Order");
    }
  }
}