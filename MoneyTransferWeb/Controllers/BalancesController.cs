using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyTransferWeb.Data;
using MoneyTransferWeb.Models;

namespace MoneyTransferWeb.Controllers
{
    public class BalancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BalancesController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        // GET: Balances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Balances.Include(b => b.Capitals).Include(b => b.Institution);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Balances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Balances == null)
            {
                return NotFound();
            }

            var balance = await _context.Balances
                .Include(b => b.Capitals)
                .Include(b => b.Institution)
                .FirstOrDefaultAsync(m => m.BalanceID == id);
            if (balance == null)
            {
                return NotFound();
            }

            return View(balance);
        }

        // GET: Balances/Create
        public IActionResult Create()
        {
            ViewData["CapitalID"] = new SelectList(_context.Capitals.OrderByDescending(c=>c.CapitalID), "CapitalID", "CapitalID");
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "INameEN");
            Balance balance = new Balance();
            return PartialView("_Create", balance);
           // return View(balance);
        }

        // POST: Balances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BalanceID,BAmountR,BAmountS,CapitalID,InstitutionID")] Balance balance)
        {
            var capital = await _context.Capitals.FirstOrDefaultAsync(c => c.isActive == true);
            if (ModelState.IsValid)
                {
                    _context.Add(balance);
                    await _context.SaveChangesAsync();
                    if(capital != null)
                    {
                        return RedirectToAction(nameof(Details),"Capitals", new { id = capital.CapitalID });
                    }
               // return RedirectToAction(nameof(Details), "Capitals", new { id = capital.CapitalID });
                return RedirectToAction(nameof(Index));
                //return PartialView("_List",balance);
            }
                ViewData["CapitalID"] = new SelectList( _context.Capitals.OrderByDescending(c => c.CapitalID), "CapitalID", "CapitalID");
                ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "INameEN", balance.InstitutionID);
                return View(balance);
           
        }

        // GET: Balances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Balances == null)
            {
                return NotFound();
            }

            var balance = await _context.Balances.FindAsync(id);
            if (balance == null)
            {
                return NotFound();
            }
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID", balance.CapitalID);
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "INameEN", balance.InstitutionID);
            return PartialView("_Edit", balance);
            //return View(balance);
        }

        // POST: Balances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BalanceID,BAmountR,BAmountS,CapitalID,InstitutionID")] Balance balance)
        {
            if (id != balance.BalanceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(balance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BalanceExists(balance.BalanceID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var capital = await _context.Capitals.FirstOrDefaultAsync(c => c.isActive == true);
                return RedirectToAction(nameof(Details), "Capitals", new { id = capital.CapitalID });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID", balance.CapitalID);
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "INameEN", balance.InstitutionID);            
            return View(balance);
        }

        // GET: Balances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Balances == null)
            {
                return NotFound();
            }

            var balance = await _context.Balances
                .Include(b => b.Capitals)
                .Include(b => b.Institution) 
                .FirstOrDefaultAsync(m => m.BalanceID == id);
            if (balance == null)
            {
                return NotFound();
            }
            /*var capital = await _context.Capitals.FirstOrDefaultAsync(c => c.isActive==true);
            return RedirectToAction(nameof(Details), "Capitals", new { id = capital.CapitalID });*/
            return PartialView("_Delete",balance);
        }

        // POST: Balances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Balances == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Balances'  is null.");
            }
            var balance = await _context.Balances.FindAsync(id);
            if (balance != null)
            {
                _context.Balances.Remove(balance);
            }
            
            await _context.SaveChangesAsync();
            var capital = await _context.Capitals.FirstOrDefaultAsync(c => c.isActive == true);
            return RedirectToAction(nameof(Details), "Capitals", new { id = capital.CapitalID });
            //return RedirectToAction(nameof(Index));
        }

        private bool BalanceExists(int id)
        {
          return (_context.Balances?.Any(e => e.BalanceID == id)).GetValueOrDefault();
        }
    }
}
