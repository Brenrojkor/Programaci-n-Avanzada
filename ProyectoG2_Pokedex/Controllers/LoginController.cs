using Microsoft.AspNetCore.Mvc;
using ProyectoG2_Pokedex.Models;
using ProyectoG2_Pokedex.Data;
using System.Linq;

namespace ProyectoG2_Pokedex.Controllers
{
    public class LoginController : Controller
    {
        private readonly MinombredeconexionDbContext _context;

        public LoginController(MinombredeconexionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TestDb()
        {
            var users = _context.Usuarios.ToList();
            return Json(users); // Devuelve los usuarios en formato JSON
        }

        // Acción para procesar el login
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {

            Console.WriteLine($"Username: {Username}, Password: {Password}");

            var user = _context.Usuarios.FirstOrDefault(u => u.Usuario == Username && u.Contrasena == Password);
            if (user != null)
            {
                // Redirigir al área protegida si las credenciales son válidas
                return RedirectToAction("Pokedex", "Pokedex");
            }

            // Mostrar mensaje de error si las credenciales son inválidas
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }
    }
}