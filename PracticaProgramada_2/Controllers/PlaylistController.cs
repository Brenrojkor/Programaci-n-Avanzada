using Microsoft.AspNetCore.Mvc;

namespace PracticaProgramada_2.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Playlist()
        {
            return View();
        }
    }
}
