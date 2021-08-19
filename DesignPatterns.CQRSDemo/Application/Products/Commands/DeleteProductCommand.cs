using MediatR;

namespace DesignPatterns.CQRSDemo.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
