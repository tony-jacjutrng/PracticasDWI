using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practicaV1.Context;
using practicaV1.Models;

namespace practicaV1.Controllers
{
    public class cHabitacionsController : Controller
    {
        private readonly HotelJacjContext _context;

        public cHabitacionsController(HotelJacjContext context)
        {
            _context = context;
        }

        // GET: cHabitacions
        public async Task<IActionResult> Index()
        {
              return _context.tHabitacion != null ? 
                          View(await _context.tHabitacion.ToListAsync()) :
                          Problem("Entity set 'HotelJacjContext.tHabitacion'  is null.");
        }

        // GET: cHabitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tHabitacion == null)
            {
                return NotFound();
            }

            var cHabitacion = await _context.tHabitacion
                .FirstOrDefaultAsync(m => m.idHabitacion == id);
            if (cHabitacion == null)
            {
                return NotFound();
            }

            return View(cHabitacion);
        }

        // GET: cHabitacions/Create
        public IActionResult Create()

        {
            ViewBag.TiposHabitacion = new SelectList(_context.tTipoHabitacion, "idTipo", "nombre");//hace la lista con los datos 
            return View();
        }

        // POST: cHabitacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idHabitacion,numero,estado,costo,descripcion,fkTipo")] cHabitacion cHabitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cHabitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.TiposHabitacion = new SelectList(_context.tTipoHabitacion, "idTipo", "nombre", cHabitacion.fkTipo);//toma el valor de la lista y la manda al view bag
            return View(cHabitacion);
        }

        // GET: cHabitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tHabitacion == null)
            {
                return NotFound();
            }

            var cHabitacion = await _context.tHabitacion.FindAsync(id);
            if (cHabitacion == null)
            {
                return NotFound();
            }
            return View(cHabitacion);
        }

        // POST: cHabitacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idHabitacion,numero,estado,costo,descripcion,fkTipo")] cHabitacion cHabitacion)
        {
            if (id != cHabitacion.idHabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cHabitacionExists(cHabitacion.idHabitacion))
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
            return View(cHabitacion);
        }

        // GET: cHabitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tHabitacion == null)
            {
                return NotFound();
            }

            var cHabitacion = await _context.tHabitacion
                .FirstOrDefaultAsync(m => m.idHabitacion == id);
            if (cHabitacion == null)
            {
                return NotFound();
            }

            return View(cHabitacion);
        }

        // POST: cHabitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tHabitacion == null)
            {
                return Problem("Entity set 'HotelJacjContext.tHabitacion'  is null.");
            }
            var cHabitacion = await _context.tHabitacion.FindAsync(id);
            if (cHabitacion != null)
            {
                _context.tHabitacion.Remove(cHabitacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cHabitacionExists(int id)
        {
          return (_context.tHabitacion?.Any(e => e.idHabitacion == id)).GetValueOrDefault();
        }
    }
}
