using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lavanderia.Domain.Models;

namespace Lavanderia.Api.Dto.Requests
{
    public class CreateOrderRequest
    {
        [Required(ErrorMessage = "O id do cliente é necessário.")]
        public int CustomerId { get; set; }
        
        public IList<OrderItem> Items { get; set; }
    }
}