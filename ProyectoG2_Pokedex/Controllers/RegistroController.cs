using Microsoft.AspNetCore.Mvc;
using ProyectoG2_Pokedex.Models;
using ProyectoG2_Pokedex.Data;

namespace ProyectoG2_Pokedex.Controllers
{
    public class RegistroController : Controller
    {
        private readonly MinombredeconexionDbContext _context;

        public RegistroController(MinombredeconexionDbContext context)
        {
            _context = context;
        }

        // Método POST: Procesa el formulario de registro con enlace manual
        [HttpPost]
        public IActionResult Registro()
        {
            // Crear manualmente el modelo usando los datos enviados en el formulario
            var usuario = new UsuariosModel
            {
                Usuario = Request.Form["Usuario"],
                NombreUsuario = Request.Form["NombreUsuario"],
                Contrasena = Request.Form["Contrasena"],
                Rol = Request.Form["Rol"]
            };

            // Imprime los valores recibidos para depuración
            Console.WriteLine($"Usuario: {usuario.Usuario}, NombreUsuario: {usuario.NombreUsuario}, Contraseña: {usuario.Contrasena}, Rol: {usuario.Rol}");

            // Validar manualmente que todos los campos estén completos
            if (string.IsNullOrEmpty(usuario.Usuario) ||
                string.IsNullOrEmpty(usuario.NombreUsuario) ||
                string.IsNullOrEmpty(usuario.Contrasena) ||
                string.IsNullOrEmpty(usuario.Rol))
            {
                Console.WriteLine("Todos los campos son obligatorios.");
                ModelState.AddModelError(string.Empty, "Todos los campos son obligatorios.");
                return View(usuario); // Devuelve la vista con mensajes de error
            }

            try
            {
                // Guarda el nuevo usuario en la base de datos
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                Console.WriteLine("Usuario registrado con éxito.");
                // Redirige al login después de un registro exitoso
                return RedirectToAction("Pokedex", "Pokedex");
            }
            catch (Exception ex)
            {
                // Muestra cualquier error al guardar en la base de datos
                Console.WriteLine($"Error al guardar el usuario: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Hubo un error al registrar el usuario. Inténtalo nuevamente.");
                return View(usuario);
            }
        }
    }
}
