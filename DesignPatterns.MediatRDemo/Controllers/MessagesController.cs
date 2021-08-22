using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesignPatterns.MediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("send-and-wait-for-response")]
        public async Task<IActionResult> SendAndWaitForResponse()
        {
            var response = await _mediator.Send(new Ping());
            return Ok(response);
        }

        [HttpGet("send-without-response")]
        public async Task<IActionResult> SendWithoutResponse()
        {
            await _mediator.Send(new OneWay());
            return Ok("Completed!!!");
        }

        [HttpGet("send-notifications")]
        public async Task<IActionResult> SendNotifications()
        {
            await _mediator.Publish(new PigNotification());
            return Ok("Completed!!!");
        }
    }
}
