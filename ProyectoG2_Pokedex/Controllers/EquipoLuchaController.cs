using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoG2_Pokedex.Data;
using ProyectoG2_Pokedex.Models;

namespace ProyectoG2_Pokedex.Controllers
{
    public class EquipoLuchaController : Controller
    {
        private readonly MinombredeconexionDbContext _context;

        public EquipoLuchaController(MinombredeconexionDbContext context)
        {
            _context = context;
        }


        public IActionResult EquipoLucha()
        {
            var equipo = _context.Equipo.ToList();
            return View(equipo);
        }

        public IActionResult Agregar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(EquipoLuchaModel equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                _context.SaveChanges();
                return RedirectToAction(nameof(EquipoLucha));
            }
            return View(equipo);
        }


        public IActionResult Editar(string? id)
        {
            if (id == null || _context.Equipo == null)
            {
                return NotFound();
            }

            var equipo = _context.Equipo.Find(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(string id, EquipoLuchaModel equipoEditado)
        {
            if (id != equipoEditado.NombreEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipoEditado);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Equipo.Any(e => e.NombreEquipo == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EquipoLucha));
            }
            return View(equipoEditado);
        }

        public IActionResult Eliminar(string? id)
        {
            if (id == null || _context.Equipo == null)
            {
                return NotFound();
            }

            var equipo = _context.Equipo
                .FirstOrDefault(m => m.NombreEquipo == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult Confirmar(string id)
        {
            var equipo = _context.Equipo.Find(id);
            if (equipo != null)
            {
                _context.Equipo.Remove(equipo);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(EquipoLucha));
        }
    }
}



    

