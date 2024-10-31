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
    public class CommercialScriptSuggestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommercialScriptSuggestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CommercialScriptSuggestions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CommercialScriptSuggestion.Include(c => c.CommercialScript).Include(c => c.CommercialScriptInsights);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CommercialScriptSuggestions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialScriptSuggestion = await _context.CommercialScriptSuggestion
                .Include(c => c.CommercialScript)
                .Include(c => c.CommercialScriptInsights)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commercialScriptSuggestion == null)
            {
                return NotFound();
            }

            return View(commercialScriptSuggestion);
        }

        // GET: CommercialScriptSuggestions/Create
        public IActionResult Create()
        {
            ViewData["CommercialScriptId"] = new SelectList(_context.CommercialScript, "Id", "Id");
            ViewData["CommercialScriptInsightsId"] = new SelectList(_context.CommercialScriptInsights, "Id", "AgeGroup");
            return View();
        }

        // POST: CommercialScriptSuggestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OriginalScript,NumberOfWeakPoints,WeakPoints,SuggestionsCount,Suggestions,CommercialScriptInsightsId,CommercialScriptId")] CommercialScriptSuggestion commercialScriptSuggestion)
        {
            if (ModelState.IsValid)
            {
                commercialScriptSuggestion.Id = Guid.NewGuid();
                _context.Add(commercialScriptSuggestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommercialScriptId"] = new SelectList(_context.CommercialScript, "Id", "Id", commercialScriptSuggestion.CommercialScriptId);
            ViewData["CommercialScriptInsightsId"] = new SelectList(_context.CommercialScriptInsights, "Id", "AgeGroup", commercialScriptSuggestion.CommercialScriptInsightsId);
            return View(commercialScriptSuggestion);
        }

        // GET: CommercialScriptSuggestions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialScriptSuggestion = await _context.CommercialScriptSuggestion.FindAsync(id);
            if (commercialScriptSuggestion == null)
            {
                return NotFound();
            }
            ViewData["CommercialScriptId"] = new SelectList(_context.CommercialScript, "Id", "Id", commercialScriptSuggestion.CommercialScriptId);
            ViewData["CommercialScriptInsightsId"] = new SelectList(_context.CommercialScriptInsights, "Id", "AgeGroup", commercialScriptSuggestion.CommercialScriptInsightsId);
            return View(commercialScriptSuggestion);
        }

        // POST: CommercialScriptSuggestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,OriginalScript,NumberOfWeakPoints,WeakPoints,SuggestionsCount,Suggestions,CommercialScriptInsightsId,CommercialScriptId")] CommercialScriptSuggestion commercialScriptSuggestion)
        {
            if (id != commercialScriptSuggestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commercialScriptSuggestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommercialScriptSuggestionExists(commercialScriptSuggestion.Id))
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
            ViewData["CommercialScriptId"] = new SelectList(_context.CommercialScript, "Id", "Id", commercialScriptSuggestion.CommercialScriptId);
            ViewData["CommercialScriptInsightsId"] = new SelectList(_context.CommercialScriptInsights, "Id", "AgeGroup", commercialScriptSuggestion.CommercialScriptInsightsId);
            return View(commercialScriptSuggestion);
        }

        // GET: CommercialScriptSuggestions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialScriptSuggestion = await _context.CommercialScriptSuggestion
                .Include(c => c.CommercialScript)
                .Include(c => c.CommercialScriptInsights)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commercialScriptSuggestion == null)
            {
                return NotFound();
            }

            return View(commercialScriptSuggestion);
        }

        // POST: CommercialScriptSuggestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var commercialScriptSuggestion = await _context.CommercialScriptSuggestion.FindAsync(id);
            if (commercialScriptSuggestion != null)
            {
                _context.CommercialScriptSuggestion.Remove(commercialScriptSuggestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommercialScriptSuggestionExists(Guid id)
        {
            return _context.CommercialScriptSuggestion.Any(e => e.Id == id);
        }
    }
}
