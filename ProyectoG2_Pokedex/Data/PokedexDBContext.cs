using ProyectoG2_Pokedex.Controllers;
using ProyectoG2_Pokedex.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoG2_Pokedex.Data
{
    public class MinombredeconexionDbContext : DbContext
    {
        public MinombredeconexionDbContext(DbContextOptions<MinombredeconexionDbContext> options)
        : base(options) { }

        public DbSet<RegistroModel> G2_Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroModel>().ToTable("G2_Usuario");
        }


    }
}
