using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTopBulgarianChannels.DataAccess;
using TheTopBulgarianChannels.DataModels;
using TheTopBulgarianChannels.Service;

namespace TheTopBulgarianChannels.Controllers
{
    public class YouTubeChannelsController : Controller
    {
        private readonly AppDbContext _context; 
        public YouTubeChannelsController(AppDbContext context)
        {
           _context = context;
        }
   
        // GET: YouTubeChannels
        public async Task<IActionResult> Index(int sortOrder)
        {
            
            return View(await _context.YouTubeChannels.OrderByDescending(y => y.Subscribers).ToListAsync());
        }

        // GET: YouTubeChannels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var youTubeChannel = await _context.YouTubeChannels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (youTubeChannel == null)
            {
                return NotFound();
            }

            return View(youTubeChannel);
        }

        // GET: YouTubeChannels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YouTubeChannels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChannelName,ChannelHandle,ChannelId,Subscribers,Views,Videos,ChannelUrl")] YouTubeChannel youTubeChannel)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(youTubeChannel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(youTubeChannel);
        }

        // GET: YouTubeChannels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var youTubeChannel = await _context.YouTubeChannels.FindAsync(id);
            if (youTubeChannel == null)
            {
                return NotFound();
            }
            return View(youTubeChannel);
        }

        // POST: YouTubeChannels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChannelName,ChannelHandle,ChannelId,Subscribers,Views,Videos,ChannelUrl")] YouTubeChannel youTubeChannel)
        {
            if (id != youTubeChannel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(youTubeChannel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YouTubeChannelExists(youTubeChannel.Id))
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
            return View(youTubeChannel);
        }

        // GET: YouTubeChannels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var youTubeChannel = await _context.YouTubeChannels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (youTubeChannel == null)
            {
                return NotFound();
            }

            return View(youTubeChannel);
        }

        // POST: YouTubeChannels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var youTubeChannel = await _context.YouTubeChannels.FindAsync(id);
            _context.YouTubeChannels.Remove(youTubeChannel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YouTubeChannelExists(int id)
        {
            return _context.YouTubeChannels.Any(e => e.Id == id);
        }
    }
}
