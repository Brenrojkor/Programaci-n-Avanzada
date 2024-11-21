using Microsoft.AspNetCore.Mvc;

namespace ProyectoG2_Pokedex.Controllers
{
    public class EntrenadoresController : Controller
    {
        public IActionResult Entrenadores()
        {
            return View();
        }
    }
}
