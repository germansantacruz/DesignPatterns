using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Notifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        [HttpGet]
        public IActionResult SaveChanges()
        {
            PersistenceService service = new PersistenceService(new NotificationHandler1(),
                new NotificationHandler2(), new NotificationHandler3());

            service.SaveChanges();
            return Ok("Saved!!!");
        }
    }
}
