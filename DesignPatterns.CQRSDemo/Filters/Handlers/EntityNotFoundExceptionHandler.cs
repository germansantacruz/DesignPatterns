using DesignPatterns.CQRSDemo.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Filters.Handlers
{
    public class EntityNotFoundExceptionHandler : ExceptionHandlerBase,
        IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            EntityNotFoundException exception = context.Exception as
                EntityNotFoundException;

            return SetResult(context, StatusCodes.Status404NotFound,
                "El recurso especificado no fue encontrado",
                $"Recurso {exception.Entity} {exception.Key} no encontrado");
        }
    }
}
