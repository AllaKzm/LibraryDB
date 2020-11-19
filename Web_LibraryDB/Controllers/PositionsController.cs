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
    public class PositionsController : Controller
    {
        private readonly LibraryContext _context;

        public PositionsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Positions.ToListAsync());
        }

        // GET: Positions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positions = await _context.Positions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (positions == null)
            {
                return NotFound();
            }

            return View(positions);
        }

        // GET: Positions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PositionTitle,Salary,Duties,Demands")] Positions positions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(positions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(positions);
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positions = await _context.Positions.FindAsync(id);
            if (positions == null)
            {
                return NotFound();
            }
            return View(positions);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PositionTitle,Salary,Duties,Demands")] Positions positions)
        {
            if (id != positions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(positions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionsExists(positions.Id))
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
            return View(positions);
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positions = await _context.Positions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (positions == null)
            {
                return NotFound();
            }

            return View(positions);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var positions = await _context.Positions.FindAsync(id);
            _context.Positions.Remove(positions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionsExists(long id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }
    }
}
