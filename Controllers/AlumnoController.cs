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
    public class AlumnoController : Controller
    {
        private readonly PostgreSqlContext _context;

        public AlumnoController(PostgreSqlContext context)
        {
            _context = context;
        }

        // GET: Alumno
        public async Task<IActionResult> Index()
        {
              return View(await _context.Alumnos.ToListAsync());
        }

        // GET: Alumno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumnoDTO = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.Alumno_id == id);
            if (alumnoDTO == null)
            {
                return NotFound();
            }

            return View(alumnoDTO);
        }

        // GET: Alumno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alumno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Alumno_id,Alumno_nombre,Alumno_apellidos,Alumno_email")] AlumnoDTO alumnoDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnoDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumnoDTO);
        }

        // GET: Alumno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumnoDTO = await _context.Alumnos.FindAsync(id);
            if (alumnoDTO == null)
            {
                return NotFound();
            }
            return View(alumnoDTO);
        }

        // POST: Alumno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Alumno_id,Alumno_nombre,Alumno_apellidos,Alumno_email")] AlumnoDTO alumnoDTO)
        {
            if (id != alumnoDTO.Alumno_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnoDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoDTOExists(alumnoDTO.Alumno_id))
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
            return View(alumnoDTO);
        }

        // GET: Alumno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumnoDTO = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.Alumno_id == id);
            if (alumnoDTO == null)
            {
                return NotFound();
            }

            return View(alumnoDTO);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alumnos == null)
            {
                return Problem("Entity set 'PostgreSqlContext.Alumnos'  is null.");
            }
            var alumnoDTO = await _context.Alumnos.FindAsync(id);
            if (alumnoDTO != null)
            {
                _context.Alumnos.Remove(alumnoDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoDTOExists(int id)
        {
          return _context.Alumnos.Any(e => e.Alumno_id == id);
        }
    }
}
