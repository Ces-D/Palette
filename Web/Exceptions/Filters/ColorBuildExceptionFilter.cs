using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Core.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Web.Exceptions.Filters
{
    public class ColorBuildExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ColorBuildException exception)
            {
                context.Result = new ObjectResult(exception.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
                context.ExceptionHandled = true;
            }
        }
    }
}

