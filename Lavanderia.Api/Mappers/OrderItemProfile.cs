using AutoMapper;
using Lavanderia.Api.Dto.Requests;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Models;
using DomainCreateOrderItemRequest = Lavanderia.Domain.Dto.Requests.CreateOrderItemRequest;
using DomainUpdateOrderItemRequest = Lavanderia.Domain.Dto.Requests.UpdateOrderItemRequest;

namespace Lavanderia.Api.Mappers
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemResponse>();
            CreateMap<CreateOrderItemRequest, OrderItem>();
            CreateMap<UpdateOrderItemRequest, OrderItem>();

            CreateMap<DomainCreateOrderItemRequest, OrderItem>();
            CreateMap<DomainUpdateOrderItemRequest, OrderItem>();

            CreateMap<CreateOrderItemRequest, DomainCreateOrderItemRequest>();
            CreateMap<UpdateOrderItemRequest, DomainUpdateOrderItemRequest>();
        }
    }
}