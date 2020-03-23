using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Databases
{
  public class PizzaBoxDbContext : DbContext
  {

    //public PizzaBoxDbContext(DbContextOptions<PizzaBoxDbContext> options) : base(options) { }
    //dotnet add PizzaBox.Storage/PizzaBox.Storage.csproj package microsoft.entityframeworkcore.design
    //dotnet add PizzaBox.Storage/PizzaBox.Storage.csproj package microsoft.entityframeworkcore.sqlserver
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<Crust> Crust { get; set; }
    public DbSet<Topping> Topping { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Store> Store { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345;");
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
      //Set a unique Id for each table
      //Pizza Components
      builder.Entity<Size>().HasKey(s => s.Id);
      builder.Entity<Crust>().HasKey(c => c.Id);
      builder.Entity<Topping>().HasKey(t => t.Id);
      builder.Entity<Pizza>().HasKey(p => p.Id);
      builder.Entity<Pizza>().Property(p => p.Id).ValueGeneratedNever();
      builder.Entity<PizzaToppings>().HasKey(pt => new { pt.PizzaId, pt.ToppingId });
      builder.Entity<Order>().HasKey(o => o.Id);
      builder.Entity<Order>().Property(o => o.Id).ValueGeneratedNever();
      //User Components
      builder.Entity<User>().HasKey(u => u.Id);
      builder.Entity<Store>().HasKey(st => st.Id);



      //Define relationships between tables
      //Pizza Tables
      builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.Size);
      builder.Entity<Crust>().HasMany(c => c.Pizzas).WithOne(p => p.Crust);
      builder.Entity<Topping>().HasMany(t => t.PizzaToppings).WithOne(pt => pt.Topping).HasForeignKey(pt => pt.ToppingId);
      builder.Entity<Pizza>().HasMany(p => p.PizzaToppings).WithOne(pt => pt.Pizza).HasForeignKey(pt => pt.PizzaId);
      //User Tables
      builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User);
      builder.Entity<Store>().HasMany(st => st.Orders).WithOne(o => o.Store);


      builder.Entity<Size>().HasData(new Size[]
      {
        new Size(){ Name = "X-Large", Price = 4.00M },
        new Size(){ Name = "Large", Price = 3.00M },
        new Size(){ Name = "Medium", Price = 2.25M },
        new Size(){ Name = "Small", Price = 1.50M },
      });

      builder.Entity<Crust>().HasData(new Crust[]
      {
        new Crust(){ Name = "Traditional (Fluffy)", Price = 2.00M},
        new Crust(){ Name = "Thin Crust", Price = 1.00M},
        new Crust(){ Name = "New York Style", Price = 1.50M},
        new Crust(){ Name = "Deep Dish", Price = 4.00M},
      });

      builder.Entity<Topping>().HasData(new Topping[]
      {
        new Topping(){ Name = "Marinara Sauce", Price = .75M},
        new Topping(){ Name = "Cheese", Price = 1.00M},
        new Topping(){ Name = "Pepperoni", Price = 1.25M},
        new Topping(){ Name = "Sausage", Price = 1.50M},
      });

      builder.Entity<Store>().HasData(new Store[]
      {
        new Store() { Id = 4, StreetAddress = "230 N Center St", City = "Arlington", State = "TX", Zip = "76011"},
        new Store() { Id = 5, StreetAddress = "989 N Walnut Creek Dr", City = "Mansfield", State = "TX", Zip = "76063"},
        new Store() { Id = 6, StreetAddress = "301 W Rendon Crowley Rd", City = "Burleson", State = "TX", Zip = "76028"},
      });


      builder.Entity<User>().HasData(new User[]
      {
        new User() { Id = 1, UserName = "Person1", Password = "Password12345", Name = "Strong Bad",  StreetAddress = "2700 E Broad St", City = "Mansfield", State = "TX", Zip = "76063", isStore = false},
        new User() { Id = 2, UserName = "Person2", Password = "Password123456",  Name = "Foo Bar", StreetAddress = "2602 Mayfield Rd", City = "Grand Prairie", State = "TX", Zip = "75052", isStore = false},
        new User() { Id = 3, UserName = "Store1", Password = "Password1234567", Name = "Arlington Store", StreetAddress = "1 AT&T Way", City = "Arlington", State = "TX", Zip = "76011", isStore = true},
      });

      builder.Entity<Order>().HasData(new Order[]
      {
        new Order() { Id = 8, UserId = 1, StoreId = 4 }
      });
    }
  }
}