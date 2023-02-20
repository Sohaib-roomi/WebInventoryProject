using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInventoryProject.Models;

namespace WebInventoryProject.Controllers
{
    public class UserController : Controller
    {

        DbContextClass _context = new DbContextClass();
        public static int UserId;
        public static string UserType;
        public static bool AllowEdit, AllowDelete, AllowSave, AllowPost;
        // GET: User
        //user should be branch wise
        //normal user ko uski brach or department hi dikhao kisi b View me
        //only admin should see drop down list of branches
        //back date allow mt kro only admin ko allow ho back date ki entry
        //item type Raw or etc ka dropdown add kro
        //validations wagera pe km karo
        //
        
        public ActionResult SignUpUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUpUser(loginUser loginUser) 
        {
            //if (ModelState.IsValid)
            {
                UserId = 0;
                var UserInDB = _context.loginUser.Where(c => c.email == loginUser.email && c.password == loginUser.password).SingleOrDefault();
                var getUserType = _context.settingUserInventoryRights.Where(x => x.userId == UserInDB.userId).FirstOrDefault();
                if (getUserType != null)
                {
                    AllowSave = getUserType.save;
                    AllowEdit = getUserType.edit;
                    AllowDelete = getUserType.delete;
                    AllowPost = getUserType.post;
                }
                else 
                {
                    TempData["Error"] = "Set User Rights";
                    return View();
                }
                

                //if (?getUserType == null) getUserType.UserType = "";                
                if (UserInDB != null)
                {
                    Session["userId"] = UserInDB.userId.ToString();
                    Session["userName"] = UserInDB.firstName.ToString();   
                    TempData["User"] = Session["userName"];
                    UserId = int.Parse(Session["userId"].ToString());
                    TempData["Success"] = "Logged In Successfully";
                    return RedirectToAction("Index", "Branch");
                }
                else
                {
                    TempData["Error"] = "User Name Or Password is Incorrect";
                    return View();
                }

            }
     
        }
        public ActionResult RegisterUser() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(loginUser loginUser)
        {
            try
            {
            if (loginUser != null)
            {
                _context.loginUser.Add(loginUser);
                int a = _context.SaveChanges();
                if (a > 0)
                {
                    TempData["Success"] = "User Registered Successfully";
                    return RedirectToAction("SignUpUser");
                }
                else
                {
                    TempData["Error"] = "Error User Not Registered";
                    return View();
                }
            }
            else 
            {
                TempData["Error"] = "Fill the Form Properly";
                return View();
            }
            }
            catch (System.Exception e)
            {
                
            }
            return View();
        }
    }
}