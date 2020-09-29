using Lavanderia.Domain.Models;

namespace Lavanderia.Domain.Dto.Requests
{
    public class CustomerRequest
    {
        public string Name { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
    }
}