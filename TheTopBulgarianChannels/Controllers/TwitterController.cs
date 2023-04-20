

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
    public class TwitterController : Controller
    {
        private readonly AppDbContext _context;

        public TwitterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Twitter
        public async Task<IActionResult> Index()
        {
            return View(await _context.Twitter.ToListAsync());
        }

        // GET: Twitter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var twitter = await _context.Twitter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (twitter == null)
            {
                return NotFound();
            }

            return View(twitter);
        }

        // GET: Twitter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Twitter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Owner,Followers")] Twitter twitter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(twitter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(twitter);
        }

        // GET: Twitter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var twitter = await _context.Twitter.FindAsync(id);
            if (twitter == null)
            {
                return NotFound();
            }
            return View(twitter);
        }

        // POST: Twitter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Owner,Followers")] Twitter twitter)
        {
            if (id != twitter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(twitter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TwitterExists(twitter.Id))
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
            return View(twitter);
        }

        // GET: Twitter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var twitter = await _context.Twitter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (twitter == null)
            {
                return NotFound();
            }

            return View(twitter);
        }

        // POST: Twitter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var twitter = await _context.Twitter.FindAsync(id);
            _context.Twitter.Remove(twitter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TwitterExists(int id)
        {
            return _context.Twitter.Any(e => e.Id == id);
        }
    }
}
