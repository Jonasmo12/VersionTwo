using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VersionTwo.Data;
using VersionTwo.Models;

namespace VersionTwo.Controllers
{
    public class VlogController : Controller
    {
        private readonly CallBackContext _context;

        public VlogController(CallBackContext context)
        {
            _context = context;
        }

        // GET: Vlog
        public async Task<IActionResult> Index()
        {
              return _context.Vlogs != null ? 
                          View(await _context.Vlogs.ToListAsync()) :
                          Problem("Entity set 'CallBackContext.Vlogs'  is null.");
        }

        // GET: Vlog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vlogs == null)
            {
                return NotFound();
            }

            var vlog = await _context.Vlogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vlog == null)
            {
                return NotFound();
            }

            return View(vlog);
        }

        // GET: Vlog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vlog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VideoUrl,Title,Description")] Vlog vlog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vlog);
        }

        // GET: Vlog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vlogs == null)
            {
                return NotFound();
            }

            var vlog = await _context.Vlogs.FindAsync(id);
            if (vlog == null)
            {
                return NotFound();
            }
            return View(vlog);
        }

        // POST: Vlog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VideoUrl,Title,Description")] Vlog vlog)
        {
            if (id != vlog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VlogExists(vlog.Id))
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
            return View(vlog);
        }

        // GET: Vlog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vlogs == null)
            {
                return NotFound();
            }

            var vlog = await _context.Vlogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vlog == null)
            {
                return NotFound();
            }

            return View(vlog);
        }

        // POST: Vlog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vlogs == null)
            {
                return Problem("Entity set 'CallBackContext.Vlogs'  is null.");
            }
            var vlog = await _context.Vlogs.FindAsync(id);
            if (vlog != null)
            {
                _context.Vlogs.Remove(vlog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VlogExists(int id)
        {
          return (_context.Vlogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
