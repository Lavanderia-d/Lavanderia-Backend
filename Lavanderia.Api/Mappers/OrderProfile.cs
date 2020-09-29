using AutoMapper;
using Lavanderia.Api.Dto.Requests;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Responses;
using DomainCreateOrderRequest = Lavanderia.Domain.Dto.Requests.CreateOrderRequest;
using DomainUpdateOrderRequest = Lavanderia.Domain.Dto.Requests.UpdateOrderRequest;

namespace Lavanderia.Api.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResponse>();
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<UpdateOrderRequest, Order>();

            CreateMap<DomainCreateOrderRequest, Order>();
            CreateMap<DomainUpdateOrderRequest, Order>();

            CreateMap<CreateOrderRequest, DomainCreateOrderRequest>();
            CreateMap<UpdateOrderRequest, DomainUpdateOrderRequest>();
        }
    }
}