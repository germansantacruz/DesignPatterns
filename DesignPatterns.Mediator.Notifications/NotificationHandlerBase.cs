using System.Diagnostics;

namespace DesignPatterns.Mediator.Notifications
{
    public abstract class NotificationHandlerBase : INotificationHandler
    {
        public virtual void Handle(string message)
        {
            Debug.WriteLine($"{this.GetType()} => {message}");
        }
    }
}
