using Microsoft.AspNetCore.Mvc;

namespace PracticaProgramada_2.Controllers
{
    public class CancionesController : Controller
    {
        public IActionResult Canciones()
        {
            return View();
        }
    }
}
