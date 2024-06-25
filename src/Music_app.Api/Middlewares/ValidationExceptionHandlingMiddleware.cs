using Music_app.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Music_app.Api.Middlewares;

public class ValidationExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ValidationExceptionHandlingMiddleware> _logger;

    public ValidationExceptionHandlingMiddleware(RequestDelegate next, ILogger<ValidationExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(InvalidValidationException ex)
        {
            _logger.LogError(ex, "FluentValidation failed");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var errors = ex.errors.Select(e =>
                new { PropertyName = e.code, ErrorMessage = e.message }).ToList();

            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = "Validation failed",
                errors
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonResponse = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}