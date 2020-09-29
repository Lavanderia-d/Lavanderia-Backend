using System.Threading.Tasks;
using Lavanderia.Domain.Models;

namespace Lavanderia.Domain.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer[]> GetAll(bool includeOrders = false);
        Task<Customer> GetById(int id, bool includeOrders = false);
    }
}