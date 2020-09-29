using System.Threading.Tasks;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Dto.Requests;

namespace Lavanderia.Domain.Services
{
    public interface IOrderService
    {
        Task<Response> GetAll(bool includeItems = false);
        Task<Response> GetAllByCustomerId(int customerId, bool includeItems = false);
        Task<Response> GetById(int id, bool includeItems = false);
        Task<Response> Create(CreateOrderRequest request);
        Task<Response> Update(int id, UpdateOrderRequest request);
        Task<Response> Delete(int id);
    }
}