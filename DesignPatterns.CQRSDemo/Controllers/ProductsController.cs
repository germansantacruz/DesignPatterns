using DesignPatterns.CQRSDemo.Application.Products.Commands;
using DesignPatterns.CQRSDemo.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesignPatterns.CQRSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            IActionResult result = BadRequest("No se ha creado el producto.");

            int id = await _mediator.Send(command);
            if (id > 0)
            {
                result = Ok($"Producto {id} creado.");
            }

            return result;
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            IActionResult result = BadRequest("No se ha modificado el producto.");

            bool modified = await _mediator.Send(command);
            
            if (modified)
            {
                result = Ok($"Producto {command.Id} ha sido modificado.");
            }

            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            IActionResult result = BadRequest($"El producto {id} no ha sido encontrado.");

            var product = await _mediator.Send(new GetProductByIdQuery { Id = id });

            if (product != null)
            {
                result = Ok(product);
            }

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            IActionResult result = BadRequest("No se ha podido eliminar el producto.");

            bool deleted = await _mediator.Send(new DeleteProductCommand { Id = id });

            if (deleted)
            {
                result = Ok($"Producto {id} ha sido eliminado.");
            }

            return result;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
        {
            IActionResult result = BadRequest("No se ha podido eliminar el producto.");

            bool deleted = await _mediator.Send(command);

            if (deleted)
            {
                result = Ok($"Producto {command.Id} ha sido eliminado.");
            }

            return result;
        }
    }
}
