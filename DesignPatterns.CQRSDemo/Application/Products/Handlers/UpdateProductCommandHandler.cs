using DesignPatterns.CQRSDemo.Application.Products.Commands;
using DesignPatterns.CQRSDemo.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Application.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        readonly IProductContext _context;
        public UpdateProductCommandHandler(IProductContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            bool result = false;

            var product = await _context.GetById(command.Id);

            if (product != null)
            {
                product.Name = command.Name;
                product.QuantityPerUnit = command.QuantityPerUnit;
                product.Description = command.Description;
                product.UnitPrice = command.UnitPrice;               
                
                result = await _context.Update(product);
            }
            /*
             * else {
             *      throw new EntityNotFoundException("Product", command.Id);
             * }
             */

            return result;
        }
    }
}
