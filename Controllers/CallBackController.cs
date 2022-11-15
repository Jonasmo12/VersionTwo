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
    public class CallBackController : Controller
    {
        private readonly CallBackContext _context;

        public CallBackController(CallBackContext context)
        {
            _context = context;
        }

        // GET: CallBack
        public async Task<IActionResult> Index()
        {
              return _context.CallBacks != null ? 
                          View(await _context.CallBacks.ToListAsync()) :
                          Problem("Entity set 'CallBackContext.CallBacks'  is null.");
        }

        // GET: CallBack/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CallBacks == null)
            {
                return NotFound();
            }

            var callBack = await _context.CallBacks
                .FirstOrDefaultAsync(m => m.id == id);
            if (callBack == null)
            {
                return NotFound();
            }

            return View(callBack);
        }

        // GET: CallBack/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CallBack/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FullName,EmailAddress,Phone,CallBackDate")] CallBack callBack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(callBack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Success));
            }
            return View(callBack);
        }

        // GET: CallBack/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CallBacks == null)
            {
                return NotFound();
            }

            var callBack = await _context.CallBacks.FindAsync(id);
            if (callBack == null)
            {
                return NotFound();
            }
            return View(callBack);
        }

        // POST: CallBack/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FullName,EmailAddress,Phone,CallBackDate")] CallBack callBack)
        {
            if (id != callBack.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(callBack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CallBackExists(callBack.id))
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
            return View(callBack);
        }

        // GET: CallBack/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CallBacks == null)
            {
                return NotFound();
            }

            var callBack = await _context.CallBacks
                .FirstOrDefaultAsync(m => m.id == id);
            if (callBack == null)
            {
                return NotFound();
            }

            return View(callBack);
        }

        // POST: CallBack/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CallBacks == null)
            {
                return Problem("Entity set 'CallBackContext.CallBacks'  is null.");
            }
            var callBack = await _context.CallBacks.FindAsync(id);
            if (callBack != null)
            {
                _context.CallBacks.Remove(callBack);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CallBackExists(int id)
        {
          return (_context.CallBacks?.Any(e => e.id == id)).GetValueOrDefault();
        }

        public IActionResult Success()
    {
        return View();
    }
    }
}
