using Microsoft.AspNetCore.Mvc;
using ProyectoG2_Pokedex.Data;
using ProyectoG2_Pokedex.Models;
using System.Linq;

namespace ProyectoG2_Pokedex.Controllers
{
    public class EntrenadoresController : Controller
    {
        private readonly MinombredeconexionDbContext _context;

        public EntrenadoresController(MinombredeconexionDbContext context)
        {
            _context = context;
        }

        public IActionResult Entrenadores()
        { 
             var entrenadores = _context.Entrenador.ToList();
              return View(entrenadores);

            
        }

    }
}


  
