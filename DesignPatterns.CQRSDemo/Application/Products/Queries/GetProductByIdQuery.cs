using DesignPatterns.CQRSDemo.Models;
using MediatR;

namespace DesignPatterns.CQRSDemo.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
