using System.Threading.Tasks;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Dto.Requests;

namespace Lavanderia.Domain.Services
{
    public interface IOrderItemService
    {
        Task<Response> GetAll();
        Task<Response> GetAllByOrderId(int orderId);
        Task<Response> GetById(int id);
        Task<Response> Create(CreateOrderItemRequest request);
        Task<Response> Update(int id, UpdateOrderItemRequest request);
        Task<Response> Delete(int id);
    }
}