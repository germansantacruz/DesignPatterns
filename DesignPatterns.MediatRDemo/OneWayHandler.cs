using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.MediatRDemo
{
    public class OneWayHandler : AsyncRequestHandler<OneWay>
    {
        protected override Task Handle(OneWay request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Mensaje  OneWay...");
            return Task.CompletedTask;
        }
    }
}
