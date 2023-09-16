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
    public class AuthorsBooksController : Controller
    {
        private readonly MvcMovieContext _context;

        public AuthorsBooksController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: AuthorsBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.AuthorsBooks.ToListAsync());
        }

        // GET: AuthorsBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorsBooks = await _context.AuthorsBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorsBooks == null)
            {
                return NotFound();
            }

            return View(authorsBooks);
        }

        // GET: AuthorsBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthorsBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookTitle,YearOfPublication,LiteraryGenre,PageCount,Price")] AuthorsBooks authorsBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorsBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authorsBooks);
        }

        // GET: AuthorsBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorsBooks = await _context.AuthorsBooks.FindAsync(id);
            if (authorsBooks == null)
            {
                return NotFound();
            }
            return View(authorsBooks);
        }

        // POST: AuthorsBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookTitle,YearOfPublication,LiteraryGenre,PageCount,Price")] AuthorsBooks authorsBooks)
        {
            if (id != authorsBooks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorsBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorsBooksExists(authorsBooks.Id))
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
            return View(authorsBooks);
        }

        // GET: AuthorsBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorsBooks = await _context.AuthorsBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorsBooks == null)
            {
                return NotFound();
            }

            return View(authorsBooks);
        }

        // POST: AuthorsBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorsBooks = await _context.AuthorsBooks.FindAsync(id);
            _context.AuthorsBooks.Remove(authorsBooks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorsBooksExists(int id)
        {
            return _context.AuthorsBooks.Any(e => e.Id == id);
        }
    }
}
