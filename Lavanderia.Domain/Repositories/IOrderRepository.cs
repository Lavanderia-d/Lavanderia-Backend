namespace Lavanderia.Domain.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order[]> GetAllByCustomerId(int customerId);
    }
}