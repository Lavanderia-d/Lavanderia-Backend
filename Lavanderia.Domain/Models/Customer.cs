namespace Lavanderia.Domain.Models
{
    public class Customer
    {
        public int Id { get; }
        public string Name { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}