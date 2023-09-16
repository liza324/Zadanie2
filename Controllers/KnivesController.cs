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
    public class KnivesController : Controller
    {
        private readonly MvcMovieContext _context;

        public KnivesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Knives
        public async Task<IActionResult> Index()
        {
            return View(await _context.Knives.ToListAsync());
        }

        // GET: Knives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knives = await _context.Knives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knives == null)
            {
                return NotFound();
            }

            return View(knives);
        }

        // GET: Knives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Knives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,BladeLength,Weight,BladeType,HandleMaterial,DegreeOfSeverity")] Knives knives)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knives);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(knives);
        }

        // GET: Knives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knives = await _context.Knives.FindAsync(id);
            if (knives == null)
            {
                return NotFound();
            }
            return View(knives);
        }

        // POST: Knives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,BladeLength,Weight,BladeType,HandleMaterial,DegreeOfSeverity")] Knives knives)
        {
            if (id != knives.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knives);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnivesExists(knives.Id))
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
            return View(knives);
        }

        // GET: Knives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knives = await _context.Knives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knives == null)
            {
                return NotFound();
            }

            return View(knives);
        }

        // POST: Knives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var knives = await _context.Knives.FindAsync(id);
            _context.Knives.Remove(knives);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnivesExists(int id)
        {
            return _context.Knives.Any(e => e.Id == id);
        }
    }
}
