using DesignPatterns.Mediator.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Mediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        readonly IMediator _mediator;

        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult SaveChanges()
        {
            PersistenceService service = new PersistenceService(_mediator);

            service.SaveChanges();
            return Ok("Saved!!!");
        }
    }
}
