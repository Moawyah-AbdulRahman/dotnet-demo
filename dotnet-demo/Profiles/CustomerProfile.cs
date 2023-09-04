using AutoMapper;
using dotnet_demo.services;
using dotnet_demo.requests;
using dotnet_demo.responses;
using dotnet_demo.models;

namespace dotnet_demo.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerResponse>()
            .ForMember(
                dest=> dest.Name, 
                opt=> opt.MapFrom(
                    src => $"{src.LastName}, {src.FirstName}")
                );

        CreateMap<CustomerRequest, Customer>();
    }
}
