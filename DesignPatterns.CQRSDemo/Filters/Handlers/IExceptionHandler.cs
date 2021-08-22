using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Filters.Handlers
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}
