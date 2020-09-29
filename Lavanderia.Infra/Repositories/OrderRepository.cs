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

        public async Task<Order[]> GetAll(bool includeItems)
        {
            IQueryable<Order> query = _dbContext.Orders;

            if (includeItems)
            {
                query = query.Include(o => o.Items);
            }

            return await query.AsNoTracking()
                              .OrderBy(o => o.Id)
                              .ToArrayAsync();
        }

        public async Task<Order[]> GetAllByCustomerId(int customerId, bool includeItems)
        {
            IQueryable<Order> query = _dbContext.Orders;

            if (includeItems)
            {
                query = query.Include(o => o.Items);
            }

            return await query.AsNoTracking()  
                              .Where(o => o.CustomerId == customerId)
                              .OrderBy(o => o.Id)
                              .ToArrayAsync();
        }

        public async Task<Order> GetById(int id, bool includeItems)
        {
            IQueryable<Order> query = _dbContext.Orders;

            if (includeItems)
            {
                query = query.Include(o => o.Items);
            }

            return await query.AsNoTracking()
                              .Where(o => o.Id == id)
                              .FirstOrDefaultAsync();
        }
    }
}