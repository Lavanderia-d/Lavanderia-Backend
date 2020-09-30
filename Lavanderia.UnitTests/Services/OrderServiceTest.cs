using System;
using System.Linq;
using Lavanderia.Domain.Dto.Requests;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Enums;
using Lavanderia.Domain.Models;
using Lavanderia.Domain.Responses;
using Lavanderia.Infra.Services;
using Lavanderia.UnitTests.Comparers;
using Lavanderia.UnitTests.Helpers;
using Xunit;

namespace Lavanderia.UnitTests.Services
{
    public class OrderServiceTest
    {
        private OrderFakes _fakes;

        public OrderServiceTest()
        {
            _fakes = new OrderFakes();
        }

        [Fact]
        public void Should_Return_All_Orders_When_GetAll()
        {
            var fakeRepository = _fakes.FakeOrderRepository().Object;

            var orders = fakeRepository.GetAll().Result;
            var response = _fakes.Mapper.Map<OrderResponse[]>(orders);
            var expected = Responses.OkResponse(null, response);

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.GetAll().Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new OrderResponseListComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_GetAll_And_Exception_Is_Thrown()
        {
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;

            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.GetAll().Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.GetAll());
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_All_Customer_Orders_When_GetAllByCustomerId()
        {
            var customerId = 1;
            var fakeRepository = _fakes.FakeOrderRepository().Object;

            var orders = fakeRepository.GetAllByCustomerId(customerId).Result;
            var response = _fakes.Mapper.Map<OrderResponse[]>(orders);
            var expected = Responses.OkResponse(null, response);

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.GetAllByCustomerId(customerId).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new OrderResponseListComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_GetAllByCustomerId_And_Exception_Is_Thrown()
        {
            var customerId = 1;
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;

            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.GetAllByCustomerId(customerId).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.GetAllByCustomerId(customerId));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Should_Return_Order_When_GetById(int id)
        {
            var fakeRepository = _fakes.FakeOrderRepository().Object;

            var order = fakeRepository.GetById(id).Result;
            var response = _fakes.Mapper.Map<OrderResponse>(order);
            var expected = Responses.OkResponse(null, response);

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.GetById(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new OrderResponseComparer());
        }

        [Fact]
        public void Should_Return_NotFound_When_GetById_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeOrderRepository().Object;

            var expected = Responses.NotFoundResponse("Pedido não encontrado.");

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.GetById(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_GetById_And_Exception_Is_Thrown()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;

            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.GetById(id).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.GetById(id));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }
    
        [Fact]
        public void Should_Return_Order_When_Create()
        {
            var fakeRepository = _fakes.FakeOrderRepository().Object;

            var request = _fakes.Get<CreateOrderRequest>().First();
            var order = _fakes.Get<Order>().First();

            var response = _fakes.Mapper.Map<OrderResponse>(order);
            response.Id = Fakes.NewEntityId; // Mocked id when creating a new order
            response.Status = OrderStatus.PENDING; // Order is created with 'pending' status
            var expected = Responses.OkResponse(null, response);

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.Create(request).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new OrderResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_Create_And_Exception_Is_Thrown()
        {
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;

            var request = _fakes.Get<CreateOrderRequest>().First();
            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.Create(request).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.Create(request));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_Updated_Order_When_Update()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderRepository().Object;

            var order = _fakes.Get<Order>().First();
            var request = _fakes.Get<UpdateOrderRequest>().First();

            var response = _fakes.Mapper.Map<OrderResponse>(order);
            var expected = Responses.OkResponse(null, response);

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.Update(id, request).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new OrderResponseComparer());
        }

        [Fact]
        public void Should_Return_NotFound_When_Update_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeOrderRepository().Object;

            var request = new UpdateOrderRequest();
            var expected = Responses.NotFoundResponse("Pedido não encontrado.");

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.Update(id, request).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_Update_And_Exception_Is_Thrown()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;

            var request = new UpdateOrderRequest();
            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.Update(id, request).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.Update(id, request));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }
    
        [Fact]
        public void Should_Return_Ok_When_Delete()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderRepository().Object;

            var expected = Responses.OkResponse("Pedido deletado.");

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.Delete(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_NotFound_When_Delete_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeOrderRepository().Object;

            var expected = Responses.NotFoundResponse("Pedido não encontrado.");

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.Delete(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_Delete_And_Exception_Is_Thrown()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;

            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderService(_fakes.Mapper, fakeRepository);
            var actual = service.Delete(id).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.Delete(id));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }
    }
}