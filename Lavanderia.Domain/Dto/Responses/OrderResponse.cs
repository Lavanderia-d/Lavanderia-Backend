using System.Collections.Generic;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Enums;

namespace Lavanderia.Domain.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public CustomerResponse Customer { get; set; }
        public virtual ICollection<OrderItemResponse> Items { get; set; }
    }
}