using System.Collections.Generic;
using Lavanderia.Domain.Enums;

namespace Lavanderia.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; private set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}