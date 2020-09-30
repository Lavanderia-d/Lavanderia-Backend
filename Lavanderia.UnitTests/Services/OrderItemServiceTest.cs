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
    public class OrderItemServiceTest
    {
        private OrderItemFakes _fakes;

        public OrderItemServiceTest()
        {
            _fakes = new OrderItemFakes();
        }

        [Fact]
        public void Should_Return_All_Items_When_GetAll()
        {
            var fakeRepository = _fakes.FakeOrderItemRepository().Object;

            var items = fakeRepository.GetAll().Result;
            var response = _fakes.Mapper.Map<OrderItemResponse[]>(items);
            var expected = Responses.OkResponse(null, response);

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.GetAll().Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new OrderItemResponseListComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_GetAll_And_Exception_Is_Thrown()
        {
            var fakeRepository = _fakes.FakeOrderItemRepository(true).Object;

            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.GetAll().Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.GetAll());
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_All_Order_Items_When_GetAllByOrderId()
        {
            var orderId = 1;
            var fakeRepository = _fakes.FakeOrderItemRepository().Object;

            var items = fakeRepository.GetAllByOrderId(orderId).Result;
            var response = _fakes.Mapper.Map<OrderItemResponse[]>(items);
            var expected = Responses.OkResponse(null, response);

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.GetAllByOrderId(orderId).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new OrderItemResponseListComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_GetAllByOrderId_And_Exception_Is_Thrown()
        {
            var orderId = 1;
            var fakeRepository = _fakes.FakeOrderItemRepository(true).Object;

            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.GetAllByOrderId(orderId).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.GetAllByOrderId(orderId));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Should_Return_Item_When_GetById(int id)
        {
            var fakeRepository = _fakes.FakeOrderItemRepository().Object;

            var item = fakeRepository.GetById(id).Result;
            var response = _fakes.Mapper.Map<OrderItemResponse>(item);
            var expected = Responses.OkResponse(null, response);

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.GetById(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new OrderItemResponseComparer());
        }

        [Fact]
        public void Should_Return_NotFound_When_GetById_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeOrderItemRepository().Object;

            var expected = Responses.NotFoundResponse("Item não encontrado.");

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.GetById(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_GetById_And_Exception_Is_Thrown()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderItemRepository(true).Object;

            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.GetById(id).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.GetById(id));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }
    
        [Fact]
        public void Should_Return_Item_When_Create()
        {
            var fakeRepository = _fakes.FakeOrderItemRepository().Object;

            var request = _fakes.Get<CreateOrderItemRequest>().First();
            var item = _fakes.Get<OrderItem>().First();

            var response = _fakes.Mapper.Map<OrderItemResponse>(item);
            response.Id = Fakes.NewEntityId; // Mocked id when creating a new item
            var expected = Responses.OkResponse(null, response);

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.Create(request).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new OrderItemResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_Create_And_Exception_Is_Thrown()
        {
            var fakeRepository = _fakes.FakeOrderItemRepository(true).Object;

            var request = _fakes.Get<CreateOrderItemRequest>().First();
            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.Create(request).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.Create(request));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_Updated_Item_When_Update()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderItemRepository().Object;

            var item = _fakes.Get<OrderItem>().First();
            var request = _fakes.Get<UpdateOrderItemRequest>().First();

            var response = _fakes.Mapper.Map<OrderItemResponse>(item);
            var expected = Responses.OkResponse(null, response);

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.Update(id, request).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new OrderItemResponseComparer());
        }

        [Fact]
        public void Should_Return_NotFound_When_Update_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeOrderItemRepository().Object;

            var request = new UpdateOrderItemRequest();
            var expected = Responses.NotFoundResponse("Item não encontrado.");

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.Update(id, request).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_Update_And_Exception_Is_Thrown()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderItemRepository(true).Object;

            var request = new UpdateOrderItemRequest();
            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.Update(id, request).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.Update(id, request));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }
    
        [Fact]
        public void Should_Return_Ok_When_Delete()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderItemRepository().Object;

            var expected = Responses.OkResponse("Item deletado.");

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.Delete(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_NotFound_When_Delete_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeOrderItemRepository().Object;

            var expected = Responses.NotFoundResponse("Item não encontrado.");

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.Delete(id).Result;

            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }

        [Fact]
        public void Should_Return_BadRequest_When_Delete_And_Exception_Is_Thrown()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderItemRepository(true).Object;

            var expected = Responses.BadRequestResponse(Fakes.TestException.Message);

            var service = new OrderItemService(_fakes.Mapper, fakeRepository);
            var actual = service.Delete(id).Result;

            Assert.ThrowsAnyAsync<Exception>(() => service.Delete(id));
            Assert.IsType<Response>(actual);
            Assert.Equal(expected, actual, new ResponseComparer());
        }
    }
}