using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Laundry_System.Data;
using Online_Laundry_System.Models;

namespace Online_Laundry_System.Controllers
{
    public class AdminController : Controller
    {
         private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }
        public IActionResult admindashboard() 
        {
            var users = _context.Resgistrations.ToList();
            var invoices = _context.Orders.ToList();

              var model = new AdminDashboardViewModel 
              {
                Users = users,
                Invoices = invoices
              };


            return View(model); 
        }

        public IActionResult Dashboard()
        {
            var users = _context.Orders.ToList(); // example EF Core
            var invoices = _context.Orders.ToList();

            ViewBag.TotalInvoices = invoices.Count;
            ViewBag.Invoices = invoices;
            return View(users); // Model me users pass ho raha
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();   // agar session use kar rahe ho
            return RedirectToAction("adminlogin", "Resgistration");
        }
    }
}

