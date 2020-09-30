using System;
using System.Linq;
using Lavanderia.Domain.Dto.Requests;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Responses;
using Lavanderia.Infra.Services;
using Lavanderia.UnitTests.Comparers;
using Lavanderia.UnitTests.Helpers;
using Xunit;

namespace Lavanderia.UnitTests.Services
{
    public class CustomerServiceTest
    {
        private CustomerFakes _fakes;

        public CustomerServiceTest()
        {
            _fakes = new CustomerFakes();
        }

        [Fact]
        public void Should_Return_All_Customers_When_GetAll()
        {
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var customers = fakeRepository.GetAll().Result;
            var response = _fakes.Mapper.Map<CustomerResponse[]>(customers);
            var expected = Responses.OkResponse(null, response);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.GetAll().Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new CustomerResponseListComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_GetAll_And_Exception_Is_Thrown()
        {
            var fakeRepository = _fakes.FakeCustomerRepository(true).Object;

            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.GetAll().Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.GetAll());
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_Customer_When_GetById(int id)
        {
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var customer = fakeRepository.GetById(id).Result;
            var response = _fakes.Mapper.Map<CustomerResponse>(customer);
            var expected = Responses.OkResponse(null, response);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.GetById(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new CustomerResponseComparer());
        }

        [Fact]
        public void Should_Return_NotFound_When_GetById_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var expected = Responses.NotFoundResponse("Cliente não encontrado.");

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.GetById(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_GetById_And_Exception_Is_Thrown()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeCustomerRepository(true).Object;

            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.GetById(id).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.GetById(id));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }
    
        [Fact]
        public void Should_Return_Customer_When_Create()
        {
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var request = _fakes.Get<CustomerRequest>().First();
            var customer = _fakes.Get<Customer>().First();

            var response = _fakes.Mapper.Map<CustomerResponse>(customer);
            response.Id = Fakes.NewEntityId; // Mocked id when creating a new customer
            var expected = Responses.OkResponse(null, response);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.Create(request).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new CustomerResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_Create_And_Exception_Is_Thrown()
        {
            var fakeRepository = _fakes.FakeCustomerRepository(true).Object;

            var request = _fakes.Get<CustomerRequest>().First();
            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.Create(request).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.Create(request));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_Updated_Customer_When_Update()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var customer = _fakes.Get<Customer>().First();
            var request = _fakes.Get<CustomerRequest>().First();

            var response = _fakes.Mapper.Map<CustomerResponse>(customer);
            var expected = Responses.OkResponse(null, response);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.Update(id, request).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new CustomerResponseComparer());
        }

        [Fact]
        public void Should_Return_NotFound_When_Update_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var request = new CustomerRequest();
            var expected = Responses.NotFoundResponse("Cliente não encontrado.");

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.Update(id, request).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_Update_And_Exception_Is_Thrown()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeCustomerRepository(true).Object;

            var request = new CustomerRequest();
            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.Update(id, request).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.Update(id, request));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }
    
        [Fact]
        public void Should_Return_Updated_Customer_When_UpdatePhone()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var customer = _fakes.Get<Customer>().FirstOrDefault(c => c.Id == id);
            customer.Phone.Number = "9 2222-3333";

            var response = _fakes.Mapper.Map<CustomerResponse>(customer);
            var expected = Responses.OkResponse(null, response);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.UpdatePhone(id, customer.Phone).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new CustomerResponseComparer());
        }

        [Fact]
        public void Should_Return_NotFound_When_UpdatePhone_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var phone = new Phone();
            var expected = Responses.NotFoundResponse("Cliente não encontrado.");

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.UpdatePhone(id, phone).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_UpdatePhone_And_Exception_Is_Thrown()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeCustomerRepository(true).Object;

            var phone = new Phone();
            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.UpdatePhone(id, phone).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.UpdatePhone(id, phone));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }
        
        [Fact]
        public void Should_Return_Updated_Customer_When_UpdateAddress()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var customer = _fakes.Get<Customer>().FirstOrDefault(c => c.Id == id);
            customer.Address.Street = "BlaBlaBla";
            customer.Address.Number = "6666";
            customer.Address.Complement = "C.o.m.p.l.e.m.e.n.t";

            var response = _fakes.Mapper.Map<CustomerResponse>(customer);
            var expected = Responses.OkResponse(null, response);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.UpdateAddress(id, customer.Address).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new CustomerResponseComparer());
        }

        [Fact]
        public void Should_Return_NotFound_When_UpdateAddress_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var address = new Address();
            var expected = Responses.NotFoundResponse("Cliente não encontrado.");

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.UpdateAddress(id, address).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_UpdateAddress_And_Exception_Is_Thrown()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeCustomerRepository(true).Object;

            var address = new Address();
            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.UpdateAddress(id, address).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.UpdateAddress(id, address));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_Ok_When_Delete()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var expected = Responses.OkResponse("Cliente deletado.");

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.Delete(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_NotFound_When_Delete_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeCustomerRepository().Object;

            var expected = Responses.NotFoundResponse("Cliente não encontrado.");

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.Delete(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_Delete_And_Exception_Is_Thrown()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeCustomerRepository(true).Object;

            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new CustomerService(_fakes.Mapper, fakeRepository);
            var actual = service.Delete(id).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.Delete(id));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }
    }
}