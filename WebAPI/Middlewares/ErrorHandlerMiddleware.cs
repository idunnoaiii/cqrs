using System.Net;
using System.Text.Json;
using Application.Wrappers;

namespace WebAPI.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
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
            HttpResponse httpResponse = context.Response;
            httpResponse.ContentType = "application/json";
            var responseModel = new Response<string>
            {
                Suceeded = false,
                Message = error?.Message
            };
            
            switch (error)
            {
                case Application.Exceptions.ApiException e:
                    //custom application error
                    httpResponse.StatusCode = (int) HttpStatusCode.BadRequest;
                break;
                case Application.Exceptions.ValidationException e:
                    httpResponse.StatusCode = (int) HttpStatusCode.BadRequest;
                    responseModel.Errors = e.Errors;
                    //custom application error
                break;
                case KeyNotFoundException e:
                    httpResponse.StatusCode = (int) HttpStatusCode.NotFound;
                    //Not found error
                break;
                default:
                    //Unhandled error
                    httpResponse.StatusCode = (int) HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(responseModel);
            await httpResponse.WriteAsync(result);
        }
    }
}