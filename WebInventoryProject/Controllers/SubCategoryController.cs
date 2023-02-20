using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInventoryProject.Models;
using WebInventoryProject.ViewModel;

namespace WebInventoryProject.Controllers
{
    public class SubCategoryController : Controller
    {
        DbContextClass context = new DbContextClass();
        // GET: SubCategory
        public ActionResult Index()
        {
           var list = context.settingSubCategory.Where(x=> x.isActive == true).ToList();
            return View(list);
        }
        public ActionResult SubCategory(int? subcategoryId)
        {
            if (subcategoryId > 0)
            {
                var ifExist = context.settingSubCategory.Where(x => x.subcategoryId == subcategoryId).FirstOrDefault();
                var list = context.settingCategory.ToList();
                var viewmodel = new SubcategoryViewModel()
                {
                    settingSubCategory = ifExist,
                    settingCategory = list
                };
                return View(viewmodel);
            }
            else
            {
                var list = context.settingCategory.ToList();
                var Viewmodel = new SubcategoryViewModel()
                {
                    settingCategory = list,
                };
                return View(Viewmodel);
            }
        }
        [HttpPost]
        public ActionResult SubCategory(SubcategoryViewModel recValues)
        {        
            var ifExist = context.settingSubCategory.Where(x => x.subcategoryId == recValues.settingSubCategory.subcategoryId).FirstOrDefault();
            if (ifExist == null)
            {
                var add = context.settingSubCategory.Add(recValues.settingSubCategory);
                int i = context.SaveChanges();
                if (i > 0)
                {
                    TempData["Success"] = "Sub Category Saved";
                    return RedirectToAction("Index");
                }
                else
                    TempData["Error"] = "Error Occured";
                    return View();
            }
            else
            {
                ifExist.categoryId = recValues.settingSubCategory.categoryId;
                ifExist.subcategoryName = recValues.settingSubCategory.subcategoryName;
                ifExist.isActive = recValues.settingSubCategory.isActive;
                var added = context.SaveChanges();
                if (added > 0)
                {
                    TempData["Success"] = "Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Error Occured";
                    return View();
                }                              
            }
            
        }
        public ActionResult Delete(int? subcategoryId)
        {
            var ifExist = context.settingSubCategory.Where(x => x.subcategoryId == subcategoryId).FirstOrDefault();
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