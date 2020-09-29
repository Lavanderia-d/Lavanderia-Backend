using System.Threading.Tasks;
using Lavanderia.Domain.Models;

namespace Lavanderia.Domain.Repositories
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        Task<OrderItem[]> GetAll();
        Task<OrderItem[]> GetAllByOrderId(int orderId);
        Task<OrderItem> GetById(int id);
    }
}