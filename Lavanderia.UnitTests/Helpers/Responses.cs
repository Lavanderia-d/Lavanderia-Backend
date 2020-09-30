using System.Net;
using Lavanderia.Domain.Dto.Responses;

namespace Lavanderia.UnitTests.Helpers
{
    public static class Responses
    {
        public static Response OkResponse(string message = null, object data = null) =>
            Response(HttpStatusCode.OK, message, data);

        public static Response BadRequestResponse(string message = null, object data = null) =>
            Response(HttpStatusCode.BadRequest, message, data);

        public static Response ForbiddenResponse(string message = null, object data = null) =>
            Response(HttpStatusCode.Forbidden, message, data);

        public static Response NotFoundResponse(string message = null, object data = null) =>
            Response(HttpStatusCode.NotFound, message, data);

        public static Response ConflictResponse(string message = null, object data = null) =>
            Response(HttpStatusCode.Conflict, message, data);

        private static Response Response(HttpStatusCode code, string message, object data)
        {
            return new Response
            {
                Code = StatusCode(code),
                Message = message,
                Data = data
            };
        }

        private static int StatusCode(HttpStatusCode code) => (int)code;
    }
}