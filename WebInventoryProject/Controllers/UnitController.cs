using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInventoryProject.Models;

namespace WebInventoryProject.Controllers
{
    public class UnitController : Controller
    {
        DbContextClass context = new DbContextClass();
        // GET: Unit
        public ActionResult Index()
        {
            var listView = context.settingUnit.Where(x=>x.isActive==true);
            return View(listView);
        }
        public ActionResult Unit(int? unitId)
        {
            if (unitId == null)
                return View();
            else
            {
                var ifExists = context.settingUnit.Where(x => x.unitId == unitId).FirstOrDefault();
                return View(ifExists);
            }
        }
        [HttpPost]
        public ActionResult Unit(settingUnit recValue,int? unitId)
        {
            if (unitId == null)
            {
                var ifExists = context.settingUnit.Where(x => x.unitName == recValue.unitName).FirstOrDefault();
                if (ifExists == null)
                {
                   context.settingUnit.Add(recValue);
                    int i = context.SaveChanges();
                    if (i>0)
                    {
                        TempData["Success"] = "Unit Saved";
                        return RedirectToAction("Index");
                    }
                    else
                        TempData["Error"] = "Error Occured";

                }
                else
                    TempData["Error"] = "Unit Already Exists";
            }
            else
            {
                var dbValues = context.settingUnit.Where(x => x.unitId == unitId).FirstOrDefault();
                if (dbValues != null)
                {
                    dbValues.unitName = recValue.unitName;
                    dbValues.isActive = recValue.isActive;
                    int i = context.SaveChanges();
                    if (i > 0)
                    {
                        TempData["Success"] = "Unit Updated";
                        RedirectToAction("Index");
                    }
                    else
                        TempData["Error"] = "Error Occured";
                }
            }
            return View();
        }
        public ActionResult DeleteUnit(int? unitId)
        {
            var dbvalue = context.settingUnit.Where(x => x.unitId == unitId).FirstOrDefault();
            if (dbvalue != null)
            {
                dbvalue.isActive = false;
                int i = context.SaveChanges();
                if (i > 0)
                {
                    TempData["Success"] = "Unit Deactivated Successfully";
                    return RedirectToAction("Index");
                }
                else
                    TempData["Error"] = "Error Occured";
            }
            return View();
        }
    }
}