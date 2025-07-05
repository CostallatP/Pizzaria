using Pizzaria.Pedidos.API.Models;

namespace Pizzaria.Pedidos.API.Persistencia
{
    public class PedidoRepository(PedidoDbContext dbContext)
    {
        //criar => create
        //getbyId
        //getAll

        public Pedido Create(Pedido pedido)
        {
            dbContext.Pedidos.Add(pedido);
            dbContext.SaveChanges();
            return pedido;
        }

        public Pedido? GetById(Guid id)
        {
            var pedido = dbContext.Pedidos.Find(id);


            if (pedido is null)
            {
                throw new("Não tem pedido com esse Id");

            }

            return pedido;

        }
        public List<Pedido> GetAll()
        {
            return dbContext.Pedidos.ToList();
        }
    }
}
