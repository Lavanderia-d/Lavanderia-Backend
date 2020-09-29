using Lavanderia.Domain.Enums;

namespace Lavanderia.Domain.Dto.Requests
{
    public class UpdateOrderItemRequest
    {
        public ItemType Type { get; set; }
        public string Color { get; set; }
        public float Value { get; set; }
    }
}