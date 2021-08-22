using DesignPatterns.Mediator.Demo.CommandsAndHandlers;
using DesignPatterns.Mediator.SendOperations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        readonly IMediator _mediator;

        public CommandsController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateProduct(string name)
        {
            int id = await _mediator.Send(new CreateProduct { Name = name });
            return Ok(id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProduct { Id = id });
            return Ok($"Producto {id} eliminado!!!");
        }
    }
}
