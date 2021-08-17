using MediatR;

namespace DesignPatterns.MediatRBehaviorsDemo
{
    public class CreateProduct : IRequest<int>
    {
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
    }
}
