using System.Linq;
using System.Net;
using Lavanderia.Api.Controllers;
using Lavanderia.Api.Dto.Requests;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Responses;
using Lavanderia.Infra.Services;
using Lavanderia.UnitTests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Lavanderia.UnitTests.Controllers
{
    public class OrderControllerTest
    {        
        private OrderFakes _fakes;

        public OrderControllerTest()
        {
            _fakes = new OrderFakes();
        }

        [Fact]
        public void Should_Return_Ok_When_GetAll()
        {
            var fakeRepository = _fakes.FakeOrderRepository().Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.GetAll();

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.OK), result.StatusCode);
        }

        [Fact]
        public void Should_Return_BadRequest_When_GetAll_And_An_Error_Occurs()
        {
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.GetAll();

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.BadRequest), result.StatusCode);
        }

        [Fact]
        public void Should_Return_Ok_When_GetAllByCustomerId()
        {
            var customerId = 1;
            var fakeRepository = _fakes.FakeOrderRepository().Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.GetAllByCustomerId(customerId);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.OK), result.StatusCode);
        }

        [Fact]
        public void Should_Return_BadRequest_When_GetAllByCustomerId_And_An_Error_Occurs()
        {
            var customerId = 1;
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.GetAllByCustomerId(customerId);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.BadRequest), result.StatusCode);
        }

        [Fact]
        public void Should_Return_Ok_When_GetById()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderRepository().Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.GetById(id);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.OK), result.StatusCode);
        }

        [Fact]
        public void Should_Return_NotFound_When_GetById_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeOrderRepository().Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.GetById(id);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.NotFound), result.StatusCode);
        }

        [Fact]
        public void Should_Return_BadRequest_When_GetById_And_An_Error_Occurs()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.GetById(id);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.BadRequest), result.StatusCode);
        }
    
        [Fact]
        public void Should_Return_Ok_When_Create()
        {
            var fakeRepository = _fakes.FakeOrderRepository().Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var request = _fakes.Get<CreateOrderRequest>().First();

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.Create(request);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.OK), result.StatusCode);
        }

        [Fact]
        public void Should_Return_BadRequest_When_Create_And_An_Error_Occurs()
        {
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var request = _fakes.Get<CreateOrderRequest>().First();

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.Create(request);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.BadRequest), result.StatusCode);
        }

        [Fact]
        public void Should_Return_Ok_When_Update()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderRepository().Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var request = _fakes.Get<UpdateOrderRequest>().First();

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.Update(id, request);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.OK), result.StatusCode);
        }

        [Fact]
        public void Should_Return_NotFound_When_Update_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeOrderRepository().Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var request = _fakes.Get<UpdateOrderRequest>().First();

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.Update(id, request);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.NotFound), result.StatusCode);
        }

        [Fact]
        public void Should_Return_BadRequest_When_Update_And_An_Error_Occurs()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var request = _fakes.Get<UpdateOrderRequest>().First();

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.Update(id, request);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.BadRequest), result.StatusCode);
        }
    
        [Fact]
        public void Should_Return_Ok_When_Delete()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderRepository().Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.Delete(id);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.OK), result.StatusCode);
        }

        [Fact]
        public void Should_Return_NotFound_When_Delete_With_An_Incorrect_Id()
        {
            var id = 0; // Does not exist!
            var fakeRepository = _fakes.FakeOrderRepository().Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.Delete(id);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.NotFound), result.StatusCode);
        }

        [Fact]
        public void Should_Return_BadRequest_When_Delete_And_An_Error_Occurs()
        {
            var id = 1;
            var fakeRepository = _fakes.FakeOrderRepository(true).Object;
            var service = new OrderService(_fakes.Mapper, fakeRepository);

            var controller = new OrderController(_fakes.Mapper, service);
            var actual = controller.Delete(id);

            Assert.NotNull(actual);
            Assert.IsType<ObjectResult>(actual.Result);

            var result = actual.Result as ObjectResult;
            Assert.NotNull(result.Value);
            Assert.IsType<Response>(result.Value);
            Assert.Equal(Responses.StatusCode(HttpStatusCode.BadRequest), result.StatusCode);
        }
    }
}