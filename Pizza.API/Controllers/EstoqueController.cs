using Microsoft.AspNetCore.Mvc;
using Pizza.API.Models;
using Pizza.API.Persistencia;

namespace Pizza.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController(EstoqueRepository _estoqueRepository) : ControllerBase
    {
        [HttpGet]
        public List<Models.Estoque> GetAll()
        {
            return _estoqueRepository.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Estoque> GetById(int Id)
        {
            return _estoqueRepository.GetById(Id);


        }
        [HttpPost]
        public ActionResult<Models.Estoque> Create(Models.Estoque entity)
        {
            _estoqueRepository.Create(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);

        }
        [HttpGet("pizza/{pizzaId}")]
        public Models.Estoque GetPizzaById(int pizzaId)
        {
            return _estoqueRepository.GetByPizzaId(pizzaId);
        }
        [HttpPut("pizza/{pizzaId}/{quantidade}")]
        public Models.Estoque Update(int pizzaId, int quantidade)
        {
            return _estoqueRepository.Update(pizzaId, quantidade);
        }
    }
}
