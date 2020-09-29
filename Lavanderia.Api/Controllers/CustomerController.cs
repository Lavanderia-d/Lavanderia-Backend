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
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;

        public CustomerController(IMapper mapper, ICustomerService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool includeOrders = false)
        {
            var response = await _service.GetAll(includeOrders);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery] bool includeOrders = false)
        {
            var response = await _service.GetById(id, includeOrders);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequest request)
        {
            var mapped = request.MapToDomainRequest(_mapper);
            var response = await _service.Create(mapped);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerRequest request)
        {
            var mapped = request.MapToDomainRequest(_mapper);
            var response = await _service.Update(id, mapped);
            return StatusCode(response.Code, response);
        }

        [HttpPatch("{id}/phone")]
        public async Task<IActionResult> UpdatePhone(int id, PhoneRequest request)
        {
            var mapped = request.MapToPhone(_mapper);
            var response = await _service.UpdatePhone(id, mapped);
            return StatusCode(response.Code, response);
        }

        [HttpPatch("{id}/address")]
        public async Task<IActionResult> UpdateAddress(int id, AddressRequest request)
        {
            var mapped = request.MapToAddress(_mapper);
            var response = await _service.UpdateAddress(id, mapped);
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