using Microsoft.EntityFrameworkCore;
using Registro_de_Usuarios.Models;

namespace Registro_de_Usuarios.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.idUsuario);
        }
    }
}
