namespace Lavanderia.Domain.Models
{
    public class OrderItem
    {
        public ItemType Type { get; set; }
        public string Color { get; set; }
        public float Value { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; private set; }
    }
}