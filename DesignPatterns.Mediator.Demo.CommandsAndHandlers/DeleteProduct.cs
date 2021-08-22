using DesignPatterns.Mediator.SendOperations;

namespace DesignPatterns.Mediator.Demo.CommandsAndHandlers
{
    public class DeleteProduct : IRequest
    {
        public int Id { get; set; }
    }
}
