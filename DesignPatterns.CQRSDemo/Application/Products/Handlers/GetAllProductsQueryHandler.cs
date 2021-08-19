using DesignPatterns.CQRSDemo.Application.Products.Queries;
using DesignPatterns.CQRSDemo.Context;
using DesignPatterns.CQRSDemo.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Application.Products.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        readonly IProductContext _context;
        public GetAllProductsQueryHandler(IProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetAll();
        }
    }
}
