using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Mediator.Notifications
{
    public class Mediator : IMediator
    {
        readonly IEnumerable<INotificationHandler> _handlers;

        public Mediator(IEnumerable<INotificationHandler> handlers)
        {
            _handlers = handlers;
        }

        public void Publish(string message)
        {
            // Notificar a los manejadores
            _handlers.ToList().ForEach(handler => handler.Handle(message));
        }
    }
}
