using DesignPatterns.CQRSDemo.Application.Products.Commands;
using DesignPatterns.CQRSDemo.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Application.Products.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        readonly IProductContext _context;
       
        public DeleteProductCommandHandler(IProductContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            return await _context.Remove(command.Id);
        }
    }
}
