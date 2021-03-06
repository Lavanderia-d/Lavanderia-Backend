using System.Threading.Tasks;
using AutoMapper;
using Lavanderia.Api.Dto.Requests;
using Lavanderia.Api.Extensions;
using Lavanderia.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lavanderia.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemService _service;

        public OrderItemController(IMapper mapper, IOrderItemService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll();
            return StatusCode(response.Code, response);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetAllByOrderId(int orderId)
        {
            var response = await _service.GetAllByOrderId(orderId);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetById(id);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderItemRequest request)
        {
            var mapped = request.MapToDomainRequest(_mapper);
            var response = await _service.Create(mapped);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderItemRequest request)
        {
            var mapped = request.MapToDomainRequest(_mapper);
            var response = await _service.Update(id, mapped);
            return StatusCode(response.Code, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.Delete(id);
            return StatusCode(response.Code, response);
        }
    }
}