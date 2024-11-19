using Microsoft.AspNetCore.Mvc;

namespace ProyectoG2_Pokedex.Controllers
{
    public class PokedexController : Controller
    {
        public IActionResult Pokedex()
        {
            return View();
        }
    }
}
