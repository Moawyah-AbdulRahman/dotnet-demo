using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using dotnet_demo.exeptions;
using Serilog;

namespace dotnet_demo.filters;

public class DemoExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        if (exception is null)
        {
            return;
        }

        var businessException = exception as BusinessException;

        if (businessException is not null)
        {
            var response = new ObjectResult(new { Massage = businessException.Massage });
            response.StatusCode = (int) businessException.ErrorCode;

            context.Result = response;
            Log.Warning("Bad business request, response: {@response}", response);
        }
        else
        {
            Log.Error("Unhandeled exception: @{exception}", exception);
            base.OnException(context);
        }
    }

}
