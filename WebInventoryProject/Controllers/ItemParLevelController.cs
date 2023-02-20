using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInventoryProject.Models;
using WebInventoryProject.ViewModel;


namespace WebInventoryProject.Controllers
{
    public class ItemParLevelController : Controller
    {
        DbContextClass _context = new DbContextClass();
        // GET: ItemParLevel
        //get Record
        public ActionResult ItemList()
        {
            var Records = _context.SettingItem.Where(x => x.isActive == true).ToList();
            return View(Records);
        }

        // GET: ItemParLevel
        public List<ParLevelViewModel> parLevelViewModelsList()
        {
            var List = (from branch in _context.settingBranch
                        join department in _context.settingDepartment on branch.branchId equals department.branchId
                        join parlevel in _context.SettingItemParlevels on branch.branchId equals parlevel.branchId
                        join Item in _context.SettingItem on parlevel.itemId equals Item.itemId
                        select new ParLevelViewModel()
                        {
                            branchId = branch.branchId,
                            branchName = branch.branchName,
                            departmentId = department.departmentId,
                            departmentName = department.departmentName,
                            ItemId = parlevel.itemId,
                            min = parlevel.min,
                            max = parlevel.max

                        }).ToList();
            return List;
        }
        public List<ParLevelViewModel> ParLevelListForInsert()
        {
            var Lista = (from br in _context.settingBranch
                         join de in _context.settingDepartment on br.branchId equals de.departmentId
                         select new ParLevelViewModel()
                         {
                             branchId = br.branchId,
                             branchName = br.branchName,
                             departmentId = de.departmentId,
                             departmentName = de.departmentName
                         }).ToList();
            return Lista;
        }

        public ActionResult Index(int ItemId = 0)
        {
            if (ItemId == 0)
            {
                var unitList = _context.settingUnit.ToList();
                var SubCatList = _context.settingSubCategory.ToList();

                var ViewModel = new ParLevelViewModel()
                {
                    settingUnits = unitList,
                    settingSubCategories = SubCatList,
                    ParLevelViewModels = ParLevelListForInsert(),

                };
                return View(ViewModel);

            }
            else

            {
                var ifExist = _context.SettingItem.Where(x => x.itemId == ItemId).FirstOrDefault();
                var unitList = _context.settingUnit.ToList();
                var SubCatList = _context.settingSubCategory.ToList();

                var ViewModel = new ParLevelViewModel()
                {

                    SettingItem = ifExist,
                    settingUnits = unitList,
                    settingSubCategories = SubCatList,
                    ParLevelViewModels = parLevelViewModelsList().Where(x => x.ItemId == ItemId).ToList(),

                };
                return View(ViewModel);
            }
        }
        [HttpPost]
        public JsonResult Index(List<ParLevelViewModel> ParLevelViewModel, settingItem model)
        {
            if (ParLevelViewModel == null)
            {
                return Json(ParLevelViewModel);
            }
            var IfExist = _context.SettingItem.Where(x => x.itemId == model.itemId).FirstOrDefault();
            if (IfExist == null)
            {



                settingItem obj = new settingItem();
                obj.itemId = model.itemId;
                obj.itemName = model.itemName;
                obj.itemCode = model.itemCode;
                obj.itemType = model.itemType;
                obj.subcategoryId = model.subcategoryId;
                obj.purchaseUnitId = model.purchaseUnitId;
                obj.issuanceUnitId = model.issuanceUnitId;
                obj.recipeUnitId = model.recipeUnitId;
                obj.purchaseIssuanceConv = model.purchaseIssuanceConv;
                obj.issuanceRecipeConv = model.issuanceRecipeConv;
                obj.isActive = model.isActive;
                obj.dateAdded = DateTime.Now;
                _context.SettingItem.Add(obj);
                _context.SaveChanges();
                //if you want ot Truancate record
                //_context.Database.ExecuteSqlCommand("what ever the command you want to run on dtabase");
                foreach (var Itemsdata in ParLevelViewModel)
                {
                    if (Itemsdata.max > 0 && Itemsdata.min > 0)
                    {
                        settingItemParlevel setValues = new settingItemParlevel();
                        setValues.itemId = obj.itemId;
                        setValues.departmentId = Itemsdata.departmentId;
                        setValues.branchId = Itemsdata.branchId;
                        setValues.min = Itemsdata.min;
                        setValues.max = Itemsdata.max;
                        _context.SettingItemParlevels.Add(setValues);
                        _context.SaveChanges();
                    }
                }
                int added = _context.SaveChanges();
                TempData["Success"] = "Added Successfully!";
                return Json(added);
            }
            else
            {
                settingItem obj = new settingItem();
                obj.itemId = model.itemId;
                obj.itemName = IfExist.itemName;
                obj.itemCode = IfExist.itemCode;
                obj.itemType = IfExist.itemType;
                obj.subcategoryId = IfExist.subcategoryId;
                obj.purchaseUnitId = IfExist.purchaseUnitId;
                obj.issuanceUnitId = IfExist.issuanceUnitId;
                obj.recipeUnitId = IfExist.recipeUnitId;
                obj.purchaseIssuanceConv = IfExist.purchaseIssuanceConv;
                obj.issuanceRecipeConv = IfExist.issuanceRecipeConv;
                obj.isActive = IfExist.isActive;
                obj.dateAdded = DateTime.Now;
                _context.SaveChanges();

                var IfExist1 = _context.SettingItemParlevels.Where(x => x.itemId == model.itemId).ToList();
                _context.SettingItemParlevels.RemoveRange(IfExist1);
                _context.SaveChanges();
                foreach (var Itemsdata in ParLevelViewModel)
                {
                    settingItemParlevel setValues = new settingItemParlevel();
                    setValues.itemId = obj.itemId;
                    setValues.departmentId = Itemsdata.departmentId;
                    setValues.branchId = Itemsdata.branchId;
                    setValues.min = Itemsdata.min;
                    setValues.max = Itemsdata.max;
                    _context.SettingItemParlevels.Add(setValues);
                    _context.SaveChanges();
                }
                int updated = _context.SaveChanges();
                TempData["Success"] = "Updated Successfully!";
                return Json(updated);


            }
        }


    }
}
