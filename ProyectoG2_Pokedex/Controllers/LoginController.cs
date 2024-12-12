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
            // Busca al usuario en la base de datos
            var user = _context.Usuarios.FirstOrDefault(u => u.Usuario == Username);

            if (user != null && BCrypt.Net.BCrypt.Verify(Password, user.Contrasena))
            {
                // Si las credenciales son válidas, guarda la información del usuario en la sesión
                HttpContext.Session.SetInt32("IdUsuario", user.IdUsuario); // Guarda el ID del usuario
                HttpContext.Session.SetString("NombreUsuario", user.Usuario); // Guarda el nombre del usuario

                return RedirectToAction("Pokedex", "Pokedex"); // Redirige al inicio después del login
            }

            // Si las credenciales son inválidas, muestra un mensaje de error
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // Elimina los datos de la sesión al cerrar sesión
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            // Renderiza la vista de login
            return View();
        }
    }
}

