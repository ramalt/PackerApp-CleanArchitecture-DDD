using System.Text.Json;
using Microsoft.AspNetCore.Http;
using PackerApp.Shared.Abstractions.Exceptions;

namespace PackerApp.Shared.Exceptions;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (PackerAppException ex)
        {
            
            context.Response.StatusCode = 400;
            context.Response.Headers.Add("content-type", "application/json");
            var errorCode = ToUnderscoreCase(ex.GetType().Name.Replace("Exception", string.Empty));
            var json = JsonSerializer.Serialize(new {errorCode = errorCode, ex.Message});
            await context.Response.WriteAsync(json);
        }
    }

        //transforms the exception class name to underscore case string
       public static string ToUnderscoreCase(string value)
            => string.Concat((value ?? string.Empty).Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(value[i-1]) ? $"_{x}" : x.ToString())).ToLower();
}
