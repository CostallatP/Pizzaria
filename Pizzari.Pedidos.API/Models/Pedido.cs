using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Pedidos.API.Models
{
    public class Pedido
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Cliente { get; set; } = string.Empty;
        public int PizzaId { get; set; }
        public int Quantidade { get; set; }
        public enum StatusPedido
        {
            Recebido,
            EmPreparacao,
            Finalizado
        }
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; }
    }
}
