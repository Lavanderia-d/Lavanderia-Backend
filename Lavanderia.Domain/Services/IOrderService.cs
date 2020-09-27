namespace Lavanderia.Domain.Services
{
    public interface IOrderService
    {
        Task<Response> GetAll();
        Task<Response> GetOrderById(int id);
        Task<Response> GetOrdersByCustomerId(int customerId);
        Task<Response> Create(CreateOrderRequest request);
        Task<Response> Update(int id, UpdateOrderRequest request);
        Task<Response> Delete(int id);
    }
}