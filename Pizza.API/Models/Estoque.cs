using System.ComponentModel.DataAnnotations;

namespace Pizza.API.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Mínimo de 1 Unidade.")]
        public int Quantidade { get; set; }
        public DateTime Criadoem { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; }
    }
}
