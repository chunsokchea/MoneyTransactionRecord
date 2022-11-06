using Microsoft.AspNetCore.Mvc;
using MoneyTransferWeb.Data;

namespace MoneyTransferWeb.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return Json("In Development");
            return View();
        }
    }
}
