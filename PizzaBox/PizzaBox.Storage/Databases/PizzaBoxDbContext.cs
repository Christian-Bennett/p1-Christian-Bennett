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

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345;");
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
      //Set a unique Id for each table
      builder.Entity<Size>().HasKey(s => s.Id);
      builder.Entity<Crust>().HasKey(c => c.Id);
      builder.Entity<Topping>().HasKey(t => t.Id);
      builder.Entity<Pizza>().HasKey(p => p.Id);
      builder.Entity<Pizza>().Property(p => p.Id).ValueGeneratedNever();
      builder.Entity<PizzaToppings>().HasKey(pt => new { pt.PizzaId, pt.ToppingId });

      //Define relationships between tables
      builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.Size);
      builder.Entity<Crust>().HasMany(c => c.Pizzas).WithOne(p => p.Crust);
      builder.Entity<Topping>().HasMany(t => t.PizzaToppings).WithOne(pt => pt.Topping).HasForeignKey(pt => pt.ToppingId);
      builder.Entity<Pizza>().HasMany(p => p.PizzaToppings).WithOne(pt => pt.Pizza).HasForeignKey(pt => pt.PizzaId);


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
        new Topping(){ Name = "Marinara Sauce", Price = .75M },
        new Topping(){ Name = "Cheese", Price = 1.00M },
        new Topping(){ Name = "Pepperoni", Price = 1.25M },
        new Topping(){ Name = "Sausage", Price = 1.50M },
      });
    }
  }
}