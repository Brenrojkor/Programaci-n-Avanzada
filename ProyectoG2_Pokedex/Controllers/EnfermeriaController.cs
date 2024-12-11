using ProyectoG2_Pokedex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoG2_Pokedex.Controllers
{
    public class EnfermeriaController : Controller
    {
        private static List<EnfermeriaModel> enfermeria = new List<EnfermeriaModel>
        {
            new EnfermeriaModel{ AtencionID = 1, NombrePokemon = "Pikachu", NombreDueño = "Ash Ketchum", Padecimiento = "Lesionado", Estado = "Recuperado" },
            new EnfermeriaModel{ AtencionID = 2, NombrePokemon = "Charmeleon", NombreDueño = "Ash Ketchum", Padecimiento = "Quemado", Estado = "Pendiente" },
            new EnfermeriaModel{ AtencionID = 3, NombrePokemon = "Squirtle", NombreDueño = "Ash Ketchum", Padecimiento = "Ahogado", Estado = "Recuperado" },
            new EnfermeriaModel{ AtencionID = 1, NombrePokemon = "Arbok", NombreDueño = "Ash Ketchum", Padecimiento = "Envenenado", Estado = "Pendiente" }
        };

        public IActionResult Enfermeria()
        {
            return View("~/Views/Enfermeria/Enfermeria.cshtml", enfermeria);
        }

        public IActionResult IngresarPokemon()
        {
            return View("~/Views/Enfermeria/IngresarPokemon.cshtml");
        }

        [HttpPost]
        public IActionResult IngresarPokemon(EnfermeriaModel nuevoPokemon)
        {
            if (ModelState.IsValid)
            {
                nuevoPokemon.AtencionID = enfermeria.Max(e => e.AtencionID) + 1;
                enfermeria.Add(nuevoPokemon);
                return RedirectToAction("Enfermeria");
            }
            return View("~/Views/Enfermeria/IngresarPokemon.cshtml", nuevoPokemon);
        }

        [HttpPost]
        public IActionResult CurarPokemon(int atencionID, [FromServices] HistorialController historial)
        {
            var pokemon = enfermeria.FirstOrDefault(e => e.AtencionID == atencionID);
            if (pokemon != null)
            {
                pokemon.Estado = "Curado";
                historial.AgregarHistorial(new HistorialModel
                {
                    HistorialID = pokemon.AtencionID,
                    NombrePokemon = pokemon.NombrePokemon,
                    NombreDueño = pokemon.NombreDueño,
                    Padecimiento = pokemon.Padecimiento,
                    Estado = pokemon.Estado
                });
                enfermeria.Remove(pokemon);
            }
            return RedirectToAction("Enfermeria");
        }
    }
}
