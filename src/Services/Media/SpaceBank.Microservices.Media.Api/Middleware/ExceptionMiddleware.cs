﻿using Newtonsoft.Json;
using SpaceBank.Microservices.Media.Api.Errors;
using SpaceBank.Microservices.Media.Application.Exceptions;
using System.Net;

namespace SpaceBank.Microservices.Media.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";

                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;


                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, validationJson));
                        break;

                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    default:
                        break;
                }

                if (string.IsNullOrEmpty(result))
                {
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, ex.StackTrace));
                }

                //var response = _env.IsDevelopment()
                //    ? new CodeErrorException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                //    : new CodeErrorException((int)HttpStatusCode.InternalServerError);

                //var options = new JsonSerializerOptions
                //{
                //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                //};

                //var json = JsonSerializer.Serialize(response, options);

                //       await context.Response.WriteAsync(json);

                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(result);
            }
        }
    }
}
