using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lavanderia.Api.Mappers;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Repositories;
using Moq;

namespace Lavanderia.UnitTests.Helpers
{
    public class CustomerFakes : Fakes
    {
        public Mock<ICustomerRepository> FakeCustomerRepository(bool exception = false)
        {
            var repository = new Mock<ICustomerRepository>();

            if (!exception)
            {
                repository.Setup(x => x.GetAll(It.IsAny<bool>()))
                    .ReturnsAsync((bool includeOrders) =>
                        Get<Customer>().ToArray());

                repository.Setup(x => x.GetById(It.IsAny<int>(), It.IsAny<bool>()))
                    .ReturnsAsync((int id, bool includeOrders) =>
                        Get<Customer>().FirstOrDefault(c => c.Id == id));

                repository.Setup(x => x.Add(It.IsAny<Customer>()))
                    .Callback<Customer>(c => c.Id = Fakes.NewEntityId);

                repository.Setup(x => x.SaveChangesAsync())
                    .ReturnsAsync(true);
            }
            else
            {
                repository.Setup(x => x.GetAll(It.IsAny<bool>()))
                    .Throws(TestException);

                repository.Setup(x => x.GetById(It.IsAny<int>(), It.IsAny<bool>()))
                    .Throws(TestException);
                
                repository.Setup(x => x.Add(It.IsAny<Customer>()))
                    .Throws(TestException);
                
                repository.Setup(x => x.Update(It.IsAny<Customer>()))
                    .Throws(TestException);

                repository.Setup(x => x.Delete(It.IsAny<Customer>()))
                    .Throws(TestException);

                repository.Setup(x => x.SaveChangesAsync())
                    .Throws(TestException);
            }

            return repository;
        }
    }
}