using Microsoft.EntityFrameworkCore;
using Pizzaria.Pedidos.API.Models;

namespace Pizzaria.Pedidos.API.Persistencia
{
    public class PedidoDbContext(DbContextOptions<PedidoDbContext> options) : DbContext(options)
    {
        public DbSet<Pedido> Pedidos { get; set; } = null;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().HasKey(x => x.Id);

            modelBuilder.Entity<Pedido>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
