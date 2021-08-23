using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Filters.Handlers
{
    public class GeneralExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            return SetResult(context, StatusCodes.Status500InternalServerError,
                "Ha ocurrido un error al procesar la petición.",
                context.Exception.Message);
        }
    }
}
