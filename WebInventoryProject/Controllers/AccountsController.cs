using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInventoryProject.Models;

namespace WebInventoryProject.Controllers
{
    public class AccountsController : Controller
    {
        int saved = 0;
        
        // GET: Accounts
        DbContextClass _context = new DbContextClass();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(loginUser loginUser)
        {
            //if (ModelState.IsValid)
            {
                var UserInDB = _context.loginUser.Where(c => c.email == loginUser.email && c.password == loginUser.password).SingleOrDefault();
                if (UserInDB != null)
                {
                    Session["userId"] = UserInDB.userId.ToString();
                    Session["userName"] = UserInDB.firstName.ToString();                 
                        TempData["Success"] = "Logged In Successfully";
                        TempData["User"] = Session["userName"];
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    TempData["Success"] = "User Name Or Password is Incorrect";
                    return View();

                }



            }
        }

        public ActionResult Insert()
        {
            return View();
        }
        public ActionResult signUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signUp(loginUser loginUser)
        {
           // if (ModelState.IsValid)
            {
                _context.loginUser.Add(loginUser);
                int a = _context.SaveChanges();
                if (a > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }


    }
}


