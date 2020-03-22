namespace PizzaBox.Domain.Abstracts
{
  public abstract class AUserComponent
  {
    public string Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }

  }
}