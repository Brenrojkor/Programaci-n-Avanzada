using Microsoft.AspNetCore.Mvc;
using ProyectoG2_Pokedex.Data;
using ProyectoG2_Pokedex.Models;


public class RegistroController : Controller
{
    private readonly MinombredeconexionDbContext _context;

    public RegistroController(MinombredeconexionDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Registro()
    {
        return View("~/Views/Login/Registro.cshtml");
    }

    [HttpPost]
    public IActionResult Registro(RegistroModel registro)
    {
        if (ModelState.IsValid)
        {
            _context.G2_Usuario.Add(new RegistroModel
            {
                NombreUsuario = registro.NombreUsuario,
                Contraseña = registro.Contraseña, 
                NombreCompleto = registro.NombreCompleto,
              
            });

            _context.SaveChanges();

            return RedirectToAction("Login", "Login");
        }
    

       
        if (string.IsNullOrEmpty(registro.NombreUsuario))
        {
            ViewData["NombreUsuarioError"] = "El nombre de usuario es obligatorio.";
        }

        if (string.IsNullOrEmpty(registro.Contraseña))
        {
            ViewData["ContraseñaError"] = "La contraseña es obligatoria.";
        }

        if (string.IsNullOrEmpty(registro.NombreCompleto))
        {
            ViewData["NombreCompletoError"] = "El nombre completo es obligatorio.";
        }

        return View("~/Views/Login/Registro.cshtml", registro);



    }
}

