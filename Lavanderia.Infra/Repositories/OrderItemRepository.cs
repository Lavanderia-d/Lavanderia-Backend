using System.Linq;
using System.Threading.Tasks;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Repositories;
using Lavanderia.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lavanderia.Infra.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DataContext context) : base(context) {}

        public async Task<OrderItem[]> GetAll()
        {
            return await _dbContext.Items
                                   .AsNoTracking()
                                   .OrderBy(i => i.Id)
                                   .ToArrayAsync();
        }

        public async Task<OrderItem[]> GetAllByOrderId(int orderId)
        {
            return await _dbContext.Items
                                   .AsNoTracking()  
                                   .Where(i => i.OrderId == orderId)
                                   .OrderBy(i => i.Id)
                                   .ToArrayAsync();
        }

        public async Task<OrderItem> GetById(int id)
        {
            return await _dbContext.Items
                                   .AsNoTracking()
                                   .Where(i => i.Id == id)
                                   .FirstOrDefaultAsync();
        }
    }
}