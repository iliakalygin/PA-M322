using Microsoft.EntityFrameworkCore;
using WebApi.Models;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
      : base(options)
    {
    }
    // Database
    public DbSet<Order> Orders { get; set; }
    public DbSet<Employee> Employees { get; set; }
}