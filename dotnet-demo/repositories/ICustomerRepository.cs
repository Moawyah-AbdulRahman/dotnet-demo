using dotnet_demo.models;

namespace dotnet_demo.repositories;

public interface ICustomerRepository
{
    Task<Customer> Delete(Customer customer);
    Task<List<Customer>> GetAll();
    Task<Customer?> GetById(int id);
    Task<Customer> Create(Customer customer);
    Task<Customer?> Update(Customer customer);
}