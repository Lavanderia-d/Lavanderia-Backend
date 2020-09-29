namespace Lavanderia.Domain.Dto.Responses
{
    public class AddressResponse
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Municipality { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}