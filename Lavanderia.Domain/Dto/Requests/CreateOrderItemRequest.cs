using Lavanderia.Domain.Enums;

namespace Lavanderia.Domain.Dto.Requests
{
    public class CreateOrderItemRequest
    {
        public ItemType Type { get; set; }
        public string Color { get; set; }
        public float Value { get; set; }
        public int OrderId { get; set; }
    }
}