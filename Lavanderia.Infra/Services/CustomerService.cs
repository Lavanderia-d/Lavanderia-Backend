using System;
using System.Threading.Tasks;
using AutoMapper;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Repositories;
using Lavanderia.Domain.Dto.Requests;
using Lavanderia.Domain.Responses;
using Lavanderia.Domain.Services;

namespace Lavanderia.Infra.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _repository;

        public CustomerService(IMapper mapper, ICustomerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response> GetAll(bool includeOrders)
        {
            try
            {
                var customers = await _repository.GetAll(includeOrders);
                var response = _mapper.Map<CustomerResponse[]>(customers);
                return OkResponse(null, response);
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> GetById(int id, bool includeOrders)
        {
            try
            {
                var customer = await _repository.GetById(id, includeOrders);
                if (customer == null)
                    return NotFoundResponse("Cliente não encontrado.");

                var response = _mapper.Map<CustomerResponse>(customer);
                return OkResponse(null, response);
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> Create(CustomerRequest request)
        {
            try
            {
                var customer = _mapper.Map<Customer>(request);
                
                _repository.Add(customer);

                if (await _repository.SaveChangesAsync())
                {
                    var response = _mapper.Map<CustomerResponse>(customer);
                    return OkResponse(null, response);
                }

                return BadRequestResponse("Erro desconhecido.");
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> Update(int id, CustomerRequest request)
        {
            try
            {
                var customer = await _repository.GetById(id);
                customer.Name = request.Name;
                customer.Phone = request.Phone;
                customer.Address = request.Address;

                _repository.Update(customer);

                if (await _repository.SaveChangesAsync())
                {
                    var response = _mapper.Map<CustomerResponse>(customer);
                    return OkResponse(null, response);
                }

                return BadRequestResponse("Erro desconhecido.");
            }
            catch (NullReferenceException)
            {
                return NotFoundResponse("Cliente não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> UpdatePhone(int id, Phone request)
        {
            try
            {
                var customer = await _repository.GetById(id);
                customer.Phone = request;

                _repository.Update(customer);

                if (await _repository.SaveChangesAsync())
                {
                    var response = _mapper.Map<CustomerResponse>(customer);
                    return OkResponse(null, response);
                }

                return BadRequestResponse("Erro desconhecido.");
            }
            catch (NullReferenceException)
            {
                return NotFoundResponse("Cliente não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }

        public async Task<Response> UpdateAddress(int id, Address request)
        {
            try
            {
                var customer = await _repository.GetById(id);
                customer.Address = request;

                _repository.Update(customer);

                if (await _repository.SaveChangesAsync())
                {
                    var response = _mapper.Map<CustomerResponse>(customer);
                    return OkResponse(null, response);
                }

                return BadRequestResponse("Erro desconhecido.");
            }
            catch (NullReferenceException)
            {
                return NotFoundResponse("Cliente não encontrado.");
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
                var customer = await _repository.GetById(id);
                if (customer == null)
                    return NotFoundResponse("Cliente não encontrado.");

                _repository.Delete(customer);

                if (await _repository.SaveChangesAsync())
                    return OkResponse("Cliente deletado.");

                return BadRequestResponse("Erro desconhecido.");
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex.Message);
            }
        }
    }
}