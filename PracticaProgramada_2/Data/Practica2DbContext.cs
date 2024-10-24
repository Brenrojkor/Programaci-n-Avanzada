using Microsoft.EntityFrameworkCore;
using PracticaProgramada_2.Models;

namespace PracticaProgramada_2.Data
{
    public class Practica2DbContext : DbContext
    {
        public Practica2DbContext ( DbContextOptions <Practica2DbContext> options )
            : base( options ) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
    }
}
