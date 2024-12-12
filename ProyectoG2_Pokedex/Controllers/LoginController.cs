using Microsoft.AspNetCore.Mvc;
using ProyectoG2_Pokedex.Data;
using BCrypt.Net;

namespace ProyectoG2_Pokedex.Controllers
{
    public class LoginController : Controller
    {
        private readonly MinombredeconexionDbContext _context;

        public LoginController(MinombredeconexionDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Usuario == Username);

            if (user != null && BCrypt.Net.BCrypt.Verify(Password, user.Contrasena))
            {
                // Credenciales válidas
                return RedirectToAction("Pokedex", "Pokedex");
            }

            // Credenciales inválidas
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }
    }
}