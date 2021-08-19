using DesignPatterns.CQRSDemo.Application.Products.Commands;
using DesignPatterns.CQRSDemo.Context;
using DesignPatterns.CQRSDemo.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Application.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        readonly IProductContext _context; 
        public CreateProductCommandHandler(IProductContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                QuantityPerUnit = command.QuantityPerUnit,
                Description = command.Description,
                UnitPrice = command.UnitPrice,
                UnitsInStock = command.UnitsInStock,
                UnitsOnOrder = 0,
                ReorderLevel = 0,
                Discontinued = false
            };

            return await _context.Add(product);
        }
    }
}
