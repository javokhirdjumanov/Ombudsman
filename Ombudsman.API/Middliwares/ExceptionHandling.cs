using DomainLayer.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Ombudsman.API.Middliwares;
public class ExceptionHandling
{
    private readonly RequestDelegate _next;
    public ExceptionHandling(RequestDelegate next)
        => _next = next;

    public async Task InvokeAsync(
        HttpContext httpContext,
        [FromServices]ILogger<ExceptionHandling> logger)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ValidationException validationException)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            logger.LogError(validationException, validationException.Message);

            await HandleExceptionAsync(httpContext, validationException.Message);
        }
        catch (NotFoundException notFoundException)
        {
            httpContext.Response.StatusCode = (int)(HttpStatusCode.NotFound);

            var serializedObject = JsonSerializer.Serialize(new
            {
                notFoundException.Message
            });

            logger.LogError(notFoundException, notFoundException.Message);

            await HandleExceptionAsync(httpContext, serializedObject);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message);

            logger.LogError(ex, ex.Message);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, string message)
    {
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(message);
    }
}
