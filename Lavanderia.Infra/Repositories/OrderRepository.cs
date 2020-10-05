using System.Linq;
using System.Threading.Tasks;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Repositories;
using Lavanderia.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lavanderia.Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context) {}

        public async Task<Order[]> GetAll(
            bool includeItems = false,
            bool includeCustomers = false
        )
        {
            IQueryable<Order> query = _dbContext.Orders;

            if (includeItems)
            {
                query = query.Include(o => o.Items);
            }

            if (includeCustomers)
            {
                query = query.Include(o => o.Customer);
            }

            return await query.AsNoTracking()
                              .OrderBy(o => o.Id)
                              .ToArrayAsync();
        }

        public async Task<Order[]> GetAllByCustomerId(
            int customerId,
            bool includeItems = false,
            bool includeCustomer = false
        )
        {
            IQueryable<Order> query = _dbContext.Orders;

            if (includeItems)
            {
                query = query.Include(o => o.Items);
            }

            if (includeCustomer)
            {
                query = query.Include(o => o.Customer);
            }

            return await query.AsNoTracking()  
                              .Where(o => o.CustomerId == customerId)
                              .OrderBy(o => o.Id)
                              .ToArrayAsync();
        }

        public async Task<Order> GetById(
            int id,
            bool includeItems = false,
            bool includeCustomer = false
        )
        {
            IQueryable<Order> query = _dbContext.Orders;

            if (includeItems)
            {
                query = query.Include(o => o.Items);
            }

            if (includeCustomer)
            {
                query = query.Include(o => o.Customer);
            }

            return await query.AsNoTracking()
                              .Where(o => o.Id == id)
                              .FirstOrDefaultAsync();
        }
    }
}