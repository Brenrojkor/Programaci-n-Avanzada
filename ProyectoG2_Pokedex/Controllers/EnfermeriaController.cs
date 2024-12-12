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

        public IActionResult Enfermeria()
        {
            var pokemones = _context.Enfermeria.ToList();
            return View(pokemones);
        }

        [HttpPost]
        public IActionResult Curar(int id)
        {
            var pokemon = _context.Enfermeria.Find(id);
            if (pokemon != null)
            {
                if (pokemon.Estado == "Curado")
                {
                    TempData["Mensaje"] = $"{pokemon.NombrePokemon} ya está curado.";
                }
                else
                {
                    pokemon.Estado = "Curado";
                    _context.SaveChanges();
                    TempData["Mensaje"] = $"{pokemon.NombrePokemon} ha sido curado.";
                }
            }
            else
            {
                TempData["Mensaje"] = "No se encontró el Pokémon.";
            }
            return RedirectToAction(nameof(Enfermeria));
        }


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

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(EnfermeriaModel nuevoPokemon)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine("ModelState Error: " + error.ErrorMessage);
                }
                return View(nuevoPokemon);
            }

            try
            {
                nuevoPokemon.Estado = "Pendiente";
                _context.Enfermeria.Add(nuevoPokemon);
                _context.SaveChanges();
                return RedirectToAction("Enfermeria");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Error: " + ex.Message);
                ModelState.AddModelError("", "Ocurrió un error al guardar los datos en la base de datos.");
                return View(nuevoPokemon);
            }
        }
    }
}

