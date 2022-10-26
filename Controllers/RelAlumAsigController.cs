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
    public class RelAlumAsigController : Controller
    {
        private readonly PostgreSqlContext _context;

        public RelAlumAsigController(PostgreSqlContext context)
        {
            _context = context;
        }

        // GET: RelAlumAsig
        public async Task<IActionResult> Index()
        {
            var postgreSqlContext = _context.RelAlumAsigs.Include(r => r.Alumno).Include(r => r.Asignatura);
            return View(await postgreSqlContext.ToListAsync());
        }

        // GET: RelAlumAsig/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RelAlumAsigs == null)
            {
                return NotFound();
            }

            var relAlumAsigDTO = await _context.RelAlumAsigs
                .Include(r => r.Alumno)
                .Include(r => r.Asignatura)
                .FirstOrDefaultAsync(m => m.RelAlumAsig_id == id);
            if (relAlumAsigDTO == null)
            {
                return NotFound();
            }

            return View(relAlumAsigDTO);
        }

        // GET: RelAlumAsig/Create
        public IActionResult Create()
        {
            ViewData["Alumno_id"] = new SelectList(_context.Alumnos, "Alumno_id", "Alumno_apellidos");
            ViewData["Asignatura_id"] = new SelectList(_context.Asignaturas, "Asignatura_id", "Asignatura_nombre");
            return View();
        }

        // POST: RelAlumAsig/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RelAlumAsig_id,Alumno_id,Asignatura_id")] RelAlumAsigDTO relAlumAsigDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relAlumAsigDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Alumno_id"] = new SelectList(_context.Alumnos, "Alumno_id", "Alumno_apellidos", relAlumAsigDTO.Alumno_id);
            ViewData["Asignatura_id"] = new SelectList(_context.Asignaturas, "Asignatura_id", "Asignatura_nombre", relAlumAsigDTO.Asignatura_id);
            return View(relAlumAsigDTO);
        }

        // GET: RelAlumAsig/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RelAlumAsigs == null)
            {
                return NotFound();
            }

            var relAlumAsigDTO = await _context.RelAlumAsigs.FindAsync(id);
            if (relAlumAsigDTO == null)
            {
                return NotFound();
            }
            ViewData["Alumno_id"] = new SelectList(_context.Alumnos, "Alumno_id", "Alumno_apellidos", relAlumAsigDTO.Alumno_id);
            ViewData["Asignatura_id"] = new SelectList(_context.Asignaturas, "Asignatura_id", "Asignatura_nombre", relAlumAsigDTO.Asignatura_id);
            return View(relAlumAsigDTO);
        }

        // POST: RelAlumAsig/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RelAlumAsig_id,Alumno_id,Asignatura_id")] RelAlumAsigDTO relAlumAsigDTO)
        {
            if (id != relAlumAsigDTO.RelAlumAsig_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relAlumAsigDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelAlumAsigDTOExists(relAlumAsigDTO.RelAlumAsig_id))
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
            ViewData["Alumno_id"] = new SelectList(_context.Alumnos, "Alumno_id", "Alumno_apellidos", relAlumAsigDTO.Alumno_id);
            ViewData["Asignatura_id"] = new SelectList(_context.Asignaturas, "Asignatura_id", "Asignatura_nombre", relAlumAsigDTO.Asignatura_id);
            return View(relAlumAsigDTO);
        }

        // GET: RelAlumAsig/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RelAlumAsigs == null)
            {
                return NotFound();
            }

            var relAlumAsigDTO = await _context.RelAlumAsigs
                .Include(r => r.Alumno)
                .Include(r => r.Asignatura)
                .FirstOrDefaultAsync(m => m.RelAlumAsig_id == id);
            if (relAlumAsigDTO == null)
            {
                return NotFound();
            }

            return View(relAlumAsigDTO);
        }

        // POST: RelAlumAsig/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RelAlumAsigs == null)
            {
                return Problem("Entity set 'PostgreSqlContext.RelAlumAsigs'  is null.");
            }
            var relAlumAsigDTO = await _context.RelAlumAsigs.FindAsync(id);
            if (relAlumAsigDTO != null)
            {
                _context.RelAlumAsigs.Remove(relAlumAsigDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelAlumAsigDTOExists(int id)
        {
          return _context.RelAlumAsigs.Any(e => e.RelAlumAsig_id == id);
        }
    }
}
