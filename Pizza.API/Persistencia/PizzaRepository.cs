using Pizza.API.Exceptions;
using Pizza.API.Models;
using Pizza.API.Persistencia;


namespace Pizza.API.Persistencia
{
    public class PizzaRepository(PizzaDbContext dbContext)
    {
        public List<Models.Pizza> GetAll()
        {
            return dbContext.Pizzas.ToList();
        }

        public Models.Pizza Add(Models.Pizza pizza)
        {
            dbContext.Pizzas.Add(pizza);
            dbContext.SaveChanges();
            return pizza;
        }

        public Models.Pizza GetById(int id)
        {
            var pizza = dbContext.Pizzas.FirstOrDefault(p => p.Id == id);

            if (pizza is null)
            {
                throw new NaoEncontradoExceptions("Não tem pizza com esse Id");

            }

            return pizza;

        }
    }
}