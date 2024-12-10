using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoG2_Pokedex.Controllers;
using ProyectoG2_Pokedex.Models;

namespace ProyectoG2_Pokedex.Data
{
    public class PokedexDBContext : DbContext
    {
        public PokedexDBContext(DbContextOptions<PokedexDBContext> options)
            : base(options) { }

    }
}
