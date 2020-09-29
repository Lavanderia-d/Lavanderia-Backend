using AutoMapper;
using Lavanderia.Api.Dto.Requests;
using Lavanderia.Domain.Models;
using DomainCustomerRequest = Lavanderia.Domain.Dto.Requests.CustomerRequest;
using DomainCreateOrderRequest = Lavanderia.Domain.Dto.Requests.CreateOrderRequest;
using DomainUpdateOrderRequest = Lavanderia.Domain.Dto.Requests.UpdateOrderRequest;
using DomainCreateOrderItemRequest = Lavanderia.Domain.Dto.Requests.CreateOrderItemRequest;
using DomainUpdateOrderItemRequest = Lavanderia.Domain.Dto.Requests.UpdateOrderItemRequest;

namespace Lavanderia.Api.Extensions
{
    public static class RequestExtensions
    {
        public static DomainCustomerRequest MapToDomainRequest(
            this CustomerRequest request,
            IMapper mapper)
        {
            return mapper.Map<DomainCustomerRequest>(request);
        }

        public static Phone MapToPhone(
            this PhoneRequest request,
            IMapper mapper)
        {
            return mapper.Map<Phone>(request);
        }

        public static Address MapToAddress(
            this AddressRequest request,
            IMapper mapper)
        {
            return mapper.Map<Address>(request);
        }

        public static DomainCreateOrderRequest MapToDomainRequest(
            this CreateOrderRequest request,
            IMapper mapper)
        {
            return mapper.Map<DomainCreateOrderRequest>(request);
        }

        public static DomainUpdateOrderRequest MapToDomainRequest(
            this UpdateOrderRequest request,
            IMapper mapper)
        {
            return mapper.Map<DomainUpdateOrderRequest>(request);
        }

        public static DomainCreateOrderItemRequest MapToDomainRequest(
            this CreateOrderItemRequest request,
            IMapper mapper)
        {
            return mapper.Map<DomainCreateOrderItemRequest>(request);
        }

        public static DomainUpdateOrderItemRequest MapToDomainRequest(
            this UpdateOrderItemRequest request,
            IMapper mapper)
        {
            return mapper.Map<DomainUpdateOrderItemRequest>(request);
        }
    }
}