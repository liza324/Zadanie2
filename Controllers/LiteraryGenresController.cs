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
    public class LiteraryGenresController : Controller
    {
        private readonly MvcMovieContext _context;

        public LiteraryGenresController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: LiteraryGenres
        public async Task<IActionResult> Index()
        {
            return View(await _context.LiteraryGenres.ToListAsync());
        }

        // GET: LiteraryGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var literaryGenres = await _context.LiteraryGenres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (literaryGenres == null)
            {
                return NotFound();
            }

            return View(literaryGenres);
        }

        // GET: LiteraryGenres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LiteraryGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GenreName,DateOfOriginOfTheGenre,TheMainMotifsInTheGenre,PopularityOfTheGenre,TheNumberOfBooksInAGivenGenre")] LiteraryGenres literaryGenres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(literaryGenres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(literaryGenres);
        }

        // GET: LiteraryGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var literaryGenres = await _context.LiteraryGenres.FindAsync(id);
            if (literaryGenres == null)
            {
                return NotFound();
            }
            return View(literaryGenres);
        }

        // POST: LiteraryGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GenreName,DateOfOriginOfTheGenre,TheMainMotifsInTheGenre,PopularityOfTheGenre,TheNumberOfBooksInAGivenGenre")] LiteraryGenres literaryGenres)
        {
            if (id != literaryGenres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(literaryGenres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiteraryGenresExists(literaryGenres.Id))
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
            return View(literaryGenres);
        }

        // GET: LiteraryGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var literaryGenres = await _context.LiteraryGenres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (literaryGenres == null)
            {
                return NotFound();
            }

            return View(literaryGenres);
        }

        // POST: LiteraryGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var literaryGenres = await _context.LiteraryGenres.FindAsync(id);
            _context.LiteraryGenres.Remove(literaryGenres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiteraryGenresExists(int id)
        {
            return _context.LiteraryGenres.Any(e => e.Id == id);
        }
    }
}
