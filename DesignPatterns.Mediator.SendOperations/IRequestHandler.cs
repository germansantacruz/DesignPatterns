using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator.SendOperations
{
    public interface IRequestHandler<RequestType>
        where RequestType : IRequest
    {
        // Task para que pueda implementar de forma sincrona o asincrona
        Task Handle(RequestType request, CancellationToken cancellationToken);
    }

    public interface IRequestHandler<RequestType, ResponseType>
        where RequestType : IRequest<ResponseType>
    {
        // Task para que pueda implementar de forma sincrona o asincrona
        Task<ResponseType> Handle(RequestType request, CancellationToken cancellationToken);
    }
}
