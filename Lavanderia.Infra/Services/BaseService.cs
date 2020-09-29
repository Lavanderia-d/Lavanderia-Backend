using System.Net;
using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Services;

namespace Lavanderia.Infra.Services
{
    public class BaseService : IBaseService
    {
        public Response OkResponse(string message = null, object data = null) =>
            Response(HttpStatusCode.OK, message, data);

        public Response BadRequestResponse(string message = null, object data = null) =>
            Response(HttpStatusCode.BadRequest, message, data);

        public Response ForbiddenResponse(string message = null, object data = null) =>
            Response(HttpStatusCode.Forbidden, message, data);

        public Response NotFoundResponse(string message = null, object data = null) =>
            Response(HttpStatusCode.NotFound, message, data);

        public Response ConflictResponse(string message = null, object data = null) =>
            Response(HttpStatusCode.Conflict, message, data);

        private Response Response(HttpStatusCode code, string message, object data)
        {
            return new Response
            {
                Code = StatusCode(code),
                Message = message,
                Data = data
            };
        }

        private int StatusCode(HttpStatusCode code) => (int)code;
    }
}