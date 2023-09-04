using dotnet_demo.models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_demo.repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DbSet<Customer> _customersSet;
    public CustomerRepository(DemoDbContext dbContext)
    {
        _customersSet = dbContext.Customers;
    }

    public Task<Customer> Delete(Customer customer)
    {
         return Task.FromResult(_customersSet.Remove(customer).Entity);
    }

    public async Task<List<Customer>> GetAll()
    {
        return await _customersSet.ToListAsync();
    }

    public async Task<Customer?> GetById(int id)
    {
        return await _customersSet.FindAsync(id);
    }

    public Task<Customer> Create(Customer customer)
    {
        return Task.FromResult(_customersSet.Add(customer).Entity);
    }

    public async Task<Customer?> Update(Customer customer)
    {
        return _customersSet.Any(c => c.Id == customer.Id) ?
            _customersSet.Update(customer).Entity :
            null;
    }
}
