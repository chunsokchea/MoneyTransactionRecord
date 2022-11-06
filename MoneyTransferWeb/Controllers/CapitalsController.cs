using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MoneyTransferWeb.Data;
using MoneyTransferWeb.Models;

namespace MoneyTransferWeb.Controllers
{
    public class CapitalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CapitalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Capitals
        public async Task<IActionResult> Index()
        {
              return _context.Capitals != null ? 
                          View(await _context.Capitals.OrderByDescending(c=>c.CapitalID).ToListAsync()) :   
                          Problem("Entity set 'ApplicationDbContext.Capitals'  is null.");
        }

        // GET: Capitals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Capitals == null)
            {
                return NotFound();
            }         
            var capital = await _context.Capitals
                .Include(c => c.Balances).ThenInclude(b=>b.Institution)
                .Include(c=>c.Withdraws)
                .FirstOrDefaultAsync(c => c.CapitalID == id);
            
            if (capital == null)
            {
                return NotFound();
            }            
            return View(capital);
        }

        // GET: Capitals/Create
        public async Task<IActionResult> Create()
        {
            var cinstitute = await _context.Institutions.ToListAsync();
            if (cinstitute.Count == 0)
            {
                return Redirect("/Institutions/create");
            }
            // var capital = await _context.Capitals.FirstOrDefaultAsync(c => c.CreatedDateTime.Date == DateTime.Now.Date);
            Capital capital = new Capital();
            for (var i = 0; i < cinstitute.Count; i++)
            {
                var id = cinstitute[i].InstitutionID;
                var name = cinstitute[i].INameKH;
                capital.Balances.Add(new Balance() { BalanceID = id, });
            }
            capital.Withdraws.Add(new Withdraw() { WithdrawID = 0, });
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "INameEN");
            ViewData["Ins"] = cinstitute.ToList();
           // return Json(ViewBag.Ins);
            return View(capital);
        }
        
        // POST: Capitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Capital capital)
        {            
           // return Json(capital);
            if (ModelState.IsValid)
            {
                var capitals =await _context.Capitals.ToListAsync();
                foreach (var c in capitals)
                {
                    c.isActive = false;
                    _context.Update(c);
                   await _context.SaveChangesAsync();
                }
                _context.Add(capital);
                await _context.SaveChangesAsync();
                
                //return Json(capital.CapitalID);
                return RedirectToAction(nameof(Details), new { id = capital.CapitalID });
            }
            var cinstitute = await _context.Institutions.ToListAsync();
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "INameEN");
           ViewData["Ins"] = cinstitute.ToList();
            return View(capital);
        }
       /* private IActionResult UpdateA()
        {
            var capitals =  _context.Capitals.ToList();
            foreach (var c in capitals)
            {
                c.isActive = false;
                _context.Update(c);
                 _context.SaveChangesAsync();
            }
            return Json(capitals);
        }*/
        // GET: Capitals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Capitals == null)
            {
                return NotFound();
            }

            var capital = await _context.Capitals.FindAsync(id);
            if (capital == null)
            {
                return NotFound();
            }
            return View(capital);
        }

        // POST: Capitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CapitalID,CAmountR,CAmountS,UAmountR,UAmountS,CreatedDateTime")] Capital capital)
        {
            if (id != capital.CapitalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapitalExists(capital.CapitalID))
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
            return View(capital);
        }

        // GET: Capitals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Capitals == null)
            {
                return NotFound();
            }

            var capital = await _context.Capitals
                .FirstOrDefaultAsync(m => m.CapitalID == id);
            if (capital == null)
            {
                return NotFound();
            }

            return View(capital);
        }

        // POST: Capitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Capitals == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Capitals'  is null.");
            }
            var capital = await _context.Capitals.FindAsync(id);
            if (capital != null)
            {
                _context.Capitals.Remove(capital);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapitalExists(int id)
        {
          return (_context.Capitals?.Any(e => e.CapitalID == id)).GetValueOrDefault();
        }
    }
}
