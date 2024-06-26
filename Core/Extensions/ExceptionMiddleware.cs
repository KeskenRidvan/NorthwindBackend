﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Core.Extensions;
public class ExceptionMiddleware
{
	private RequestDelegate _next;

	public ExceptionMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext httpContext)
	{
		try
		{
			await _next(httpContext);
		}
		catch (Exception exception)
		{
			await HandleExceptionAsync(httpContext, exception);
		}
	}

	private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
	{
		httpContext.Response.ContentType = "application/json";
		httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

		string message = "Internal Server Error";

		if (exception.GetType().Equals(typeof(ValidationException)))
			message = exception.Message;


		return httpContext.Response.WriteAsync(new ErrorDetails
		{
			StatusCode = httpContext.Response.StatusCode,
			Message = message
		}.ToString());
	}
}