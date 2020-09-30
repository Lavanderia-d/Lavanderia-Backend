using System.Collections.Generic;

namespace Lavanderia.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PhoneId { get; set; }
        public virtual Phone Phone { get; set; }
        
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
    }
}