using AutoMapper;
using Lavanderia.Api.Dto.Requests;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Responses;
using DomainCustomerRequest = Lavanderia.Domain.Dto.Requests.CustomerRequest;

namespace Lavanderia.Api.Mappers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResponse>();
            CreateMap<CustomerRequest, Customer>();

            CreateMap<Phone, PhoneResponse>();
            CreateMap<PhoneRequest, Phone>();

            CreateMap<Address, AddressResponse>();
            CreateMap<AddressRequest, Address>();

            CreateMap<DomainCustomerRequest, Customer>();

            CreateMap<CustomerRequest, DomainCustomerRequest>();
        }
    }
}