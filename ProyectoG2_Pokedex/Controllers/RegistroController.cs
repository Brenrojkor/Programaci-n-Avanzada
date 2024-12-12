using Microsoft.AspNetCore.Mvc;
using ProyectoG2_Pokedex.Models;
using ProyectoG2_Pokedex.Data;
using BCrypt.Net;

namespace ProyectoG2_Pokedex.Controllers
{
    public class RegistroController : Controller
    {
        private readonly MinombredeconexionDbContext _context;

        public RegistroController(MinombredeconexionDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Registro()
        {
            var usuario = new UsuariosModel
            {
                Usuario = Request.Form["Usuario"],
                NombreUsuario = Request.Form["NombreUsuario"],
                Contrasena = BCrypt.Net.BCrypt.HashPassword(Request.Form["Contrasena"]), // Hashear contraseña
                Rol = Request.Form["Rol"]
            };

            if (string.IsNullOrEmpty(usuario.Usuario) ||
                string.IsNullOrEmpty(usuario.NombreUsuario) ||
                string.IsNullOrEmpty(usuario.Contrasena) ||
                string.IsNullOrEmpty(usuario.Rol))
            {
                ModelState.AddModelError(string.Empty, "Todos los campos son obligatorios.");
                return View(usuario);
            }

            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return RedirectToAction("Pokedex", "Pokedex");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Hubo un error al registrar el usuario. Inténtalo nuevamente.");
                return View(usuario);
            }
        }
    }
}
