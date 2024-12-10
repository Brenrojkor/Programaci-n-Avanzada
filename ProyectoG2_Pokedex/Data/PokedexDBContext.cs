using Microsoft.AspNetCore.Mvc;

namespace ProyectoG2_Pokedex.Data
{
    public class PokedexDBContext : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
