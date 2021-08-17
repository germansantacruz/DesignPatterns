using MediatR;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.MediatRBehaviorsDemo
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, int>
    {
        public Task<int> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Crear el producto {request.Name} con existencia {request.UnitsInStock}");

            return Task.FromResult(new Random().Next(1, 1000));
        }
    }
}
