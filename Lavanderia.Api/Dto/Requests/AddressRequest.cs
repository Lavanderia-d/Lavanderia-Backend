using System.ComponentModel.DataAnnotations;

namespace Lavanderia.Api.Dto.Requests
{
    public class AddressRequest
    {
        [Required(ErrorMessage = "O logradouro é necessário.")]
        [StringLength(255, ErrorMessage = "O logradouro precisa ter no máximo {1} caracteres.")]
        public string Street { get; set; }
     
        [Required(ErrorMessage = "O número é necessário.")]
        [StringLength(6, ErrorMessage = "O número precisa ter no máximo {1} caracteres.")]
        public string Number { get; set; }
        
        [StringLength(255, ErrorMessage = "O complemento precisa ter no máximo {1} caracteres.")]
        public string Complement { get; set; }
        
        [Required(ErrorMessage = "O município é necessário.")]
        [StringLength(100, ErrorMessage = "O município precisa ter no máximo {1} caracteres.")]
        public string Municipality { get; set; }
        
        [Required(ErrorMessage = "O estado é necessário.")]
        [StringLength(100, ErrorMessage = "O estado precisa ter no máximo {1} caracteres.")]
        public string State { get; set; }
        
        [Required(ErrorMessage = "O CEP é necessário.")]
        [StringLength(9, ErrorMessage = "O CEP precisa ter no máximo {1} caracteres.")]
        public string PostalCode { get; set; }
    }
}