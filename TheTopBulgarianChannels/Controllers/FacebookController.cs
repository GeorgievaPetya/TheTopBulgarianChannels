using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTopBulgarianChannels.DataAccess;
using TheTopBulgarianChannels.DataModels;

namespace TheTopBulgarianChannels.Controllers
{
    public class FacebookController : Controller
    {
        private readonly AppDbContext _context;

        public FacebookController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Facebook
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facebook.ToListAsync());
        }

        // GET: Facebook/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facebook = await _context.Facebook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facebook == null)
            {
                return NotFound();
            }

            return View(facebook);
        }

        // GET: Facebook/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facebook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Followers")] Facebook facebook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facebook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facebook);
        }

        // GET: Facebook/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facebook = await _context.Facebook.FindAsync(id);
            if (facebook == null)
            {
                return NotFound();
            }
            return View(facebook);
        }

        // POST: Facebook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Followers")] Facebook facebook)
        {
            if (id != facebook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facebook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacebookExists(facebook.Id))
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
            return View(facebook);
        }

        // GET: Facebook/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facebook = await _context.Facebook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facebook == null)
            {
                return NotFound();
            }

            return View(facebook);
        }

        // POST: Facebook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facebook = await _context.Facebook.FindAsync(id);
            _context.Facebook.Remove(facebook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacebookExists(int id)
        {
            return _context.Facebook.Any(e => e.Id == id);
        }
    }
}
