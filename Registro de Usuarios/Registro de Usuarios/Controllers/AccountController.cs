using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registro_de_Usuarios.Data;
using Registro_de_Usuarios.Models;

namespace Registro_de_Usuarios.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View("~/Views/Register.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Register(string usuario, string password)
        {
            var existingUser = await _context.usuarios.FirstOrDefaultAsync(u => u.usuario == usuario);
            if (existingUser != null)
            {
                ModelState.AddModelError("usuario", "Este usuario ya existe.");
                return View();
            }

            var newUser = new Usuario
            {
                usuario = usuario,
                password = password
            };

            _context.usuarios.Add(newUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Login()
        {
            return View("~/Views/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            var user = _context.usuarios
                .FirstOrDefault(u => u.usuario == usuario && u.password == password);

            if (user != null)
            {
                return RedirectToAction("Playlist", "Playlist");
            }

            ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            return View("~/Views/Login.cshtml");
        }
    }
}
