using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRadio.Data;
using MyRadio.Models;

namespace MyRadio.Controllers
{
    public class RadiosController : Controller
    {
        private readonly MyRadioContext _context;

        public RadiosController(MyRadioContext context)
        {
            _context = context;
        }

        // GET: Radios
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Radio == null)
            {
                return Problem("Entity set 'MyRadioContext.Radio'  is null.");
            }

            var Radios = from m in _context.Radio
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Radios = Radios.Where(s => s.Title!.Contains(searchString));
            }

            return View(await Radios.ToListAsync());
        }

        // GET: Radios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radio = await _context.Radio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (radio == null)
            {
                return NotFound();
            }

            return View(radio);
        }

        // GET: Radios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Radios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,TypeOfRadio,Price")] Radio radio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(radio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(radio);
        }

        // GET: Radios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radio = await _context.Radio.FindAsync(id);
            if (radio == null)
            {
                return NotFound();
            }
            return View(radio);
        }

        // POST: Radios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,TypeOfRadio,Price")] Radio radio)
        {
            if (id != radio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(radio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RadioExists(radio.Id))
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
            return View(radio);
        }

        // GET: Radios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radio = await _context.Radio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (radio == null)
            {
                return NotFound();
            }

            return View(radio);
        }

        // POST: Radios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var radio = await _context.Radio.FindAsync(id);
            if (radio != null)
            {
                _context.Radio.Remove(radio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RadioExists(int id)
        {
            return _context.Radio.Any(e => e.Id == id);
        }
    }
}
