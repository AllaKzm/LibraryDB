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
    public class PublicistsController : Controller
    {
        private readonly LibraryContext _context;

        public PublicistsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Publicists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Publicist.ToListAsync());
        }

        // GET: Publicists/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicist = await _context.Publicist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicist == null)
            {
                return NotFound();
            }

            return View(publicist);
        }

        // GET: Publicists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publicists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PublicistTitle,City,Address")] Publicist publicist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publicist);
        }

        // GET: Publicists/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicist = await _context.Publicist.FindAsync(id);
            if (publicist == null)
            {
                return NotFound();
            }
            return View(publicist);
        }

        // POST: Publicists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PublicistTitle,City,Address")] Publicist publicist)
        {
            if (id != publicist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicistExists(publicist.Id))
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
            return View(publicist);
        }

        // GET: Publicists/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicist = await _context.Publicist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicist == null)
            {
                return NotFound();
            }

            return View(publicist);
        }

        // POST: Publicists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var publicist = await _context.Publicist.FindAsync(id);
            _context.Publicist.Remove(publicist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicistExists(long id)
        {
            return _context.Publicist.Any(e => e.Id == id);
        }
    }
}
