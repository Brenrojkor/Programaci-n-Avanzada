using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Registro_de_Usuarios.Controllers
{
    public class CancionesController : Controller
    {
        public IActionResult Canciones()
        {
            return View("~/Views/Canciones.cshtml");
        }
    }
}
