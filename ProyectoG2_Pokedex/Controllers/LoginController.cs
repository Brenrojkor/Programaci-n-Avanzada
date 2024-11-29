using Microsoft.AspNetCore.Mvc;
using ProyectoG2_Pokedex.Models;

namespace ProyectoG2_Pokedex.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}