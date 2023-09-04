using AutoMapper;
using dotnet_demo.services;
using dotnet_demo.requests;
using dotnet_demo.responses;
using Microsoft.AspNetCore.Mvc;
using dotnet_demo.models;
using dotnet_demo.repositories;

namespace dotnet_demo.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CustomersController(ICustomerService customerService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _customerService = customerService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerResponse>>> GetAll()
    {
        var customers = await _customerService.GetAll();

        return customers.Any() ? Ok(_mapper.Map<List<CustomerResponse>>(customers)) : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerResponse>> GetById(int id)
    {
        var customer = await _customerService.GetById(id);

        return Ok(_mapper.Map<CustomerResponse>(customer));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerResponse>> Create(CustomerRequest customerRequest)
    {
        var customer = await _customerService.Create(_mapper.Map<Customer>(customerRequest));

        await _unitOfWork.SaveChangesAsync();
        
        return Ok(_mapper.Map<CustomerResponse>(customer));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerResponse>> Update(int id, CustomerRequest customerRequest)
    {
        var customer = _mapper.Map<Customer>(customerRequest);
        customer.Id = id;

        customer = await _customerService.Update(customer);
        
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<CustomerResponse>(customer);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CustomerResponse>> Delete(int id) {
        var customer = await _customerService.Delete(id);
        
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<CustomerResponse>(customer);
    }
}
