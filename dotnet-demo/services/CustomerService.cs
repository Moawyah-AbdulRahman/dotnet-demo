using dotnet_demo.exeptions;
using dotnet_demo.models;
using dotnet_demo.repositories;

namespace dotnet_demo.services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository; 
    }

    public async Task<Customer> Create(Customer customer)
    {
        if( customer.Id != 0)
        {
            throw new BusinessException("Id must be 0 on create (not set)", ErrorCode.BadRequest);
        }

        return await _customerRepository.Create(customer);
    }

    public async Task<Customer> Delete(int id)
    {
        var customer = await _customerRepository.GetById(id);
        if (customer is null)
        {
            throw new BusinessException("A user with the given id does not exist", ErrorCode.NotFound);
        }

        return await _customerRepository.Delete(customer);
    }

    public async Task<List<Customer>> GetAll()
    {
        return await _customerRepository.GetAll();
    }

    public async Task<Customer> GetById(int id)
    {
        return await _customerRepository.GetById(id) ??
            throw new BusinessException("A user with the given id does not exist", ErrorCode.NotFound);
    }

    public async Task<Customer> Update(Customer customer)
    {
        return await _customerRepository.Update(customer)??
            throw new BusinessException("A user with the given id does not exist", ErrorCode.NotFound);
    }
}
