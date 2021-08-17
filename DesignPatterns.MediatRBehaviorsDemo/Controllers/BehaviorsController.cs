using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesignPatterns.MediatRBehaviorsDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BehaviorsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BehaviorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct(string name)
        {
            IActionResult result;
            try
            {
                int id = await _mediator.Send(new CreateProduct { Name = name });
                result = Ok(id);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }
    }
}
