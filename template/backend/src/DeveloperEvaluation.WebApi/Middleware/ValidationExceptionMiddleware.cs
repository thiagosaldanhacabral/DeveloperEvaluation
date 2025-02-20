﻿using DeveloperEvaluation.Common.Common;
using DeveloperEvaluation.Common.Validation;
using FluentValidation;
using System.Text.Json;

namespace DeveloperEvaluation.WebApi.Middleware
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex);
            }
        }

        private static Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var response = new ApiResponseError
            {
                Success = false,
                Message = "Validation Failed",
                Errors = exception.Errors
                    .Select(error => (ValidationErrorDetail)error)
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response, _jsonOptions));
        }
    }
}
