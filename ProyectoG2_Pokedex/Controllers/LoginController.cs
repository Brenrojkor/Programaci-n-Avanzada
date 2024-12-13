using Microsoft.AspNetCore.Mvc;
using ProyectoG2_Pokedex.Data;
using System.Linq;
using Microsoft.AspNetCore.Http; // Para trabajar con sesiones
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
                HttpContext.Session.SetInt32("IdUsuario", user.IdUsuario); 
                HttpContext.Session.SetString("NombreUsuario", user.Usuario);

                return RedirectToAction("Pokedex", "Pokedex");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }
    }
}

