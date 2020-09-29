using System.Collections.Generic;
using Lavanderia.Domain.Models;

namespace Lavanderia.Domain.Dto.Requests
{
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }
        public IList<OrderItem> Items { get; set; }
    }
}