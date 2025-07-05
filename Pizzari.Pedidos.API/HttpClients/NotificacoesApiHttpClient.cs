using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Pedidos.API.HttpClients
{
    public class NoticacoesApiHttpClient
    {

        public sealed class Clients(HttpClient httpClient)
        {
            public async Task CriarNotificacaoAsync(string pedidoId, string destinatario, string mensagem)
            {
                var res = await httpClient.PostAsJsonAsync("/notificacao", new
                {
                    pedidoId,
                    destinatario,
                    mensagem
                });

                res.EnsureSuccessStatusCode();
            }
        }
    

    }
}
