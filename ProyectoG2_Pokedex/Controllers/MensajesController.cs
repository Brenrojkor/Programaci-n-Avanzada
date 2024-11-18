using Microsoft.AspNetCore.Mvc;

namespace ProyectoG2_Pokedex.Controllers
{
    public class MensajesController : Controller
    {
        public IActionResult Mensajes()
        {
            return View();
        }
    }
}
