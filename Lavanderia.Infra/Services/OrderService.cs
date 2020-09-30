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
    public class OrderService : BaseService, IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;

        public OrderService(IMapper mapper, IOrderRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response> GetAll(bool includeItems = false)
        {
            try
            {
                var orders = await _repository.GetAll(includeItems);
                var response = _mapper.Map<OrderResponse[]>(orders);
                return OkResponse(null, response);
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> GetAllByCustomerId(int customerId, bool includeItems = false)
        {
            try
            {
                var orders = await _repository.GetAllByCustomerId(customerId, includeItems);
                var response = _mapper.Map<OrderResponse[]>(orders);
                return OkResponse(null, response);
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> GetById(int id, bool includeItems = false)
        {
            try
            {
                var order = await _repository.GetById(id, includeItems);
                if (order == null)
                    return NotFoundResponse("Pedido não encontrado.");

                var response = _mapper.Map<OrderResponse>(order);
                return OkResponse(null, response);
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> Create(CreateOrderRequest request)
        {
            try
            {
                var order = _mapper.Map<Order>(request);
                order.Status = OrderStatus.PENDING;
                
                _repository.Add(order);

                if (await _repository.SaveChangesAsync())
                {
                    var response = _mapper.Map<OrderResponse>(order);
                    return OkResponse(null, response);
                }

                return BadRequestResponse("Erro desconhecido.");
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> Update(int id, UpdateOrderRequest request)
        {
            try
            {
                var order = await _repository.GetById(id);
                order.Status = request.Status;

                _repository.Update(order);

                if (await _repository.SaveChangesAsync())
                {
                    var response = _mapper.Map<OrderResponse>(order);
                    return OkResponse(null, response);
                }

                return BadRequestResponse("Erro desconhecido.");
            }
            catch (NullReferenceException)
            {
                return NotFoundResponse("Pedido não encontrado.");
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
                var order = await _repository.GetById(id);
                if (order == null)
                    return NotFoundResponse("Pedido não encontrado.");

                _repository.Delete(order);

                if (await _repository.SaveChangesAsync())
                    return OkResponse("Pedido deletado.");

                return BadRequestResponse("Erro desconhecido.");
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }
    }
}