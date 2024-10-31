using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommAI.Data;
using CommAI.Models;

namespace CommAI.Controllers
{
    public class CommercialScriptEnhancedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommercialScriptEnhancedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CommercialScriptEnhanceds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CommercialScriptEnhanced.Include(c => c.CommercialScript).Include(c => c.CommercialScriptInsights);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CommercialScriptEnhanceds/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialScriptEnhanced = await _context.CommercialScriptEnhanced
                .Include(c => c.CommercialScript)
                .Include(c => c.CommercialScriptInsights)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commercialScriptEnhanced == null)
            {
                return NotFound();
            }

            return View(commercialScriptEnhanced);
        }

        // GET: CommercialScriptEnhanceds/Create
        public IActionResult Create()
        {
            ViewData["CommercialScriptId"] = new SelectList(_context.CommercialScript, "Id", "Id");
            ViewData["CommercialScriptInsightsId"] = new SelectList(_context.CommercialScriptInsights, "Id", "AgeGroup");
            return View();
        }

        // POST: CommercialScriptEnhanceds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OriginalScript,AdvertisingIdea,EnhancedScript,EnhancedScriptTagLine,Improvements,KeyMessagesOfEnhancedScript,NewsCreativeContentBasedNews,CommercialScriptInsightsId,CommercialScriptId")] CommercialScriptEnhanced commercialScriptEnhanced)
        {
            if (ModelState.IsValid)
            {
                commercialScriptEnhanced.Id = Guid.NewGuid();
                _context.Add(commercialScriptEnhanced);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommercialScriptId"] = new SelectList(_context.CommercialScript, "Id", "Id", commercialScriptEnhanced.CommercialScriptId);
            ViewData["CommercialScriptInsightsId"] = new SelectList(_context.CommercialScriptInsights, "Id", "AgeGroup", commercialScriptEnhanced.CommercialScriptInsightsId);
            return View(commercialScriptEnhanced);
        }

        // GET: CommercialScriptEnhanceds/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialScriptEnhanced = await _context.CommercialScriptEnhanced.FindAsync(id);
            if (commercialScriptEnhanced == null)
            {
                return NotFound();
            }
            ViewData["CommercialScriptId"] = new SelectList(_context.CommercialScript, "Id", "Id", commercialScriptEnhanced.CommercialScriptId);
            ViewData["CommercialScriptInsightsId"] = new SelectList(_context.CommercialScriptInsights, "Id", "AgeGroup", commercialScriptEnhanced.CommercialScriptInsightsId);
            return View(commercialScriptEnhanced);
        }

        // POST: CommercialScriptEnhanceds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,OriginalScript,AdvertisingIdea,EnhancedScript,EnhancedScriptTagLine,Improvements,KeyMessagesOfEnhancedScript,NewsCreativeContentBasedNews,CommercialScriptInsightsId,CommercialScriptId")] CommercialScriptEnhanced commercialScriptEnhanced)
        {
            if (id != commercialScriptEnhanced.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commercialScriptEnhanced);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommercialScriptEnhancedExists(commercialScriptEnhanced.Id))
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
            ViewData["CommercialScriptId"] = new SelectList(_context.CommercialScript, "Id", "Id", commercialScriptEnhanced.CommercialScriptId);
            ViewData["CommercialScriptInsightsId"] = new SelectList(_context.CommercialScriptInsights, "Id", "AgeGroup", commercialScriptEnhanced.CommercialScriptInsightsId);
            return View(commercialScriptEnhanced);
        }

        // GET: CommercialScriptEnhanceds/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialScriptEnhanced = await _context.CommercialScriptEnhanced
                .Include(c => c.CommercialScript)
                .Include(c => c.CommercialScriptInsights)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commercialScriptEnhanced == null)
            {
                return NotFound();
            }

            return View(commercialScriptEnhanced);
        }

        // POST: CommercialScriptEnhanceds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var commercialScriptEnhanced = await _context.CommercialScriptEnhanced.FindAsync(id);
            if (commercialScriptEnhanced != null)
            {
                _context.CommercialScriptEnhanced.Remove(commercialScriptEnhanced);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommercialScriptEnhancedExists(Guid id)
        {
            return _context.CommercialScriptEnhanced.Any(e => e.Id == id);
        }
    }
}
