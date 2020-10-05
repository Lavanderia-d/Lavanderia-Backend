using System.Threading.Tasks;
using Lavanderia.Domain.Models;

namespace Lavanderia.Domain.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order[]> GetAll(bool includeItems = false, bool includeCustomers = false);
        Task<Order[]> GetAllByCustomerId(
            int customerId,
            bool includeItems = false,
            bool includeCustomer = false
        );
        Task<Order> GetById(int id, bool includeItems = false, bool includeCustomer = false);
    }
}