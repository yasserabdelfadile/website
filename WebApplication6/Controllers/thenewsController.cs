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
    public class thenewsController : Controller
    {
        private readonly dbcontext _context;

        public thenewsController(dbcontext context)
        {
            _context = context;
        }

        // GET: thenews
        public async Task<IActionResult> Index()
        {
            return View(await _context.thenews.ToListAsync());
        }

        // GET: thenews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thenews = await _context.thenews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thenews == null)
            {
                return NotFound();
            }

            return View(thenews);
        }

        // GET: thenews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: thenews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,tital,Description,thedate,thecatogryId")] thenews thenews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thenews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thenews);
        }

        // GET: thenews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thenews = await _context.thenews.FindAsync(id);
            if (thenews == null)
            {
                return NotFound();
            }
            return View(thenews);
        }

        // POST: thenews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,tital,Description,thedate,thecatogryId")] thenews thenews)
        {
            if (id != thenews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thenews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!thenewsExists(thenews.Id))
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
            return View(thenews);
        }

        // GET: thenews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thenews = await _context.thenews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thenews == null)
            {
                return NotFound();
            }

            return View(thenews);
        }

        // POST: thenews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thenews = await _context.thenews.FindAsync(id);
            _context.thenews.Remove(thenews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool thenewsExists(int id)
        {
            return _context.thenews.Any(e => e.Id == id);
        }
    }
}
