using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInventoryProject.Models;
using WebInventoryProject.ViewModel;

namespace WebInventoryProject.Controllers
{
    public class CategoryController : Controller
    {
        DbContextClass context = new DbContextClass();
        //public bool AllowtoSave, AllowtoEdit, AllowtoDelete;
        // GET: Category
        public ActionResult Index()
        {
            //List of Category
            //MasterDetailController obj = new MasterDetailController();
            //var Rights = obj.CheckUserRights();
            //AllowtoSave = Rights.save;
            //AllowtoEdit = Rights.edit;
            //AllowtoDelete = Rights.delete;
            //var viewModel = new InvRightsViewModel
            //{
            //    settingCategory = context.settingCategory.Where(x => x.isActive == true).ToList(),
            //    save = AllowtoSave,
            //    edit = AllowtoEdit,
            //    delete = AllowtoDelete,
            //};
            var list = context.settingCategory.Where(x => x.isActive == true).ToList();
            return View(list);
        }
        //public void CheckRights() 
        //{
        //    MasterDetailController obj = new MasterDetailController();
        //    var Rights = obj.CheckUserRights();
        //    AllowtoSave = Rights.save;
        //    AllowtoEdit = Rights.edit;
           
        //}
        public ActionResult Category(int? categoryId)//create form
        {
            if(categoryId==null)
                return View();
            else
            {
                var ifexists = context.settingCategory.Where(x => x.categoryId == categoryId).FirstOrDefault();
                return View(ifexists);
            }
        }
        [HttpPost]
        public ActionResult Category(settingCategory RecValues, int? categoryId)
        {
                if (categoryId == null)
                {
                    //Save Category
                    var ifexists = context.settingCategory.Where(x => x.categoryName == RecValues.categoryName).FirstOrDefault();
                    if (ifexists == null)
                    {
                        context.settingCategory.Add(RecValues);
                        int a = context.SaveChanges();
                        if (a > 0)
                        {
                            TempData["Success"] = "Category Saved";
                            return RedirectToAction("Index", "Category");
                        }
                        else
                            TempData["Error"] = "Error Occured";
                    }
                    else
                        TempData["Error"] = "Category Already Exists";
                }
                else
                {
                    var dbvalues = context.settingCategory.Where(x => x.categoryId == categoryId).FirstOrDefault();
                    if (dbvalues != null)
                    {
                        dbvalues.categoryName = RecValues.categoryName;
                        dbvalues.isActive = RecValues.isActive;
                        int a = context.SaveChanges();
                        if (a > 0)
                        {
                            TempData["Success"] = "Category Updated ";
                            return RedirectToAction("Index", "Category");
                        }
                        else
                            TempData["Error"] = "Error Occured";
                    }
                }
            return View();
        }

        public ActionResult Delete(int? categoryId)
        {
            var ifExist = context.settingCategory.Where(x => x.categoryId == categoryId).FirstOrDefault();
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