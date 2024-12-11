using ProyectoG2_Pokedex.Controllers;
using ProyectoG2_Pokedex.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoG2_Pokedex.Data
{
    public class MinombredeconexionDbContext : DbContext
    {
        public MinombredeconexionDbContext(DbContextOptions<MinombredeconexionDbContext> options)
    : base(options) { }

        public DbSet<UsuariosModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuariosModel>().ToTable("Usuarios");
        }
    }
}
