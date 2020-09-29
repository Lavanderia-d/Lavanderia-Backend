using Lavanderia.Domain.Enums;

namespace Lavanderia.Domain.Dto.Requests
{
    public class UpdateOrderRequest
    {
        public OrderStatus Status { get; set; }
    }
}