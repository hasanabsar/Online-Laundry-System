using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Laundry_System.Data;
using Online_Laundry_System.Models;

namespace Online_Laundry_System.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult createOrder()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                return RedirectToAction("Login", "Resgistration");
            }

            return View();
        }


        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult createOrder(Order model)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(model);
                _context.SaveChanges();
                ViewBag.Message = "Order Successfully";
                ViewBag.Showpreview = true;
                ViewBag.ShowData = model;
                return RedirectToAction("createOrder");
            }

            return View(new Order());
        }
    }
}

 