using Microsoft.AspNetCore.Mvc;

namespace ProyectoG2_Pokedex.Controllers
{
    public class RetosController : Controller
    {
        public IActionResult Retos()
        {
            return View();
        }
    }
}
