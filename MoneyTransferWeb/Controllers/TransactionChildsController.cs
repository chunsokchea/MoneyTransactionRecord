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
    public class TransactionChildsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionChildsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TransactionChilds
        public async Task<IActionResult> Index()
        {
              return View(await _context.TransactionChilds.ToListAsync());
        }

        // GET: TransactionChilds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransactionChilds == null)
            {
                return NotFound();
            }

            var transactionChild = await _context.TransactionChilds
                .FirstOrDefaultAsync(m => m.ChildID == id);
            if (transactionChild == null)
            {
                return NotFound();
            }

            return View(transactionChild);
        }

        // GET: TransactionChilds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransactionChilds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChildID,TAmountR,TAmountS,TType")] TransactionChild transactionChild)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionChild);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactionChild);
        }

        // GET: TransactionChilds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransactionChilds == null)
            {
                return NotFound();
            }

            var transactionChild = await _context.TransactionChilds.FindAsync(id);
            if (transactionChild == null)
            {
                return NotFound();
            }
            return View(transactionChild);
        }

        // POST: TransactionChilds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChildID,TAmountR,TAmountS,TType")] TransactionChild transactionChild)
        {
            if (id != transactionChild.ChildID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionChild);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionChildExists(transactionChild.ChildID))
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
            return View(transactionChild);
        }

        // GET: TransactionChilds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransactionChilds == null)
            {
                return NotFound();
            }

            var transactionChild = await _context.TransactionChilds
                .FirstOrDefaultAsync(m => m.ChildID == id);
            if (transactionChild == null)
            {
                return NotFound();
            }

            return View(transactionChild);
        }

        // POST: TransactionChilds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransactionChilds == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TransactionChilds'  is null.");
            }
            var transactionChild = await _context.TransactionChilds.FindAsync(id);
            if (transactionChild != null)
            {
                _context.TransactionChilds.Remove(transactionChild);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionChildExists(int id)
        {
          return _context.TransactionChilds.Any(e => e.ChildID == id);
        }
    }
}
