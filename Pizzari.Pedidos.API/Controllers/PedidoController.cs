using Microsoft.AspNetCore.Mvc;
using Pizzaria.Pedidos.API.Models;
using Pizzaria.Pedidos.API.Services;

namespace Pizzaria.Pedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController(PedidoService pedidoService) :ControllerBase
    {
        [HttpGet("{id}")]
        public Pedido GetById(Guid id)
        {
            return pedidoService.GetById(id);
        }
        [HttpGet]
        public List<Pedido> GetAll()
        {
            return pedidoService.GetAll();
        }
        [HttpPost]
        public async Task<ActionResult<Pedido>> Create(Pedido pedido)
        {
            await pedidoService.Create(pedido);
            return CreatedAtAction(nameof(GetById), new { id = pedido.Id, pedido});
        }
    }
}
