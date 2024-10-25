using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Registro_de_Usuarios.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Playlist()
        {
            return View("~/Views/Playlist.cshtml");
        }
    }
}
