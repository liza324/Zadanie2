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
    public class AlcoholsController : Controller
    {
        private readonly MvcMovieContext _context;

        public AlcoholsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Alcohols
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alcohols.ToListAsync());
        }

        // GET: Alcohols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcohols = await _context.Alcohols
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alcohols == null)
            {
                return NotFound();
            }

            return View(alcohols);
        }

        // GET: Alcohols/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alcohols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeOfAlcohol,Volume,PercentageOfAlcoholContent,AmountOfSugar,Price,YearOfManufacture")] Alcohols alcohols)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alcohols);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alcohols);
        }

        // GET: Alcohols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcohols = await _context.Alcohols.FindAsync(id);
            if (alcohols == null)
            {
                return NotFound();
            }
            return View(alcohols);
        }

        // POST: Alcohols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeOfAlcohol,Volume,PercentageOfAlcoholContent,AmountOfSugar,Price,YearOfManufacture")] Alcohols alcohols)
        {
            if (id != alcohols.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alcohols);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlcoholsExists(alcohols.Id))
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
            return View(alcohols);
        }

        // GET: Alcohols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcohols = await _context.Alcohols
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alcohols == null)
            {
                return NotFound();
            }

            return View(alcohols);
        }

        // POST: Alcohols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alcohols = await _context.Alcohols.FindAsync(id);
            _context.Alcohols.Remove(alcohols);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlcoholsExists(int id)
        {
            return _context.Alcohols.Any(e => e.Id == id);
        }
    }
}
