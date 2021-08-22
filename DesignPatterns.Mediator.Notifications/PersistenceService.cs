namespace DesignPatterns.Mediator.Notifications
{
    public class PersistenceService
    {
        readonly IMediator _mediator;

        public PersistenceService(IMediator mediator) => _mediator = mediator;

        public void SaveChanges()
        {
            // logica para guardar cambios ...            

            // Notificar a los manejadores
            _mediator.Publish("SaveChanges");
        }
    }
}
