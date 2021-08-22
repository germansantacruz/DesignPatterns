using DesignPatterns.Mediator.SendOperations;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator.Demo.CommandsAndHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, int>
    {
        public Task<int> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            // Logica para crear un nuevo producto...
            Debug.WriteLine($"Crear el producto: {request.Name}");

            return Task.FromResult(new Random().Next(1, 1000));
        }
    }
}
