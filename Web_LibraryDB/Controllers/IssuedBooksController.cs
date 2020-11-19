using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryDB.Data;
using LibraryDB.Models;

namespace Web_libraryDB.Controllers
{
    public class IssuedBooksController : Controller
    {
        private readonly LibraryContext _context;

        public IssuedBooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: IssuedBooks
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.IssuedBooks.Include(i => i.Book).Include(i => i.Emp).Include(i => i.Read);
            return View(await libraryContext.ToListAsync());
        }

        // GET: IssuedBooks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuedBooks = await _context.IssuedBooks
                .Include(i => i.Book)
                .Include(i => i.Emp)
                .Include(i => i.Read)
                .FirstOrDefaultAsync(m => m.ReturnMark == id);
            if (issuedBooks == null)
            {
                return NotFound();
            }

            return View(issuedBooks);
        }

        // GET: IssuedBooks/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author");
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "Address");
            ViewData["ReadId"] = new SelectList(_context.Readers, "ReadId", "Address");
            return View();
        }

        // POST: IssuedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IssueDate,ReturnDate,ReturnMark,EmpId,ReadId,BookId")] IssuedBooks issuedBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issuedBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", issuedBooks.BookId);
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "Address", issuedBooks.EmpId);
            ViewData["ReadId"] = new SelectList(_context.Readers, "ReadId", "Address", issuedBooks.ReadId);
            return View(issuedBooks);
        }

        // GET: IssuedBooks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuedBooks = await _context.IssuedBooks.FindAsync(id);
            if (issuedBooks == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", issuedBooks.BookId);
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "Address", issuedBooks.EmpId);
            ViewData["ReadId"] = new SelectList(_context.Readers, "ReadId", "Address", issuedBooks.ReadId);
            return View(issuedBooks);
        }

        // POST: IssuedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IssueDate,ReturnDate,ReturnMark,EmpId,ReadId,BookId")] IssuedBooks issuedBooks)
        {
            if (id != issuedBooks.ReturnMark)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issuedBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssuedBooksExists(issuedBooks.ReturnMark))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", issuedBooks.BookId);
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "Address", issuedBooks.EmpId);
            ViewData["ReadId"] = new SelectList(_context.Readers, "ReadId", "Address", issuedBooks.ReadId);
            return View(issuedBooks);
        }

        // GET: IssuedBooks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuedBooks = await _context.IssuedBooks
                .Include(i => i.Book)
                .Include(i => i.Emp)
                .Include(i => i.Read)
                .FirstOrDefaultAsync(m => m.ReturnMark == id);
            if (issuedBooks == null)
            {
                return NotFound();
            }

            return View(issuedBooks);
        }

        // POST: IssuedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var issuedBooks = await _context.IssuedBooks.FindAsync(id);
            _context.IssuedBooks.Remove(issuedBooks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssuedBooksExists(string id)
        {
            return _context.IssuedBooks.Any(e => e.ReturnMark == id);
        }
    }
}
