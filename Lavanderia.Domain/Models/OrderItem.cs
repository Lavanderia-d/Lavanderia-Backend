using Lavanderia.Domain.Enums;

namespace Lavanderia.Domain.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public ItemType Type { get; set; }
        public string Color { get; set; }
        public float Value { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; private set; }
    }
}