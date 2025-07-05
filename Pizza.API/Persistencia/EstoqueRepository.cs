using Pizza.API.Exceptions;
using Pizza.API.Models;

namespace Pizza.API.Persistencia
{
    public class EstoqueRepository(PizzaDbContext dbContext)
    {
        public List<Estoque>GetAll()
        {
        return dbContext.Estoques.ToList();
        }

        public Estoque GetById(int id)
        {
            var estoque = dbContext.Estoques.FirstOrDefault(e => e.Id == id);
            if (estoque == null)
            {
                throw new NaoEncontradoExceptions("EStoque não cadastrado");
            }
            return estoque;
        }
        public Estoque Create(Estoque e) 
        {
        var pizza = dbContext.Pizzas.FirstOrDefault(p => p.Id == e.PizzaId);


            if (pizza == null)
            {
                throw new Exception("A pizza é quantica e nao cadastrada!");
            }

            var existeEstoque = dbContext.Estoques.FirstOrDefault(p => p.PizzaId == e.PizzaId);
            if (existeEstoque is not null)
            {
                throw new Exception("a pizza ja existe em estoque não possivel cadastrar de novo");
            }
            dbContext.Estoques.Add(e);
            dbContext.SaveChanges();
            return e;
        }

        public Estoque GetByPizzaId(int id)
        {
            var e = dbContext.Estoques.FirstOrDefault(p => p.PizzaId == id);

            if (e is null)
            {
                throw new NaoEncontradoExceptions("Não tem pizza com esse Id");

            }

            return e;

        }
        public Estoque Update(int PizzaId, int quantidadeAremover) 
        {
            var estoque = GetByPizzaId(PizzaId);
            if (quantidadeAremover > estoque.Quantidade) {
                throw new ArgumentException("quantidade excedida da possuida");

            }
            estoque.Quantidade -= quantidadeAremover;
            estoque.AtualizadoEm = DateTime.UtcNow;
            dbContext.Update(estoque);
            dbContext.SaveChanges();
            return estoque;
        }

    }
}
