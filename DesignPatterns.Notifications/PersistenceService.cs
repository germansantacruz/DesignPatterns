using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Notifications
{
    public class PersistenceService
    {
        readonly NotificationHandler1 Handler1;
        readonly NotificationHandler2 Handler2;
        readonly NotificationHandler3 Handler3;

        public PersistenceService(NotificationHandler1 handler1,
            NotificationHandler2 handler2, NotificationHandler3 handler3)
        {
            Handler1 = handler1;
            Handler2 = handler2;
            Handler3 = handler3;
        }

        public void SaveChanges()
        {
            // logica para guardar cambios ...
            // Notificar a los manejadores
            Handler1.Handle("SaveChanges");
            Handler2.Handle("SaveChanges");
            Handler3.Handle("SaveChanges");
        }
    }
}
