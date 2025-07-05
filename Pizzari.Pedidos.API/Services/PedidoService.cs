using Pizzaria.Pedidos.API.Persistencia;
using Pizzaria.Pedidos.API.Exceptions;
using Pizzaria.Pedidos.API.Models;
using Pizzaria.Pedidos.API.HttpClients;

namespace Pizzaria.Pedidos.API.Services
{
    public class PedidoService(PedidoRepository _repository, PizzaApiHttpClient.Client pizzaApi, NoticacoesApiHttpClient.Clients notificacoesApi)
    {

        //Obterid
        public Pedido? GetById(Guid id)
        {

            var pedido = _repository.GetById(id);
            if (pedido == null)
            {
                throw new NaoEncontradoException("Pedido não encontrado");
            }
            return pedido;
        }
        //allobter
        public List<Pedido> GetAll()
        {
            return _repository.GetAll();
        }
        //Create
        public async Task <Pedido> Create(Pedido pedido)
        {
            //verificar se a pizza existe e se tem estoque
            var estoque = await pizzaApi.GetEstoque(pedido.PizzaId);
            if (estoque == null || estoque.Quantidade < pedido.Quantidade)
            { throw new NaoEncontradoException("Estoque insuficiente"); }

            //salva pedido
            _repository.Create(pedido);
            //atualizar o estoque
            await pizzaApi.UpdateEstoque(pedido.PizzaId, pedido.Quantidade);
            //notificar o cliente
            await notificacoesApi.CriarNotificacaoAsync(
                pedido.Id.ToString(),
                pedido.Cliente,
                $"Seu pedido {pedido.Id} foi confirmado"
            );
        
        return pedido;
        }
    }
}
