using dotnet_demo.models;

namespace dotnet_demo.services;

public interface ICustomerService
{
    Task<Customer> Delete(int id);
    Task<List<Customer>> GetAll();
    Task<Customer> GetById(int id);
    Task<Customer> Update(Customer customer);
    Task<Customer> Create(Customer customer);
}
