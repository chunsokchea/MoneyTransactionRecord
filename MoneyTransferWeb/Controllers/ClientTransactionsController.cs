/*using System;
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
    public class ClientTransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientTransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientTransactions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClientTransactions.Include(c => c.Capital).Include(c => c.Client);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClientTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientTransactions == null)
            {
                return NotFound();
            }

            var clientTransaction = await _context.ClientTransactions
                .Include(c => c.Capital)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ClientTransactionID == id);
            if (clientTransaction == null)
            {
                return NotFound();
            }

            return View(clientTransaction);
        }

        // GET: ClientTransactions/Create
        public IActionResult Create()
        {
            ViewData["CapitalID"] = new SelectList(_context.Capitals.Where(c => c.isActive == true),"CapitalID","CapitalID");           
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientName");
            var trans = new List<TransactionDebt>();  
            return View(trans);
        }

        // POST: ClientTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientTransactionID,TAmountR,TAmountS,TransactionType,TDetail,Dept,DeptAmountR,DeptAmountS,TransactionDateTime,ClientID,CapitalID")] TransactionChild clientTransaction,Debt debt)
        {
            return Json(clientTransaction);
            if (ModelState.IsValid)
            {
                _context.Add(clientTransaction);
                //await _context.SaveChangesAsync();
                _context.Add(debt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID", clientTransaction.CapitalID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientName", clientTransaction.ClientID);
            return View(clientTransaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Createa(List<TransactionChild> transactions, Debt debt)
        {
            return Json(transactions);
        }

        // GET: ClientTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientTransactions == null)
            {
                return NotFound();
            }

            var clientTransaction = await _context.ClientTransactions.FindAsync(id);
            if (clientTransaction == null)
            {
                return NotFound();
            }
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID", clientTransaction.CapitalID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientName", clientTransaction.ClientID);
            return View(clientTransaction);
        }

        // POST: ClientTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientTransactionID,TAmountR,TAmountS,TransactionType,TDetail,Dept,DeptAmountR,DeptAmountS,TransactionDateTime,ClientID,CapitalID")] TransactionChild clientTransaction)
        {
            if (id != clientTransaction.ClientTransactionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientTransactionExists(clientTransaction.ClientTransactionID))
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
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID", clientTransaction.CapitalID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientName", clientTransaction.ClientID);
            return View(clientTransaction);
        }

        // GET: ClientTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientTransactions == null)
            {
                return NotFound();
            }

            var clientTransaction = await _context.ClientTransactions
                .Include(c => c.Capital)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ClientTransactionID == id);
            if (clientTransaction == null)
            {
                return NotFound();
            }

            return View(clientTransaction);
        }

        // POST: ClientTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientTransactions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ClientTransactions'  is null.");
            }
            var clientTransaction = await _context.ClientTransactions.FindAsync(id);
            if (clientTransaction != null)
            {
                _context.ClientTransactions.Remove(clientTransaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientTransactionExists(int id)
        {
          return (_context.ClientTransactions?.Any(e => e.ClientTransactionID == id)).GetValueOrDefault();
        }
    }
}
*/