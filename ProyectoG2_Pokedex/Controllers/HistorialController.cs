using ProyectoG2_Pokedex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProyectoG2_Pokedex.Controllers
{
    public class HistorialController : Controller
    {
        private static List<HistorialModel> historial = new List<HistorialModel>();

        public IActionResult Historial()
        {
            return View("~/Views/Historial/Historial.cshtml", historial);
        }

        public void AgregarHistorial(HistorialModel pokemonCurado)
        {
            historial.Add(pokemonCurado);
        }
    }
}
