namespace TheTopBulgarianChannels.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using TheTopBulgarianChannels.DataAccess;
    using TheTopBulgarianChannels.DataModels;
    using TheTopBulgarianChannels.Models;
    using TheTopBulgarianChannels.Service;

    public class InstagramController : Controller
    {
        private readonly AppDbContext _context;

        public InstagramController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Instagram
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instagram.OrderByDescending(y => y.Followers).ToListAsync());
        }

        // GET: Instagram/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instagram = await _context.Instagram
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instagram == null)
            {
                return NotFound();
            }

            return View(instagram);
        }

        // GET: Instagram/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instagram/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Followers,Posts")] Instagram instagram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instagram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instagram);
        }

        // GET: Instagram/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instagram = await _context.Instagram.FindAsync(id);
            if (instagram == null)
            {
                return NotFound();
            }
            return View(instagram);
        }

        // POST: Instagram/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Followers,Posts")] Instagram instagram)
        {
            if (id != instagram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instagram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstagramExists(instagram.Id))
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
            return View(instagram);
        }

        // GET: Instagram/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instagram = await _context.Instagram
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instagram == null)
            {
                return NotFound();
            }

            return View(instagram);
        }

        // POST: Instagram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instagram = await _context.Instagram.FindAsync(id);
            _context.Instagram.Remove(instagram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstagramExists(int id)
        {
            return _context.Instagram.Any(e => e.Id == id);
        }
    }
}
