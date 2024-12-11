using Microsoft.AspNetCore.Mvc;
using ProyectoG2_Pokedex.Data;
using ProyectoG2_Pokedex.Models;
using System.Linq;

namespace ProyectoG2_Pokedex.Controllers
{
    public class EnfermeriaController : Controller
    {
        private readonly MinombredeconexionDbContext _context;

        public EnfermeriaController(MinombredeconexionDbContext context)
        {
            _context = context;
        }

        // Listar Pokémones en Enfermería
        public IActionResult Enfermeria()
        {
            var pokemones = _context.Enfermeria.ToList();
            return View(pokemones);
        }

        // Actualizar estado a "Recuperado"
        [HttpPost]
        public IActionResult Curar(int id)
        {
            var pokemon = _context.Enfermeria.Find(id);
            if (pokemon != null)
            {
                pokemon.Estado = "Curado";
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Enfermeria));
        }

        // Eliminar Pokémon de la lista
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var pokemon = _context.Enfermeria.Find(id);
            if (pokemon != null)
            {
                _context.Enfermeria.Remove(pokemon);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Enfermeria));
        }

        // Mostrar formulario para agregar Pokémon
        public IActionResult Agregar()
        {
            return View();
        }

        // Agregar un Pokémon a la Enfermería
        [HttpPost]
        public IActionResult Agregar(EnfermeriaModel nuevoPokemon)
        {
            if (ModelState.IsValid)
            {
                nuevoPokemon.Estado = "Pendiente"; // Estado predeterminado
                _context.Enfermeria.Add(nuevoPokemon);
                _context.SaveChanges(); // Guarda los cambios en la base de datos
                return RedirectToAction("Enfermeria"); // Redirige a la vista principal
            }
            return View(nuevoPokemon);
        }

    }
}

