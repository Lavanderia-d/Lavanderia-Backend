using System.Linq;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Repositories;
using Moq;

namespace Lavanderia.UnitTests.Helpers
{
    public class OrderItemFakes : Fakes
    {
        public Mock<IOrderItemRepository> FakeOrderItemRepository(bool exception = false)
        {
            var repository = new Mock<IOrderItemRepository>();

            if (!exception)
            {
                repository.Setup(x => x.GetAll())
                    .ReturnsAsync(Get<OrderItem>().ToArray());

                repository.Setup(x => x.GetAllByOrderId(It.IsAny<int>()))
                    .ReturnsAsync((int orderId) =>
                        Get<OrderItem>().Where(i => i.OrderId == orderId).ToArray());

                repository.Setup(x => x.GetById(It.IsAny<int>()))
                    .ReturnsAsync((int id) =>
                        Get<OrderItem>().FirstOrDefault(i => i.Id == id));

                repository.Setup(x => x.Add(It.IsAny<OrderItem>()))
                    .Callback<OrderItem>(i => i.Id = Fakes.NewEntityId);

                repository.Setup(x => x.SaveChangesAsync())
                    .ReturnsAsync(true);
            }
            else
            {
                repository.Setup(x => x.GetAll())
                    .Throws(TestException);

                repository.Setup(x => x.GetAllByOrderId(It.IsAny<int>()))
                    .Throws(TestException);

                repository.Setup(x => x.GetById(It.IsAny<int>()))
                    .Throws(TestException);
                
                repository.Setup(x => x.Add(It.IsAny<OrderItem>()))
                    .Throws(TestException);
                
                repository.Setup(x => x.Update(It.IsAny<OrderItem>()))
                    .Throws(TestException);

                repository.Setup(x => x.Delete(It.IsAny<OrderItem>()))
                    .Throws(TestException);

                repository.Setup(x => x.SaveChangesAsync())
                    .Throws(TestException);
            }

            return repository;
        }
    }
}