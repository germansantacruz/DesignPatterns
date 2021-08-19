using DesignPatterns.CQRSDemo.Models;
using MediatR;
using System.Collections.Generic;

namespace DesignPatterns.CQRSDemo.Application.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
