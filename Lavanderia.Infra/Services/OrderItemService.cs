using System.Threading.Tasks;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Dto.Requests;
using Lavanderia.Domain.Services;
using System;
using AutoMapper;
using Lavanderia.Domain.Repositories;
using Lavanderia.Domain.Responses;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Enums;

namespace Lavanderia.Infra.Services
{
    public class OrderItemService : BaseService, IOrderItemService
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _repository;

        public OrderItemService(IMapper mapper, IOrderItemRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response> GetAll()
        {
            try
            {
                var items = await _repository.GetAll();
                var response = _mapper.Map<OrderItemResponse[]>(items);
                return OkResponse(null, response);
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> GetAllByOrderId(int orderId)
        {
            try
            {
                var items = await _repository.GetAllByOrderId(orderId);
                var response = _mapper.Map<OrderItemResponse[]>(items);
                return OkResponse(null, response);
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> GetById(int id)
        {
            try
            {
                var item = await _repository.GetById(id);
                if (item == null)
                    return NotFoundResponse("Item não encontrado.");

                var response = _mapper.Map<OrderItemResponse>(item);
                return OkResponse(null, response);
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> Create(CreateOrderItemRequest request)
        {
            try
            {
                var item = _mapper.Map<OrderItem>(request);
                
                _repository.Add(item);

                if (await _repository.SaveChangesAsync())
                {
                    var response = _mapper.Map<OrderItemResponse>(item);
                    return OkResponse(null, response);
                }

                return BadRequestResponse("Erro desconhecido.");
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> Update(int id, UpdateOrderItemRequest request)
        {
            try
            {
                var item = await _repository.GetById(id);
                item.Type = request.Type;
                item.Color = request.Color;
                item.Value = request.Value;

                _repository.Update(item);

                if (await _repository.SaveChangesAsync())
                {
                    var response = _mapper.Map<OrderItemResponse>(item);
                    return OkResponse(null, response);
                }

                return BadRequestResponse("Erro desconhecido.");
            }
            catch (NullReferenceException)
            {
                return NotFoundResponse("Item não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> Delete(int id)
        {
            try
            {
                var item = await _repository.GetById(id);
                if (item == null)
                    return NotFoundResponse("Item não encontrado.");

                _repository.Delete(item);

                if (await _repository.SaveChangesAsync())
                    return OkResponse("Item deletado.");

                return BadRequestResponse("Erro desconhecido.");
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }
    }
}