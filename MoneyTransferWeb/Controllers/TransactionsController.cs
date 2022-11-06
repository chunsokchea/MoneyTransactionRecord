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
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Transactions.Include(t => t.Capital).Include(t => t.Client);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Daily()
        {
            var applicationDbContext = _context.Transactions.Include(t => t.Capital).Include(t => t.Client).Where(t=>t.TransactionDateTime.Date==DateTime.Now.Date);
            return View("Index",await applicationDbContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Capital)
                .Include(t => t.Client)
                .Include(t=>t.TransactionChild)
                .Include(t=>t.ReturnTransactions)
                .Include(t=>t.Debt)
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            Transaction transaction = new Transaction();
            transaction.TransactionChild.Add(new TransactionChild() { ChildID =0, });
           // transaction.Debts.Add(new Debt() { DebtID = 0 });
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID");
            ViewData["ClientID"] = new SelectList(_context.Clients.OrderByDescending(c=>c.ClientID), "ClientID", "ClientName");
            return View(transaction);
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Transaction transaction)
        {
           // return Json(transaction);
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID", transaction.CapitalID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientName", transaction.ClientID);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID", transaction.CapitalID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientName", transaction.ClientID);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionID,TotalR,TotalS,TDetail,TransactionDateTime,ClientID,CapitalID")] Transaction transaction)
        {
            if (id != transaction.TransactionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionID))
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
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID", transaction.CapitalID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientName", transaction.ClientID);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Capital)
                .Include(t => t.Client)
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transactions'  is null.");
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
          return _context.Transactions.Any(e => e.TransactionID == id);
        }
    }
}
