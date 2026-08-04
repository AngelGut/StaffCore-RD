using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffCoreRD.Data;
using StaffCoreRD.Models;

namespace StaffCoreRD.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffDbContext _context;

        public StaffController(StaffDbContext context)
        {
            _context = context;
        }

        // ========== INDEX (READ) ==========
        [Authorize(Roles = "Administrador,RRHH,Viewer")]
        public async Task<IActionResult> Index()
        {
            // Obtener personal activo ordenado por nombre
            var personal = await _context.Personal
                .Where(s => s.Activo)
                .OrderBy(s => s.Nombre)
                .ToListAsync();

            return View(personal);
        }

        // ========== CREATE GET ==========
        [Authorize(Roles = "Administrador,RRHH")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Staff());
        }

        // ========== CREATE POST ==========
        [Authorize(Roles = "Administrador,RRHH")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Cedula,Cargo,Departamento,Salario,FechaIngreso,Activo")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                TempData["Exito"] = $"Empleado {staff.Nombre} creado exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // ========== EDIT GET ==========
        [Authorize(Roles = "Administrador,RRHH")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Personal.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // ========== EDIT POST ==========
        [Authorize(Roles = "Administrador,RRHH")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Nombre,Cedula,Cargo,Departamento,Salario,FechaIngreso,Activo")] Staff staff)
        {
            if (id != staff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                    TempData["Exito"] = $"Empleado {staff.Nombre} actualizado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(staff);
        }

        // ========== DELETE GET ==========
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Personal.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // ========== DELETE POST ==========
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Personal.FindAsync(id);
            if (staff != null)
            {
                _context.Personal.Remove(staff);
                await _context.SaveChangesAsync();
                TempData["Exito"] = $"Empleado {staff.Nombre} eliminado exitosamente.";
            }

            return RedirectToAction(nameof(Index));
        }

        // ========== HELPER ==========
        private bool StaffExists(int id)
        {
            return _context.Personal.Any(e => e.Id == id);
        }
    }
}