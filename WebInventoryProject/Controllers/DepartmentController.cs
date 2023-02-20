using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInventoryProject.Models;
using WebInventoryProject.ViewModel;

namespace WebInventoryProject.Controllers
{
    public class DepartmentController : Controller
    {
        DbContextClass context = new DbContextClass();
        // GET: Department
        public ActionResult Index()
        {
            var listView = context.settingDepartment.Where(x=> x.isActive == true).ToList();
            return View(listView);
        }
        public ActionResult Department(int? departmentId)
        {
            if (departmentId == null)
            {
                var branchList = context.settingBranch.ToList();
                var ViewModel = new DepartmentViewModel()
                {
                    settingBranch = branchList,
                };
                return View(ViewModel);
            }
            else
            {
                var ifExists = context.settingDepartment.Where(x => x.departmentId == departmentId).FirstOrDefault();
                var branchList = context.settingBranch.ToList();
                var ViewModel = new DepartmentViewModel()
                {
                    settingDepartment = ifExists,
                    settingBranch = branchList
                };
                return View(ViewModel);
            }
        }

        [HttpPost]
        public ActionResult Department (DepartmentViewModel recValue)
        {
            if(recValue.settingDepartment.departmentId == 0)
            {
                var ifExists = context.settingDepartment.Where(x => x.departmentName == recValue.settingDepartment.departmentName && x.branchId == recValue.settingDepartment.branchId).FirstOrDefault();
                if (ifExists == null)
                {
                    context.settingDepartment.Add(recValue.settingDepartment);
                    int i = context.SaveChanges();
                    if (i > 0)
                    {
                        TempData["Success"] = "Department Saved";
                        return RedirectToAction("Index");
                    }
                    else
                        TempData["Error"] = "Error Occures";
                }
                else
                    TempData["Error"] = "Department Already Exists";
            }
            else
            {
                var dbValue = context.settingDepartment.Where(x => x.departmentId == recValue.settingDepartment.departmentId).FirstOrDefault();
                 if (dbValue != null)
                {
                    dbValue.branchId = recValue.settingDepartment.branchId;
                    dbValue.departmentName = recValue.settingDepartment.departmentName;
                    dbValue.isActive = recValue.settingDepartment.isActive;
                    int i = context.SaveChanges();
                    if (i > 0)
                    {
                        TempData["Success"] = "Department Updated ";
                        return RedirectToAction("Index", "Department");
                    }
                    else
                        TempData["Error"] = "Error Occured";
                }
            }
            return View();
        }
        public ActionResult Delete(int? departmentId)
        {
            var ifExist = context.settingDepartment.Where(x => x.departmentId == departmentId).FirstOrDefault();
            if (ifExist != null)
            {
                if (ifExist.isActive == false)
                {
                    ifExist.isActive = true;
                    var added = context.SaveChanges();
                    if (added > 0)
                    {
                        TempData["Success"] = "Activated Successfully";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ifExist.isActive = false;
                    var added = context.SaveChanges();
                    if (added > 0)
                    {
                        TempData["Error"] = "Deactivated Successfully";
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
    }
}