using MediatR;

namespace DesignPatterns.CQRSDemo.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        // Solo recibir los datos que se necesite
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
