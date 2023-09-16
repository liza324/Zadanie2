using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedProgramming_Lesson1.Data;
using AdvancedProgramming_Lesson1.Models;

namespace AdvancedProgramming_Lesson1.Controllers
{
    public class PotsController : Controller
    {
        private readonly MvcMovieContext _context;

        public PotsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Pots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pots.ToListAsync());
        }

        // GET: Pots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pots = await _context.Pots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pots == null)
            {
                return NotFound();
            }

            return View(pots);
        }

        // GET: Pots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Capacity,Weight,LidType,NumberOfHandles,Material")] Pots pots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pots);
        }

        // GET: Pots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pots = await _context.Pots.FindAsync(id);
            if (pots == null)
            {
                return NotFound();
            }
            return View(pots);
        }

        // POST: Pots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Capacity,Weight,LidType,NumberOfHandles,Material")] Pots pots)
        {
            if (id != pots.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PotsExists(pots.Id))
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
            return View(pots);
        }

        // GET: Pots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pots = await _context.Pots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pots == null)
            {
                return NotFound();
            }

            return View(pots);
        }

        // POST: Pots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pots = await _context.Pots.FindAsync(id);
            _context.Pots.Remove(pots);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PotsExists(int id)
        {
            return _context.Pots.Any(e => e.Id == id);
        }
    }
}
