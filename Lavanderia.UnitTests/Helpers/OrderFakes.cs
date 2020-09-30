using System.Linq;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Repositories;
using Moq;

namespace Lavanderia.UnitTests.Helpers
{
    public class OrderFakes : Fakes
    {
        public Mock<IOrderRepository> FakeOrderRepository(bool exception = false)
        {
            var repository = new Mock<IOrderRepository>();

            if (!exception)
            {
                repository.Setup(x => x.GetAll(It.IsAny<bool>()))
                    .ReturnsAsync((bool includeItems) =>
                        Get<Order>().ToArray());

                repository.Setup(x => x.GetAllByCustomerId(It.IsAny<int>(), It.IsAny<bool>()))
                    .ReturnsAsync((int customerId, bool includeItems) =>
                        Get<Order>().Where(o => o.CustomerId == customerId).ToArray());

                repository.Setup(x => x.GetById(It.IsAny<int>(), It.IsAny<bool>()))
                    .ReturnsAsync((int id, bool includeItems) =>
                        Get<Order>().FirstOrDefault(o => o.Id == id));

                repository.Setup(x => x.Add(It.IsAny<Order>()))
                    .Callback<Order>(o => o.Id = Fakes.NewEntityId);

                repository.Setup(x => x.SaveChangesAsync())
                    .ReturnsAsync(true);
            }
            else
            {
                repository.Setup(x => x.GetAll(It.IsAny<bool>()))
                    .Throws(TestException);

                repository.Setup(x => x.GetAllByCustomerId(It.IsAny<int>(), It.IsAny<bool>()))
                    .Throws(TestException);

                repository.Setup(x => x.GetById(It.IsAny<int>(), It.IsAny<bool>()))
                    .Throws(TestException);
                
                repository.Setup(x => x.Add(It.IsAny<Order>()))
                    .Throws(TestException);
                
                repository.Setup(x => x.Update(It.IsAny<Order>()))
                    .Throws(TestException);

                repository.Setup(x => x.Delete(It.IsAny<Order>()))
                    .Throws(TestException);

                repository.Setup(x => x.SaveChangesAsync())
                    .Throws(TestException);
            }

            return repository;
        }
    }
}