using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GameHub.Presentation.Exceptions;

public class DefaultExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = (int)HttpStatusCode.ServiceUnavailable,
            Title = "An unexpected error occurred",
            Detail = exception.Message,
            Type = exception.GetType().ToString(),
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
        }, cancellationToken);

        return true;
    }
}
