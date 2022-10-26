using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET_CRUD_example_2.DataContexts;
using ASP.NET_CRUD_example_2.Models;

namespace ASP.NET_CRUD_example_2.Controllers
{
    public class AsignaturaController : Controller
    {
        private readonly PostgreSqlContext _context;

        public AsignaturaController(PostgreSqlContext context)
        {
            _context = context;
        }

        // GET: Asignatura
        public async Task<IActionResult> Index()
        {
              return View(await _context.Asignaturas.ToListAsync());
        }

        // GET: Asignatura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asignaturas == null)
            {
                return NotFound();
            }

            var asignaturaDTO = await _context.Asignaturas
                .FirstOrDefaultAsync(m => m.Asignatura_id == id);
            if (asignaturaDTO == null)
            {
                return NotFound();
            }

            return View(asignaturaDTO);
        }

        // GET: Asignatura/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asignatura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Asignatura_id,Asignatura_nombre")] AsignaturaDTO asignaturaDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturaDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asignaturaDTO);
        }

        // GET: Asignatura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asignaturas == null)
            {
                return NotFound();
            }

            var asignaturaDTO = await _context.Asignaturas.FindAsync(id);
            if (asignaturaDTO == null)
            {
                return NotFound();
            }
            return View(asignaturaDTO);
        }

        // POST: Asignatura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Asignatura_id,Asignatura_nombre")] AsignaturaDTO asignaturaDTO)
        {
            if (id != asignaturaDTO.Asignatura_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturaDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturaDTOExists(asignaturaDTO.Asignatura_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(asignaturaDTO);
        }

        // GET: Asignatura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asignaturas == null)
            {
                return NotFound();
            }

            var asignaturaDTO = await _context.Asignaturas
                .FirstOrDefaultAsync(m => m.Asignatura_id == id);
            if (asignaturaDTO == null)
            {
                return NotFound();
            }

            return View(asignaturaDTO);
        }

        // POST: Asignatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asignaturas == null)
            {
                return Problem("Entity set 'PostgreSqlContext.Asignaturas'  is null.");
            }
            var asignaturaDTO = await _context.Asignaturas.FindAsync(id);
            if (asignaturaDTO != null)
            {
                _context.Asignaturas.Remove(asignaturaDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturaDTOExists(int id)
        {
          return _context.Asignaturas.Any(e => e.Asignatura_id == id);
        }
    }
}
