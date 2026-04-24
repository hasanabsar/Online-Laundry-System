using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Online_Laundry_System.Data;
using Online_Laundry_System.Models;

namespace Online_Laundry_System.Controllers
{
    public class ResgistrationController : Controller
    {
        [HttpGet]
        public IActionResult regis()
        {
            return View();
        }

        private readonly ApplicationDbContext _context;

        public ResgistrationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult regis(Resgistration model) 
        {
            if (ModelState.IsValid)
            {
                _context.Resgistrations.Add(model);
                _context.SaveChanges();
                ViewBag.Message = "Registration Successfully";
                ViewBag.Showpreview = true;
                ViewBag.ShowData = model;
                return RedirectToAction("login");
            }

            return View(new Resgistration());
        } 

        //=====LOGIN=====

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Resgistrations
                .FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserEmail", user.Email);
                return RedirectToAction("createOrder", "Order");
            }

            ViewBag.Message = "Invalid Email or Password";
            return View();
        }

        //======LOGOUT=======

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
        
            HttpContext.Session.Clear();   // session remove
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Resgistration");
        
        }

        //====ADMin=====

        public IActionResult adminlogin(string email, string password)
        {
            var admin = _context.Admins
            .FirstOrDefault(a => a.email == email && a.password == password);

            if (admin != null)
            {
                return RedirectToAction("admindashboard", "Admin");
            }
            else
            {
                ViewBag.Message = "Invalid Email or Password";
                return View();
            }

            //return View();
        }
    }
}
