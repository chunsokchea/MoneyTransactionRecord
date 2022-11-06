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
    public class DebtsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DebtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Debts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Debts.Include(d => d.Transaction);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Debts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Debts == null)
            {
                return NotFound();
            }

            var debt = await _context.Debts
                .Include(d => d.Transaction)
                .FirstOrDefaultAsync(m => m.DebtID == id);
            if (debt == null)
            {
                return NotFound();
            }

            return View(debt);
        }

        // GET: Debts/Create
        public IActionResult Create()
        {
            ViewData["TransactionID"] = new SelectList(_context.Transactions, "TransactionID", "TransactionID");
            return View();
        }

        // POST: Debts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DebtID,DAmountR,DAmountS,DebtOwe,TransactionID")] Debt debt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(debt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TransactionID"] = new SelectList(_context.Transactions, "TransactionID", "TransactionID", debt.TransactionID);
            return View(debt);
        }

        // GET: Debts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Debts == null)
            {
                return NotFound();
            }

            var debt = await _context.Debts.FindAsync(id);
            if (debt == null)
            {
                return NotFound();
            }
            ViewData["TransactionID"] = new SelectList(_context.Transactions, "TransactionID", "TransactionID", debt.TransactionID);
            return View(debt);
        }

        // POST: Debts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DebtID,DAmountR,DAmountS,DebtOwe,TransactionID")] Debt debt)
        {
            if (id != debt.DebtID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(debt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DebtExists(debt.DebtID))
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
            ViewData["TransactionID"] = new SelectList(_context.Transactions, "TransactionID", "TransactionID", debt.TransactionID);
            return View(debt);
        }

        // GET: Debts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Debts == null)
            {
                return NotFound();
            }

            var debt = await _context.Debts
                .Include(d => d.Transaction)
                .FirstOrDefaultAsync(m => m.DebtID == id);
            if (debt == null)
            {
                return NotFound();
            }

            return View(debt);
        }

        // POST: Debts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Debts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Debts'  is null.");
            }
            var debt = await _context.Debts.FindAsync(id);
            if (debt != null)
            {
                _context.Debts.Remove(debt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DebtExists(int id)
        {
          return _context.Debts.Any(e => e.DebtID == id);
        }
    }
}
