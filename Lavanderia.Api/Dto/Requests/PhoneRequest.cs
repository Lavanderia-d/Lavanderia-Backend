using System.ComponentModel.DataAnnotations;

namespace Lavanderia.Api.Dto.Requests
{
    public class PhoneRequest
    {   
        [Required(ErrorMessage = "O DDD é necessário.")]
        [StringLength(3, ErrorMessage = "O DDD precisa ter no máximo {1} caracteres.")]
        public string DDD { get; set; }

        [Required(ErrorMessage = "O número de telefone é necessário.")]
        [StringLength(11, ErrorMessage = "O número de telefone precisa ter no máximo {1} caracteres.")]
        public string Number { get; set; }
    }
}