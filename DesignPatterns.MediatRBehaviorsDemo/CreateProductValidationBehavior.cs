using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.MediatRBehaviorsDemo
{
    public class CreateProductValidationBehavior : IPipelineBehavior<CreateProduct, int>
    {
        public Task<int> Handle(CreateProduct request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentNullException("Name", "El nombre del producto no puede ser nulo");
            }

            return next();
        }
    }
}
