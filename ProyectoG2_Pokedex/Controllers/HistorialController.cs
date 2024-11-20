using Microsoft.AspNetCore.Mvc;

namespace ProyectoG2_Pokedex.Controllers
{
    public class HistorialController : Controller
    {
        public IActionResult Historial()
        {
            return View();
        }
    }
}
