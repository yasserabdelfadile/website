using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class thecatogryController : Controller
    {
        private readonly dbcontext _context;

        public thecatogryController(dbcontext context)
        {
            _context = context;
        }

        // GET: thecatogry
        public async Task<IActionResult> Index()
        {
            return View(await _context.Thecatogry.ToListAsync());
        }

        // GET: thecatogry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thecatogry = await _context.Thecatogry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thecatogry == null)
            {
                return NotFound();
            }

            return View(thecatogry);
        }

        // GET: thecatogry/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: thecatogry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,discraption")] thecatogry thecatogry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thecatogry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thecatogry);
        }

        // GET: thecatogry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thecatogry = await _context.Thecatogry.FindAsync(id);
            if (thecatogry == null)
            {
                return NotFound();
            }
            return View(thecatogry);
        }

        // POST: thecatogry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,discraption")] thecatogry thecatogry)
        {
            if (id != thecatogry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thecatogry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!thecatogryExists(thecatogry.Id))
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
            return View(thecatogry);
        }

        // GET: thecatogry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thecatogry = await _context.Thecatogry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thecatogry == null)
            {
                return NotFound();
            }

            return View(thecatogry);
        }

        // POST: thecatogry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thecatogry = await _context.Thecatogry.FindAsync(id);
            _context.Thecatogry.Remove(thecatogry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool thecatogryExists(int id)
        {
            return _context.Thecatogry.Any(e => e.Id == id);
        }
    }
}
