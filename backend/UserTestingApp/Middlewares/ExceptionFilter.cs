using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using UserTestingApp.Common.Exceptions;

namespace UserTestingApp.Middlewares;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.Result = context.Exception switch
        {
            NotFoundException => new NotFoundObjectResult(context.Exception.Message),
            NoRigthAnswerException => new BadRequestObjectResult(context.Exception.Message),
            InvalidOperationException => new BadRequestObjectResult(context?.Exception.Message),
            _ => new ObjectResult(new { error = $"An unexpected error occurred: {context.Exception.Message}" })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            }
        };
    }
}
