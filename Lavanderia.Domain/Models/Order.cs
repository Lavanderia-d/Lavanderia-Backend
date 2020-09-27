namespace Lavanderia.Domain.Models
{
    public class Order
    {
        public int Id { get; }
        public Status Status { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; private set; }
    }
}