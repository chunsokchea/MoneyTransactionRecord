using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyTransferWeb.Data;

namespace MoneyTransferWeb.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var capital = await _context.Capitals
                .Include(c=>c.Balances)
               /* .Include(t=>t.Transactions).ThenInclude(r=>r.ReturnTransactions)
                 .Include(t => t.Transactions).ThenInclude(r => r.TransactionChild)*/
                .Include(w=>w.Withdraws)
                .FirstOrDefaultAsync(m => m.isActive==true);
            if (capital == null)
            {
                //return NotFound();
                return Redirect("/capitals/create");
            }
            var transaction =  _context.Transactions
                .Include(r => r.ReturnTransactions)
                .Include(t => t.TransactionChild)
                .Where(c => c.CapitalID == capital.CapitalID).ToList();


            var cAmountR = capital.CAmountR;           
            var cAmountS = capital.CAmountS;
            var uAmountR = 0;
            var uAmountS = 0;
            var tAmountR = 0;
            var tAmountS = 0;
            var deptAmountR = 0;
            var deptAmountS = 0;
            var oweAmountR = 0;
            var oweAmountS = 0;
            var withdrawR=0;
            var withdrawS = 0;

            foreach (var t in transaction)
            {
                foreach(var tc in t.TransactionChild)
                {
                    if (tc.TType == true)
                    {
                        tAmountR += ((int)tc.TAmountR);
                        tAmountS += ((int)tc.TAmountS);
                       
                    }
                    if (tc.TType == false)
                    {
                        uAmountR += ((int)tc.TAmountR);
                        uAmountS += ((int)tc.TAmountS);
                        
                    }
                }
                try
                {                    
                    var d = t.Debt;
                    if(d is not null)
                    {
                        if (d.DebtOwe == true)
                        {
                            deptAmountR += (int)d.DAmountR;
                            deptAmountS += (int)d.DAmountS;
                        }
                        else
                        {
                            oweAmountR += (int)d.DAmountR;
                            oweAmountS += (int)d.DAmountS;
                        }
                    }                   
                }
                catch (Exception)
                {

                }
                           
                    
                
                
            }
            foreach(var withdraw in capital.Withdraws)
            {
                withdrawR += ((int)withdraw.WAmountR);
                withdrawS += ((int)withdraw.WAmountS);
            }

            ViewBag.CAmountR =  cAmountR.ToString("N0");
            ViewBag.CAmountS = cAmountS.ToString("N0");
            ViewBag.UAmountR = uAmountR.ToString("N0");
            ViewBag.UAmountS = uAmountS.ToString("N0");
            ViewBag.TAmountR = tAmountR.ToString("N0");
            ViewBag.TAmountS = tAmountS.ToString("N0");
            ViewBag.DAmountR = deptAmountR.ToString("N0");
            ViewBag.DAmountS = deptAmountS.ToString("N0");
            ViewBag.OAmountR = oweAmountR.ToString("N0");
            ViewBag.OAmountS = oweAmountS.ToString("N0");
            ViewBag.WAmountR = withdrawR.ToString("N0");
            ViewBag.WAmountS = withdrawS.ToString("N0");

            return View();
        }

        public async Task<IActionResult> Capital()
        {                       
            var capital = await _context.Capitals
                .Include(c => c.Balances).ThenInclude(b => b.Institution)
                .Include(c => c.Withdraws)
                .FirstOrDefaultAsync(c => c.isActive==true);

            if (capital == null)
            {
                return NotFound();
            }
            return View("../Capitals/Details",capital);
        }

    }
}
