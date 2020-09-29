using System.Linq;
using System.Threading.Tasks;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Repositories;
using Lavanderia.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lavanderia.Infra.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context) {}

        public async Task<Customer[]> GetAll(bool includeOrders)
        {
            IQueryable<Customer> query = _dbContext.Customers;

            if (includeOrders)
            {
                query = query.Include(c => c.Orders)
                             .ThenInclude(o => o.Items);
            }

            return await query.Include(c => c.Phone)
                              .Include(c => c.Address)
                              .AsNoTracking()
                              .OrderBy(c => c.Id)
                              .ToArrayAsync();
        }

        public async Task<Customer> GetById(int id, bool includeOrders)
        {
            IQueryable<Customer> query = _dbContext.Customers;

            if (includeOrders)
            {
                query = query.Include(c => c.Orders)
                             .ThenInclude(o => o.Items);
            }

            return await query.Include(c => c.Phone)
                              .Include(c => c.Address)
                              .AsNoTracking()
                              .FirstOrDefaultAsync(c => c.Id == id);    
        }
    }
}