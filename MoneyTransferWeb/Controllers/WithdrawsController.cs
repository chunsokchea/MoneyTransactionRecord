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
    public class WithdrawsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WithdrawsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Withdraws
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Withdraws.Include(w => w.Capital).OrderByDescending(c=>c.CapitalID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Withdraws/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Withdraws == null)
            {
                return NotFound();
            }

            var withdraw = await _context.Withdraws
                .Include(w => w.Capital)
                .FirstOrDefaultAsync(m => m.WithdrawID == id);
            if (withdraw == null)
            {
                return NotFound();
            }

            return PartialView(withdraw);
        }

        // GET: Withdraws/Create
        public IActionResult Create()
        {
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID");
            return PartialView();
        }

        // POST: Withdraws/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WithdrawID,WAmountR,WAmountS,WithdrawDateTime,WDetail,CapitalID")] Withdraw withdraw)
        {
            if (ModelState.IsValid)
            {
                _context.Add(withdraw);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID", withdraw.CapitalID);
            return View(withdraw);
        }

        // GET: Withdraws/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Withdraws == null)
            {
                return NotFound();
            }

            var withdraw = await _context.Withdraws.FindAsync(id);
            if (withdraw == null)
            {
                return NotFound();
            }
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID", withdraw.CapitalID);
            return PartialView(withdraw);
        }

        // POST: Withdraws/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WithdrawID,WAmountR,WAmountS,WithdrawDateTime,WDetail,CapitalID")] Withdraw withdraw)
        {
            if (id != withdraw.WithdrawID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(withdraw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WithdrawExists(withdraw.WithdrawID))
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
            ViewData["CapitalID"] = new SelectList(_context.Capitals, "CapitalID", "CapitalID", withdraw.CapitalID);
            return View(withdraw);
        }

        // GET: Withdraws/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Withdraws == null)
            {
                return NotFound();
            }

            var withdraw = await _context.Withdraws
                .Include(w => w.Capital)
                .FirstOrDefaultAsync(m => m.WithdrawID == id);
            if (withdraw == null)
            {
                return NotFound();
            }

            return PartialView(withdraw);
        }

        // POST: Withdraws/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Withdraws == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Withdraws'  is null.");
            }
            var withdraw = await _context.Withdraws.FindAsync(id);
            if (withdraw != null)
            {
                _context.Withdraws.Remove(withdraw);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WithdrawExists(int id)
        {
          return _context.Withdraws.Any(e => e.WithdrawID == id);
        }
    }
}
