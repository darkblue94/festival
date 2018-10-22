using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FestiFind.Models;

namespace FestiFind.Controllers
{
    public class HomeController : Controller
    {
        private FContext _context;

        public HomeController(FContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [Route("register")]
        public IActionResult Register(ValidateUser NewUser)
        {


            if (ModelState.IsValid)
            {
                User DBUser = _context.user.SingleOrDefault(u => u.Email == NewUser.Email);

                if (DBUser != null)
                {
                    ViewBag.Error = "Email already exists";
                    return View("Index");
                }



                User RealUser = new User();
                RealUser.FirstName = NewUser.FirstName;
                RealUser.LastName = NewUser.LastName;
                RealUser.Email = NewUser.Email;
                RealUser.Password = NewUser.Password;
             

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                RealUser.Password = Hasher.HashPassword(RealUser, RealUser.Password);


                _context.user.Add(RealUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", RealUser.User_Id);



                return RedirectToAction("Dashboard", RealUser);

            }

            return View("Index");
        }





        [HttpPost]
        [Route("process")]

        public IActionResult Login(string LogEmail, string LogPass)
        {

            if (ModelState.IsValid)
            {

                User DBUser = _context.user.SingleOrDefault(u => u.Email == LogEmail);

                var user = DBUser;
                if (user != null && LogPass != null)
                {
                    var Hasher = new PasswordHasher<User>();


                    if (0 != Hasher.VerifyHashedPassword(user, hashedPassword: user.Password, providedPassword: LogPass))
                    {
                        HttpContext.Session.SetInt32("UserId", DBUser.User_Id);
                        return RedirectToAction("About", user);

                    }
                    else
                    {
                        ViewBag.Error = " Invalid Login";
                        return View("Index");
                    }
                }
            }

            ViewBag.Error = " Invalid Login";
            return View("Index");

        }
       
        public IActionResult Dashboard()

        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }

            int UserId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            User thisUser = _context.user.Where(p => p.User_Id == UserId).SingleOrDefault();
           

            return View(thisUser);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
