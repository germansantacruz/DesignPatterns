namespace DesignPatterns.Mediator.Notifications
{
    public interface INotificationHandler
    {
        void Handle(string message);
    }
}
