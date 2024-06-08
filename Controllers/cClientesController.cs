using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practicaV1.Context;
using practicaV1.Models;
using System.Linq;
using System.Threading.Tasks;

namespace practicaV1.Controllers
{
    public class cClientesController : Controller
    {
        private readonly HotelJacjContext _context;

        public cClientesController(HotelJacjContext context)
        {
            _context = context;
        }

        // GET: cClientes
        public async Task<IActionResult> Index()
        {
            return _context.tCliente != null ?
                        View(await _context.tCliente.ToListAsync()) :
                        Problem("Entity set 'HotelJacjContext.tCliente' is null.");
        }

        // GET: cClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tCliente == null)
            {
                return NotFound();
            }

            var cCliente = await _context.tCliente
                .FirstOrDefaultAsync(m => m.idCliente == id);
            if (cCliente == null)
            {
                return NotFound();
            }

            return View(cCliente);
        }

        // GET: cClientes/Create
        public IActionResult Create()
        {
            ViewBag.Nacionalidades = new SelectList(_context.tNacionalidad, "idNacionalidad", "nacionalidad");
            return View();
        }

        // POST: cClientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCliente,nombre,direccion,documento,telefono,fkNacionalidad")] cCliente cCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Nacionalidades = new SelectList(_context.tNacionalidad, "idNacionalidad", "nacionalidad", cCliente.fkNacionalidad);
            return View(cCliente);
        }

        // GET: cClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tCliente == null)
            {
                return NotFound();
            }

            var cCliente = await _context.tCliente.FindAsync(id);
            if (cCliente == null)
            {
                return NotFound();
            }
            ViewBag.Nacionalidades = new SelectList(_context.tNacionalidad, "idNacionalidad", "nacionalidad", cCliente.fkNacionalidad);
            return View(cCliente);
        }

        // POST: cClientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCliente,nombre,direccion,documento,telefono,fkNacionalidad")] cCliente cCliente)
        {
            if (id != cCliente.idCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cClienteExists(cCliente.idCliente))
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
            ViewBag.Nacionalidades = new SelectList(_context.tNacionalidad, "idNacionalidad", "nacionalidad", cCliente.fkNacionalidad);
            return View(cCliente);
        }

        // GET: cClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tCliente == null)
            {
                return NotFound();
            }

            var cCliente = await _context.tCliente
                .FirstOrDefaultAsync(m => m.idCliente == id);
            if (cCliente == null)
            {
                return NotFound();
            }

            return View(cCliente);
        }

        // POST: cClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tCliente == null)
            {
                return Problem("Entity set 'HotelJacjContext.tCliente' is null.");
            }
            var cCliente = await _context.tCliente.FindAsync(id);
            if (cCliente != null)
            {
                _context.tCliente.Remove(cCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cClienteExists(int id)
        {
            return (_context.tCliente?.Any(e => e.idCliente == id)).GetValueOrDefault();
        }
    }
}
