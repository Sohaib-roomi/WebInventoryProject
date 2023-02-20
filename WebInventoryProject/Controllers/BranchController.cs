using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInventoryProject.Models;

namespace WebInventoryProject.Controllers
{
    public class BranchController : Controller
    {
        DbContextClass context = new DbContextClass();
        // GET: Branch
        public ActionResult Index()
        {
            var branchList = context.settingBranch.Where(x=> x.isActive == true).ToList();
            return View(branchList);
        }

        public ActionResult Branch(int? branchId)
        {
            if (branchId == null)
                return View();
            else
            {
                var ifExists = context.settingBranch.Where(x => x.branchId == branchId).FirstOrDefault();
                return View(ifExists);
            }
        }
        [HttpPost]
        public ActionResult Branch(settingBranch recValue,int? branchId)
        {
            if(branchId==null)
            {
                var ifexists = context.settingBranch.Where(x => x.branchName == recValue.branchName).FirstOrDefault();
                if(ifexists==null)
                {
                    context.settingBranch.Add(recValue);
                    int i=context.SaveChanges();
                    if (i > 0)
                    {
                        TempData["Success"] = "Branch Saved";
                        return RedirectToAction("Index");
                    }
                    else
                        TempData["Error"] = "Error Occured";
                }
                else
                TempData["Error"] = "Branch Already Exists";
            }
            else
            {
                var dbValues = context.settingBranch.Where(x => x.branchId == branchId).FirstOrDefault();
                if(dbValues!=null)
                {
                    dbValues.branchName = recValue.branchName;
                    dbValues.isHeadOfficeBranch = recValue.isHeadOfficeBranch;
                    dbValues.isActive = recValue.isActive;
                    int i = context.SaveChanges();
                    if (i > 0)
                    {
                        TempData["Success"] = "Branch Updated";
                        RedirectToAction("Index");
                    }
                    else
                        TempData["Error"] = "Error Occured";
                }
            }
            return View();
        }
       
        public ActionResult DeleteBranch(int? branchId)
        {
            var dbvalue = context.settingBranch.Where(x => x.branchId == branchId).FirstOrDefault();
            if(dbvalue!=null)
            {
                dbvalue.isActive = false;
               int i= context.SaveChanges();
                if (i > 0)
                {
                    TempData["Success"] = "Branch Deactivated Successfully";
                    return RedirectToAction("Index");
                }
                else
                    TempData["Error"] = "Error Occured";
            }
            return View();
        }
    }
}