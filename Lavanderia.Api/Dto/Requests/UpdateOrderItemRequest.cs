using System.ComponentModel.DataAnnotations;
using Lavanderia.Domain.Enums;

namespace Lavanderia.Api.Dto.Requests
{
    public class UpdateOrderItemRequest
    {
        [Required(ErrorMessage = "O tipo de peça é necessário.")]
        public ItemType Type { get; set; }
        
        [Required(ErrorMessage = "A cor da peça é necessária.")]
        [StringLength(30, ErrorMessage = "A cor da peça precisa ter no máximo {1} caracteres.")]
        public string Color { get; set; }
        
        [Required(ErrorMessage = "O valor da peça é necessário.")]
        public float Value { get; set; }
    }
}