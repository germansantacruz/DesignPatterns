using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.MediatRDemo
{
    public class PigNotificationHandler1 : INotificationHandler<PigNotification>
    {
        public Task Handle(PigNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Pong 1...");
            return Task.CompletedTask;
        }
    }

    public class PigNotificationHandler2 : INotificationHandler<PigNotification>
    {
        public Task Handle(PigNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Pong 2...");
            return Task.CompletedTask;
        }
    }

    public class PigNotificationHandler3 : INotificationHandler<PigNotification>
    {
        public Task Handle(PigNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Pong 3...");
            return Task.CompletedTask;
        }
    }
}
