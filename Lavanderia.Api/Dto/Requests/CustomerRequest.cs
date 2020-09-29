using System.ComponentModel.DataAnnotations;

namespace Lavanderia.Api.Dto.Requests
{
    public class CustomerRequest
    {
        [Required(ErrorMessage = "O nome é necessário.")]
        [StringLength(100, ErrorMessage = "O nome precisa ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O telefone é necessário.")]
        public PhoneRequest Phone { get; set; }

        [Required(ErrorMessage = "O endereço é necessário.")]
        public AddressRequest Address { get; set; }
    }
}