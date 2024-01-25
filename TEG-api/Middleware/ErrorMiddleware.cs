using System.Net;
using System.Text.Json;
using TEG_api.Middleware.Exceptions;

namespace TEG_api.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ExceptionBadRequestClient e:
                        // 400 Bad Request
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // 404 Not Found
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // 500 Unhandle Errors
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var messageError = error?.Message;
                if (error?.InnerException != null)
                    messageError += error.InnerException;
                var result = JsonSerializer.Serialize(new { message = messageError });
                await response.WriteAsync(result);
            }
        }
    }
}
