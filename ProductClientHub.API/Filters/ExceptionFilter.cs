using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Communication.Responses;
using ProductionClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Filters;
public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ProductClientHubException productClientHubException)
        {
            context.HttpContext.Response.StatusCode = (int)productClientHubException.GetStatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessagesJson(productClientHubException.GetErrorMessages()));
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson("Erro Desconhecido"));
    }

}