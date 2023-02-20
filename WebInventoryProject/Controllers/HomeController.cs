using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInventoryProject.Models;
using WebInventoryProject.ViewModel;

namespace WebInventoryProject.Controllers
{
    
    public class HomeController : Controller
    {
        int saved = 0;
        DbContextClass _context = new DbContextClass();
     
        public ActionResult IndexOfSupplier()
        {
            var ListofSupplier = _context.Supplier.ToList();
            return View(ListofSupplier);
        }

        public ActionResult Supplier(int SPId = 0)
        {
            if (SPId == 0)
            {
                return View();
            }
            else
            {
                var IfExist = _context.Supplier.Where(x => x.SPId == SPId).FirstOrDefault();
                return View(IfExist);
            }
        }
        [HttpPost]
        public ActionResult Supplier(Supplier model)
        {
            var IfExist = _context.Supplier.Where(x => x.SPId == model.SPId).FirstOrDefault();
            if (IfExist == null)
            {
                _context.Supplier.Add(model);
                _context.SaveChanges();
                TempData["Success"] = "Supplier Added";
                return RedirectToAction("IndexOfSupplier", "Home");
            }
            else
            {   
                IfExist = _context.Supplier.Where(x => x.SPId == model.SPId).FirstOrDefault();
                IfExist.Vendor = model.Vendor;
                IfExist.VendorCode = model.VendorCode;
                IfExist.CellNo = model.CellNo;
                IfExist.Address = model.Address;
                _context.SaveChanges();
                TempData["Success"] = "Supplier Updated";
                return RedirectToAction("IndexOfSupplier", "Home");
            }

        }

        public ActionResult Delete(int? SPId)
        {
            var ifExist = _context.Supplier.Where(x => x.SPId == SPId).FirstOrDefault();
            if (ifExist != null)
            {
                _context.Supplier.Remove(ifExist);
                var removed = _context.SaveChanges();
                if (removed > 0)
                {
                    TempData["Success"] = "Deleted Successfully";
                    return RedirectToAction("IndexOfSupplier", "Home");
                }


            }
            return View();
        }

        #region UserFromRights
        public ActionResult UserInvRightsIndex()
        {
            var list = _context.settingUserInventoryRights.ToList();
            return View(list);
        }
        public ActionResult UserInventoryRights(int Id = 0)
        {           
            var ifexist = _context.settingUserInventoryRights.Where(x => x.Id == Id).FirstOrDefault();          
            if (ifexist != null)
            {
                var viewmodel = new UserInventoryRightsViewModel()
                {
                    settingBranch = _context.settingBranch.ToList(),
                    settingDepartment = _context.settingDepartment.ToList(),
                    loginUsers = _context.loginUser.ToList(),
                    settingUserInventoryRights = ifexist,
                    userType = ifexist.UserType
                  
                };
                return View(viewmodel);
            }
            else 
            {
                var vwmodel = new UserInventoryRightsViewModel()
                {
                    settingBranch = _context.settingBranch.ToList(),
                    settingDepartment = _context.settingDepartment.ToList(),
                    loginUsers = _context.loginUser.ToList(),
                    userType = null
                };
                return View(vwmodel);
            } 
    }
           
        [HttpPost]
        public ActionResult UserInventoryRights(UserInventoryRightsViewModel recValues)
        {
            var getUserbyId = _context.loginUser.Where(x=> x.userId == recValues.settingUserInventoryRights.userId).FirstOrDefault();
            var userInDB = getUserbyId.userId;
            var UserTypeExist = _context.settingUserInventoryRights.Where(x=> x.userId == userInDB && x.UserType == recValues.userType).FirstOrDefault();
            //For Update
            if (UserTypeExist == null)
            {            
            var ifExist = _context.settingUserInventoryRights.Where(x => x.Id == recValues.settingUserInventoryRights.Id).FirstOrDefault();
                if (ifExist != null)
                {
                    ifExist.loginUser = recValues.settingUserInventoryRights.loginUser;
                    ifExist.branchId = recValues.settingUserInventoryRights.branchId;
                    ifExist.departmentId = recValues.settingUserInventoryRights.departmentId;
                    ifExist.formId = recValues.settingUserInventoryRights.formId;
                    ifExist.edit = recValues.settingUserInventoryRights.edit;
                    ifExist.delete = recValues.settingUserInventoryRights.delete;
                    ifExist.save = recValues.settingUserInventoryRights.save;
                    ifExist.post = recValues.settingUserInventoryRights.post;
                    ifExist.userId = recValues.settingUserInventoryRights.userId;
                    ifExist.UserType = recValues.userType;
                    saved = _context.SaveChanges();
                    if (saved > 0)
                    {
                        TempData["Success"] = "Upated SuccessFully";
                        return RedirectToAction("UserInvRightsIndex");
                    }
                    else
                    {
                        TempData["Success"] = "Not Upated";
                        return RedirectToAction("UserInventoryRights");
                    }

                }
                else
                {
                    if (recValues.userType != null)
                    {
                        recValues.settingUserInventoryRights.UserType = recValues.userType;
                        _context.settingUserInventoryRights.Add(recValues.settingUserInventoryRights);
                        saved = _context.SaveChanges();
                        if (saved > 0)
                        {
                            TempData["Success"] = "Added SuccessFully";
                            return RedirectToAction("UserInvRightsIndex");
                        }
                        else
                        {
                            TempData["Success"] = "Not Added";
                            return RedirectToAction("UserInventoryRights");
                        }
                    }
                    else
                    {
                        TempData["Success"] = "Select UserType";
                        return RedirectToAction("UserInventoryRights");
                    }
                }                
            }
            else
            {
                TempData["Error"] = "Same User and UserType Already Exist";
                return RedirectToAction("UserInventoryRights");
            }
            return View();
        }
        public ActionResult DeleteUserInvRights(int Id)
        {
            var ifexist = _context.settingUserInventoryRights.Where(x => x.Id == Id).FirstOrDefault();
            var delete = _context.settingUserInventoryRights.Remove(ifexist);
            if (delete != null)
            {
                _context.SaveChanges();
                TempData["Success"] = "Deleted Successfully";
                return RedirectToAction("UserInvRightsIndex");
            }
            else
                TempData["Success"] = "Not Deleted";
            return RedirectToAction("UserInvRightsIndex");
        }
        #endregion
    }
}