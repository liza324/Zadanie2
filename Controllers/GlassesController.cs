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
    public class GlassesController : Controller
    {
        private readonly MvcMovieContext _context;

        public GlassesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Glasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Glasses.ToListAsync());
        }

        // GET: Glasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glasses = await _context.Glasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (glasses == null)
            {
                return NotFound();
            }

            return View(glasses);
        }

        // GET: Glasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Glasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Capacity,Weight,Type,Color,MaterialOfManufacture")] Glasses glasses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(glasses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(glasses);
        }

        // GET: Glasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glasses = await _context.Glasses.FindAsync(id);
            if (glasses == null)
            {
                return NotFound();
            }
            return View(glasses);
        }

        // POST: Glasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Capacity,Weight,Type,Color,MaterialOfManufacture")] Glasses glasses)
        {
            if (id != glasses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(glasses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GlassesExists(glasses.Id))
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
            return View(glasses);
        }

        // GET: Glasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glasses = await _context.Glasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (glasses == null)
            {
                return NotFound();
            }

            return View(glasses);
        }

        // POST: Glasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var glasses = await _context.Glasses.FindAsync(id);
            _context.Glasses.Remove(glasses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GlassesExists(int id)
        {
            return _context.Glasses.Any(e => e.Id == id);
        }
    }
}
