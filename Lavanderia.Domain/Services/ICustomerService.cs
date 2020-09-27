namespace Lavanderia.Domain.Services
{
    public interface ICustomerService
    {
        Task<Response> GetAll();
        Task<Response> GetCustomerById(int id);
        Task<Response> Create(CreateCustomerRequest request);
        Task<Response> Update(int id, UpdateCustomerRequest request);
        Task<Response> Delete(int id);
    }
}