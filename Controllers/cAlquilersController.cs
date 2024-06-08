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
    public class cAlquilersController : Controller
    {
        private readonly HotelJacjContext _context;

        public cAlquilersController(HotelJacjContext context)
        {
            _context = context;
        }

        // GET: cAlquilers
        public async Task<IActionResult> Index()
        {
              return _context.tAlquiler != null ? 
                          View(await _context.tAlquiler.ToListAsync()) :
                          Problem("Entity set 'HotelJacjContext.tAlquiler'  is null.");
        }

        // GET: cAlquilers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tAlquiler == null)
            {
                return NotFound();
            }

            var cAlquiler = await _context.tAlquiler
                .FirstOrDefaultAsync(m => m.idAlquiler == id);
            if (cAlquiler == null)
            {
                return NotFound();
            }

            return View(cAlquiler);
        }

        // GET: cAlquilers/Create
        public IActionResult Create()
        {
            ViewBag.Habitacion = new SelectList(_context.tHabitacion, "idHabitacion", "descripcion");
            ViewBag.Cliente = new SelectList(_context.tCliente, "idCliente", "nombre");
            ViewBag.Registrador = new SelectList(_context.tRegistrador, "idRegistrador", "nombre");
            ViewBag.Estado = new SelectList(_context.tEstado, "idEstado", "nombre");
            return View();

        }

        // POST: cAlquilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idAlquiler,fechaHoraEntrada,fechaHoraSalida,costoTotal,observacion,fkHabitacion,fkCliente,fkRegistrador,fkEstado")] cAlquiler cAlquiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cAlquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["fkHabitacion"] = new SelectList(_context.tHabitacion, "idHabitacion", "numero", cAlquiler.fkHabitacion);
            ViewData["fkCliente"] = new SelectList(_context.tCliente, "idCliente", "nombre", cAlquiler.fkCliente);
            ViewData["fkRegistrador"] = new SelectList(_context.tRegistrador, "idRegistrador", "nombre", cAlquiler.fkRegistrador);
            ViewData["fkEstado"] = new SelectList(_context.tEstado, "idEstado", "nombre", cAlquiler.fkEstado);
            return View(cAlquiler);
        }

        // GET: cAlquilers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tAlquiler == null)
            {
                return NotFound();
            }

            var cAlquiler = await _context.tAlquiler.FindAsync(id);
            if (cAlquiler == null)
            {
                return NotFound();
            }
            return View(cAlquiler);
        }

        // POST: cAlquilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idAlquiler,fechaHoraEntrada,fechaHoraSalida,costoTotal,observacion,fkHabitacion,fkCliente,fkRegistrador,fkEstado")] cAlquiler cAlquiler)
        {
            if (id != cAlquiler.idAlquiler)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cAlquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cAlquilerExists(cAlquiler.idAlquiler))
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
            return View(cAlquiler);
        }

        // GET: cAlquilers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tAlquiler == null)
            {
                return NotFound();
            }

            var cAlquiler = await _context.tAlquiler
                .FirstOrDefaultAsync(m => m.idAlquiler == id);
            if (cAlquiler == null)
            {
                return NotFound();
            }

            return View(cAlquiler);
        }

        // POST: cAlquilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tAlquiler == null)
            {
                return Problem("Entity set 'HotelJacjContext.tAlquiler'  is null.");
            }
            var cAlquiler = await _context.tAlquiler.FindAsync(id);
            if (cAlquiler != null)
            {
                _context.tAlquiler.Remove(cAlquiler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cAlquilerExists(int id)
        {
          return (_context.tAlquiler?.Any(e => e.idAlquiler == id)).GetValueOrDefault();
        }
    }
}
