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
    public class ReturnsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReturnsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Returns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Returns.Include(r => r.Transaction);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Returns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Returns == null)
            {
                return NotFound();
            }

            var returnTransaction = await _context.Returns
                .Include(r => r.Transaction)
                .FirstOrDefaultAsync(m => m.ReturnID == id);
            if (returnTransaction == null)
            {
                return NotFound();
            }

            return View(returnTransaction);
        }

        // GET: Returns/Create
        public IActionResult Create()
        {
            ViewData["TransactionID"] = new SelectList(_context.Transactions, "TransactionID", "TransactionID");
            return View();
        }

        // POST: Returns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnID,RAmountR,RAmountS,Paid,ReturnDate,TransactionID")] ReturnTransaction returnTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(returnTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TransactionID"] = new SelectList(_context.Transactions, "TransactionID", "TransactionID", returnTransaction.TransactionID);
            return View(returnTransaction);
        }

        // GET: Returns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Returns == null)
            {
                return NotFound();
            }

            var returnTransaction = await _context.Returns.FindAsync(id);
            if (returnTransaction == null)
            {
                return NotFound();
            }
            ViewData["TransactionID"] = new SelectList(_context.Transactions, "TransactionID", "TransactionID", returnTransaction.TransactionID);
            return View(returnTransaction);
        }

        // POST: Returns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnID,RAmountR,RAmountS,Paid,ReturnDate,TransactionID")] ReturnTransaction returnTransaction)
        {
            if (id != returnTransaction.ReturnID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returnTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnTransactionExists(returnTransaction.ReturnID))
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
            ViewData["TransactionID"] = new SelectList(_context.Transactions, "TransactionID", "TransactionID", returnTransaction.TransactionID);
            return View(returnTransaction);
        }

        // GET: Returns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Returns == null)
            {
                return NotFound();
            }

            var returnTransaction = await _context.Returns
                .Include(r => r.Transaction)
                .FirstOrDefaultAsync(m => m.ReturnID == id);
            if (returnTransaction == null)
            {
                return NotFound();
            }

            return View(returnTransaction);
        }

        // POST: Returns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Returns == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Returns'  is null.");
            }
            var returnTransaction = await _context.Returns.FindAsync(id);
            if (returnTransaction != null)
            {
                _context.Returns.Remove(returnTransaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnTransactionExists(int id)
        {
          return _context.Returns.Any(e => e.ReturnID == id);
        }
    }
}
