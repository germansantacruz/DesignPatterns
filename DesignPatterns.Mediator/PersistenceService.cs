using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator
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
