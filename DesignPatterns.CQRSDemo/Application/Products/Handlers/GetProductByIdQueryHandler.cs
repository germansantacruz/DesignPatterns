using DesignPatterns.CQRSDemo.Application.Products.Queries;
using DesignPatterns.CQRSDemo.Context;
using DesignPatterns.CQRSDemo.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        readonly IProductContext _context;
        public GetProductByIdQueryHandler(IProductContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.GetById(command.Id);
        }
    }
}
