using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.MediatRDemo
{
    public class PingHandler : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }
}
