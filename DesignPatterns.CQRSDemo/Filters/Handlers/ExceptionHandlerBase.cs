using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Filters.Handlers
{
    public class ExceptionHandlerBase
    {
        readonly Dictionary<int, string> RFC7231Types = new Dictionary<int, string>
        {
            { StatusCodes.Status404NotFound, "" },
            { StatusCodes.Status500InternalServerError, "" }
        };

        // ValueTask en lugar TAsk mejora un poco el rendimiento
        public Task SetResult(ExceptionContext context, int? status, 
            string title, string detail = "")
        {
            // verificar que status tenga valor
            ProblemDetails details = new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = detail,
                Type = RFC7231Types.ContainsKey(status.Value) ?
                    RFC7231Types[status.Value] : ""
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = status
            };

            context.ExceptionHandled = true;
            return Task.CompletedTask;  // ValueTask.CompletedTask;
        }
    }
}
