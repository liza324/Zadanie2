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
    public class DairtyProductsController : Controller
    {
        private readonly MvcMovieContext _context;

        public DairtyProductsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: DairtyProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.DairtyProducts.ToListAsync());
        }

        // GET: DairtyProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dairtyProducts = await _context.DairtyProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dairtyProducts == null)
            {
                return NotFound();
            }

            return View(dairtyProducts);
        }

        // GET: DairtyProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DairtyProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeOfProduct,ExpiryDate,Weight,Fat,Price")] DairtyProducts dairtyProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dairtyProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dairtyProducts);
        }

        // GET: DairtyProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dairtyProducts = await _context.DairtyProducts.FindAsync(id);
            if (dairtyProducts == null)
            {
                return NotFound();
            }
            return View(dairtyProducts);
        }

        // POST: DairtyProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeOfProduct,ExpiryDate,Weight,Fat,Price")] DairtyProducts dairtyProducts)
        {
            if (id != dairtyProducts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dairtyProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DairtyProductsExists(dairtyProducts.Id))
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
            return View(dairtyProducts);
        }

        // GET: DairtyProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dairtyProducts = await _context.DairtyProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dairtyProducts == null)
            {
                return NotFound();
            }

            return View(dairtyProducts);
        }

        // POST: DairtyProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dairtyProducts = await _context.DairtyProducts.FindAsync(id);
            _context.DairtyProducts.Remove(dairtyProducts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DairtyProductsExists(int id)
        {
            return _context.DairtyProducts.Any(e => e.Id == id);
        }
    }
}
