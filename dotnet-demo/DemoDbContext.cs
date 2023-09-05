using dotnet_demo.models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_demo;

public class DemoDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    private readonly IConfiguration _configuration;
    public DemoDbContext(IConfiguration configuration) : base()
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("Database");
        optionsBuilder.UseSqlServer(connectionString); 
    }
}
