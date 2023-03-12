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
    public class TikTokController : Controller
    {
        private readonly AppDbContext _context;

        public TikTokController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TikTok
        public async Task<IActionResult> Index()
        {
            return View(await _context.TikTok.ToListAsync());
        }

        // GET: TikTok/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tikTok = await _context.TikTok
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tikTok == null)
            {
                return NotFound();
            }

            return View(tikTok);
        }

        // GET: TikTok/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TikTok/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Owner,Followers")] TikTok tikTok)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tikTok);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tikTok);
        }

        // GET: TikTok/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tikTok = await _context.TikTok.FindAsync(id);
            if (tikTok == null)
            {
                return NotFound();
            }
            return View(tikTok);
        }

        // POST: TikTok/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Owner,Followers")] TikTok tikTok)
        {
            if (id != tikTok.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tikTok);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TikTokExists(tikTok.Id))
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
            return View(tikTok);
        }

        // GET: TikTok/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tikTok = await _context.TikTok
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tikTok == null)
            {
                return NotFound();
            }

            return View(tikTok);
        }

        // POST: TikTok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tikTok = await _context.TikTok.FindAsync(id);
            _context.TikTok.Remove(tikTok);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TikTokExists(int id)
        {
            return _context.TikTok.Any(e => e.Id == id);
        }
    }
}
