using DesignPatterns.Mediator.SendOperations;

namespace DesignPatterns.Mediator.Demo.CommandsAndHandlers
{
    public class CreateProduct : IRequest<int>
    {
        public string Name { get; set; }
    }
}
