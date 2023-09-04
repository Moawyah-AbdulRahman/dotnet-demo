using dotnet_demo.models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_demo;

public class DemoDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost;
            User Id=sa;
            Password=P@ssw0rd;
            Database=demoDb;
            Encrypt=True;
            TrustServerCertificate=True;"
        ); 
    }
}
