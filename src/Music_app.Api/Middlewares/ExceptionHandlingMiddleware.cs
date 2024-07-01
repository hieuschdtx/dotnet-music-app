using System.Net;
using Music_app.Domain.Exceptions;
using Music_app.Domain.Extensions;
using Music_app.Domain.Models;
using Newtonsoft.Json;

namespace Music_app.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InvalidValidationException ex)
            {
                _logger.LogError(ex, "FluentValidation failed");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)(int)ex.status;

                var errors = ex.errors.Select(e =>
                    new { code = e.code, message = e.message }).ToList();

                var response = new ErrorResponse
                {
                    statusCode = context.Response.StatusCode,
                    message = "Validation failed",
                    errors = errors.Select(e => new ResponseBase(e.code, e.message)).ToList()
                };

                var jsonResponse = JsonExtension.ToJson(response);

                await context.Response.WriteAsync(jsonResponse);
            }
            catch (BusinessRuleException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)ex.status;

                _logger.LogError(ex, $"Business rule exception occurred");

                var response = new ErrorResponse
                {
                    statusCode = context.Response.StatusCode,
                    message = "Business rule failed",
                    errors = new List<ResponseBase>
                    {
                        new ResponseBase(ex.code, ex.Message)
                    }.ToList()
                };

                var jsonResponse = JsonExtension.ToJson(response);

                await context.Response.WriteAsync(jsonResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = new ErrorResponse
                {
                    statusCode = context.Response.StatusCode,
                    message = "An unexpected error occurred",
                    errors = new List<ResponseBase>
                    {
                        new ResponseBase(ex.Source!, ex.Message)
                    }.ToList()
                };

                var jsonResponse = JsonConvert.SerializeObject(response);

                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}