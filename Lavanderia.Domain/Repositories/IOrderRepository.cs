using System.Threading.Tasks;
using Lavanderia.Domain.Models;

namespace Lavanderia.Domain.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order[]> GetAll(bool includeItems = false);
        Task<Order[]> GetAllByCustomerId(int customerId, bool includeItems = false);
        Task<Order> GetById(int id, bool includeItems = false);
    }
}