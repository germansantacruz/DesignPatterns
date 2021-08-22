using DesignPatterns.Mediator.SendOperations;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator.Demo.CommandsAndHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct>
    {
        public Task Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            // Logica para eliminar el producto...
            Debug.WriteLine($"Eliminar el producto {request.Id}");

            //for (int i = 0; i < 1000; i++)
            //{
            //    if (cancellationToken.IsCancellationRequested) break;
            //    Task.Delay(10000);
            //}

            return Task.CompletedTask;
        }
    }
}
