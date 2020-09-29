using System.Collections.Generic;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Models;

namespace Lavanderia.Domain.Responses
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PhoneResponse Phone { get; set; }
        public AddressResponse Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}