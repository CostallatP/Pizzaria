using Microsoft.EntityFrameworkCore;

namespace Pizza.API.Persistencia
{
    public class PizzaDbContext(DbContextOptions<PizzaDbContext> options) : DbContext(options)
    {
        public DbSet<Models.Pizza> Pizzas { get; set; }
        public DbSet<Models.Estoque> Estoques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Pizza>().HasKey(x => x.Id);

            modelBuilder.Entity<Models.Pizza>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Models.Estoque>().HasKey(x => x.Id);

            modelBuilder.Entity<Models.Estoque>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Models.Estoque>().HasOne(e => e.Pizza).WithOne().HasForeignKey<Models.Estoque>(e => e.PizzaId).IsRequired();

            modelBuilder.Entity<Models.Estoque>().Property(e => e.Quantidade).IsRequired();

            
            
        }
    }
}
