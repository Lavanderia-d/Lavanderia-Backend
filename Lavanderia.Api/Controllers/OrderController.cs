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
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _service;

        public OrderController(IMapper mapper, IOrderService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool includeItems = false)
        {
            var response = await _service.GetAll(includeItems);
            return StatusCode(response.Code, response);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetAllByCustomerId(
            int customerId,
            [FromQuery] bool includeItems = false
        )
        {
            var response = await _service.GetAllByCustomerId(customerId, includeItems);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery] bool includeItems = false)
        {
            var response = await _service.GetById(id, includeItems);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var mapped = request.MapToDomainRequest(_mapper);
            var response = await _service.Create(mapped);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderRequest request)
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