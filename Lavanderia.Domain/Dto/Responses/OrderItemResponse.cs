using Lavanderia.Domain.Enums;

namespace Lavanderia.Domain.Dto.Responses
{
    public class OrderItemResponse
    {
        public int Id { get; set; }
        public ItemType Type { get; set; }
        public string Color { get; set; }
        public float Value { get; set; }
    }
}