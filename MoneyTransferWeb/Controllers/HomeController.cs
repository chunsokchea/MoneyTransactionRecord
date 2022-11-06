using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyTransferWeb.Data;
using MoneyTransferWeb.Models;
using System;
using System.Diagnostics;

namespace MoneyTransferWeb.Controllers
{
    public class HomeController : Controller
    {       
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
          
        public IActionResult Index()
        {         
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*public IActionResult CreateCapital(int? id)
        {
            if(id==null || _context.Capitals == null)
            {
                return Redirect("/capitals/create");
            }
            return Redirect("/capitals/details/"+id);
        }
        public IActionResult CreateTransaction()
        {
            return Redirect("/clienttransactions/create");
        }
        public async Task<IActionResult> GetCapital(DateTime dateTime)
        {
            var capital = await _context.Capitals
                .FirstOrDefaultAsync(m => m.CreatedDateTime.ToString("dd/MM/yyyy") == dateTime.ToString("dd/MM/yyyy"));
            if (capital == null)
            {
                return NotFound();
            }

            return View(capital);
        }*/
    }
}