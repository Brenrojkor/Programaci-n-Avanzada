using Microsoft.AspNetCore.Mvc;
using ProyectoG2_Pokedex.Data;
using ProyectoG2_Pokedex.Models;
using System.Linq;

namespace ProyectoG2_Pokedex.Controllers
{
    public class MensajesController : Controller
    {
        private readonly MinombredeconexionDbContext _context;

        public MensajesController(MinombredeconexionDbContext context)
        {
            _context = context;
        }

        // Verificar si el usuario está logueado
        private bool UsuarioLogueado()
        {
            return HttpContext.Session.GetInt32("IdUsuario") != null;
        }

        // Vista de la mensajería
        public IActionResult Mensajes()
        {
            if (!UsuarioLogueado())
            {
                // Redirige al login si no está logueado
                return RedirectToAction("Index", "Home");
            }

            var mensajes = _context.Mensajes
                                   .OrderBy(m => m.Fecha)
                                   .Select(m => new
                                   {
                                       m.Mensaje,
                                       Usuario = m.Usuario.Usuario,
                                       m.Fecha
                                   }).ToList();

            ViewBag.Mensajes = mensajes;
            return View();
        }

        [HttpGet]
        public IActionResult ObtenerMensajes()
        {
            var mensajes = _context.Mensajes
                                   .OrderBy(m => m.Fecha)
                                   .Select(m => new
                                   {
                                       m.Mensaje,
                                       Usuario = m.Usuario.Usuario, // Nombre del usuario
                                       Fecha = m.Fecha.ToString("dd/MM/yyyy hh:mm:ss tt") // Formato legible de la fecha
                                   })
                                   .ToList();

            return Json(mensajes);
        }
        [HttpPost]
        public IActionResult Enviar(string texto)
        {
            if (!UsuarioLogueado())
            {
                // Redirige al login si no está logueado
                return RedirectToAction("Index", "Home");
            }

            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");

            if (idUsuario != null)
            {
                var nuevoMensaje = new MensajeModel
                {
                    IdUsuario = idUsuario.Value,
                    Mensaje = texto,
                    Fecha = DateTime.Now
                };

                _context.Mensajes.Add(nuevoMensaje);
                _context.SaveChanges();
            }

            return RedirectToAction("Mensajes");
        }
    }
}
