using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Pedidos.API.HttpClients
{
    public class PizzaApiHttpClient
    {
        //criar um cliente
        public sealed class Client(HttpClient httpClient)
        {
            public async Task<Estoque?> GetEstoque(int pizzaId)
            {
                return await httpClient.GetFromJsonAsync<Estoque>($"/estoque/Pizza/{pizzaId}");
            }
            public async Task UpdateEstoque(int pizzaId, int quantidade)
            {
                var response = await httpClient.PutAsync($"/estoque/pizza/{pizzaId}/{quantidade}", null);
                //garante que vai dar pau se der pau
                response.EnsureSuccessStatusCode();
            }
        }

        //Criar uma classe de retorno
        public class Estoque
        {
            public int Id { get; set; }
            public int PizzaId { get; set; }
            public int Quantidade { get; set; }
        }
    }
}
