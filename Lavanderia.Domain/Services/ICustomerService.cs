using System.Threading.Tasks;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Dto.Requests;
using Lavanderia.Domain.Models;

namespace Lavanderia.Domain.Services
{
    public interface ICustomerService
    {
        Task<Response> GetAll(bool includeOrders = false);
        Task<Response> GetById(int id, bool includeOrders = false);
        Task<Response> Create(CustomerRequest request);
        Task<Response> Update(int id, CustomerRequest request);
        Task<Response> UpdatePhone(int id, Phone request);
        Task<Response> UpdateAddress(int id, Address request);
        Task<Response> Delete(int id);
    }
}