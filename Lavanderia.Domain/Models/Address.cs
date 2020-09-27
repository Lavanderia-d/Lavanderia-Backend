namespace Lavanderia.Domain.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Municipality { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}