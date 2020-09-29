using System.ComponentModel.DataAnnotations;
using Lavanderia.Domain.Enums;

namespace Lavanderia.Api.Dto.Requests
{
    public class UpdateOrderRequest
    {
        [Required(ErrorMessage = "O status é necessário.")]
        public OrderStatus Status { get; set; }
    }
}