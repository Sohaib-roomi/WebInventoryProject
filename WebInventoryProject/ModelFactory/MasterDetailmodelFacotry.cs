using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using WebInventoryProject.Controllers;
using WebInventoryProject.Models;
using WebInventoryProject.ViewModel;

namespace WebInventoryProject.ModelFactory
{
    public class MasterDetailmodelFacotry
    {
        DbContextClass _context = new DbContextClass();
        public static int tempid;
        int userId;
        int departmentId;
        int branchId;

        public settingUserInventoryRights getDeptBranchbyUser()
        {
            userId = WebInventoryProject.Controllers.UserController.UserId;
            var user = _context.settingUserInventoryRights.Where(x => x.userId == userId).FirstOrDefault();
            if (user != null) { departmentId = user.departmentId; branchId = user.branchId; }
            return user;

        }
        #region InvDemandMasterDetail
        public InvMasterDetailViewModel InvDemandMasterDetail(InvMasterDetailViewModel viewModel)
        {
            settingUserInventoryRights user = getDeptBranchbyUser();
            if (user.UserType == "Admin")
            {
                viewModel = new InvMasterDetailViewModel()
                {
                    settingBranches = _context.settingBranch.ToList(),
                    settingDepartments = _context.settingDepartment.ToList(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    UserType = user.UserType,
                    code = MasterDetailController.Demcode
                    
                };
                return viewModel;
            }
            else
            {
                viewModel = new InvMasterDetailViewModel()
                {
                    settingBr = _context.settingBranch.Where(x => x.branchId == branchId).FirstOrDefault(),
                    settingDept = _context.settingDepartment.Where(x => x.departmentId == departmentId).FirstOrDefault(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    demandDate = DateTime.Now,
                    code = MasterDetailController.Demcode

                };
                return viewModel;
            }

        }

        public Result InvDemandMasterDetailPost(invDemandMaster OrderMasterArray, List<invDemandDetail> OrderDetailArray, int added)
        {
            invDemandMaster model = new invDemandMaster();
            try
            { //save Master Detail Form
                //if (true)
                {


                    settingUserInventoryRights user = getDeptBranchbyUser();//to get Dept and Branch
                    
                    model.demandDate = OrderMasterArray.demandDate;
                    model.demandNo = OrderMasterArray.demandNo;
                    if (user != null)
                    {
                        model.branchId = user.branchId;
                        model.departmentId = user.departmentId;
                    }
                    else
                    {
                        model.branchId = OrderMasterArray.branchId;
                        model.departmentId = OrderMasterArray.departmentId;
                    }
                    model.userId = userId;
                    model.dateTime = DateTime.Now;
                    model.modifiedDate = DateTime.Now;
                    model.isActive = OrderMasterArray.isActive;
                    model.isPost = false;
                    _context.invDemandMaster.Add(model);
                    _context.SaveChanges();
                    foreach (var item in OrderDetailArray)
                    {
                        invDemandDetail model2 = new invDemandDetail();
                        model2.itemId = item.itemId;
                        model2.unitId = item.unitId;
                        model2.qty = item.qty;
                        model2.balance = item.balance;
                        model2.isActive = item.isActive;
                        model2.stock = item.stock;
                        model2.demand_Id = model.demand_Id;
                        _context.invDemandDetail.Add(model2);

                    }
                }
                
            }
            catch (Exception ex)
            {
            }

            added = _context.SaveChanges();

            var Result = new Result()
            {
             TempId = model.demand_Id,
            AddedRecord = added,
            };


            return Result;
        }


        public int InvDemMasterDetailProceed(int getDemId, int added)
        {
            var getDemandMaster = _context.invDemandMaster.Where(x => x.demand_Id == getDemId).FirstOrDefault();
            var getDemandDetail = _context.invDemandDetail.Where(x => x.demand_Id == getDemId).ToList();
            getDemandMaster.isPost = true;
            _context.SaveChanges();

            foreach (var item in getDemandDetail)
            {
                invWareHouse model2 = new invWareHouse();
                settingUserInventoryRights GetDeptBranchbyUser = getDeptBranchbyUser();
                if (GetDeptBranchbyUser != null)
                {
                    model2.branchId = GetDeptBranchbyUser.branchId;
                    model2.departmentId = GetDeptBranchbyUser.departmentId;
                }
                else
                {
                    model2.branchId = getDemandMaster.branchId;
                    model2.departmentId = getDemandMaster.departmentId;
                }
                model2.Date = (DateTime)getDemandMaster.demandDate;
                model2.itemId = item.itemId;
                model2.unitId = item.unitId;
                model2.qty = item.qty;
                model2.rate = item.balance;
                model2.AvgRate = item.balance;
                //model2.Desc = DemMaster.desc;
                //model2.amount = DemMaster.totalAmount;
                model2.ExpiryDate = DateTime.Now.AddDays(90);
                model2.dateTime = DateTime.Now;
                // model2.Desc = DemMaster.desc;
                model2.workStation = getDemandMaster.workStation;
                model2.VoucherId = getDemandMaster.demand_Id;

                _context.invWareHouse.Add(model2);
            }
            added = _context.SaveChanges();
            return added;
        }
        public int EditDemandDetail(int demand_Id, invDemandDetail RecValues, int added)
        {
            var ifExist = _context.invDemandDetail.Where(x => x.demand_Id == demand_Id).FirstOrDefault();

            ifExist.qty = RecValues.qty;
            ifExist.balance = RecValues.balance;
            ifExist.stock = RecValues.stock;
            added = _context.SaveChanges();
            return added;
        }
        #endregion

        #region InvPurchaseMasterDetail
        public InvPurchaseOrderViewModel IndexInvPurchaseOrder(InvPurchaseOrderViewModel viewmodel)
        {
            var IfExist = _context.invPurchaseOrderMaster.ToList();
            var IfExist1 = _context.settingDepartment.ToList();
            var IfExist2 = _context.settingBranch.ToList();
            var IfExist3 = _context.Supplier.ToList();

            viewmodel = new InvPurchaseOrderViewModel()
            {
                PurchaseOrderMasterList = IfExist,
                settingDepartments = IfExist1,
                settingBranches = IfExist2,
                Supplier = IfExist3
            };
            return viewmodel;
        }
        public InvPurchaseOrderViewModel InvPurchaseDetails(int poId, InvPurchaseOrderViewModel viewmodel)
        {
            var List = _context.invPurchaseOrderDetail.Where(x => x.poId == poId).ToList();
            var IfExist1 = _context.settingDepartment.ToList();
            var IfExist2 = _context.settingBranch.ToList();
            viewmodel = new InvPurchaseOrderViewModel()
            {
                PurchaseOrderDetailList = List,
                settingDepartments = IfExist1,
                settingBranches = IfExist2
            };
            return viewmodel;
        }
        public InvPurchaseOrderViewModel InvPurchaseOrderMasterDetail(InvPurchaseOrderViewModel viewModel)
        {
            settingUserInventoryRights user = getDeptBranchbyUser();
            if (user.UserType == "Admin")
            {
                viewModel = new InvPurchaseOrderViewModel()
                {
                    settingBranches = _context.settingBranch.ToList(),
                    settingDepartments = _context.settingDepartment.ToList(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    Supplier = _context.Supplier.ToList(),
                    UserType = user.UserType,
                    code = MasterDetailController.poCode

                };
                return viewModel;
            }
            else 
            {
                viewModel = new InvPurchaseOrderViewModel()
                {
                    settingBr = _context.settingBranch.Where(x => x.branchId == branchId).FirstOrDefault(),
                    settingDept = _context.settingDepartment.Where(x => x.departmentId == departmentId).FirstOrDefault(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    Supplier = _context.Supplier.ToList(),
                    poDate = DateTime.Now,
                    code = MasterDetailController.poCode

                };
                return viewModel;
            }
        }
        public int InvPurchaseOrderMasterDetailPost(invPurchaseOrderMaster OrderMasterArray, List<invPurchaseOrderDetail> OrderDetailArray, int added)
        {
            settingUserInventoryRights GetDeptBranchbyUser = getDeptBranchbyUser();
            invPurchaseOrderMaster model = new invPurchaseOrderMaster();
            if (GetDeptBranchbyUser != null)
            {
                model.branchId = GetDeptBranchbyUser.branchId;
                model.departmentId = GetDeptBranchbyUser.departmentId;
            }
            else
            {
                model.branchId = OrderMasterArray.branchId;
                model.departmentId = OrderMasterArray.departmentId;
            }
            model.SPId = OrderMasterArray.SPId;
            model.poId = OrderMasterArray.poId;
            model.poNo = OrderMasterArray.poNo;
            model.poDate = OrderMasterArray.poDate;
            model.desc = OrderMasterArray.desc;
            model.status = OrderMasterArray.status;
            model.dateTime = DateTime.Now;
            model.workStation = OrderMasterArray.workStation;
            model.isPost = OrderMasterArray.isPost;

            _context.invPurchaseOrderMaster.Add(model);
            _context.SaveChanges();
            foreach (var item in OrderDetailArray)
            {
                invPurchaseOrderDetail model2 = new invPurchaseOrderDetail();
                model2.itemId = item.itemId;
                model2.unitId = item.unitId;
                model2.qty = item.qty;
                model2.rate = item.rate;
                model2.stock = item.stock;
                model2.grnQty = item.grnQty;
                model2.isActive = item.isActive;
                model2.status = item.status;
                model2.poId = model.poId;

                _context.invPurchaseOrderDetail.Add(model2);
            }
            added = _context.SaveChanges();
            return added;
        }

        public int EditPurhaseOrderDetail(int poId, invPurchaseOrderDetail RecValues)
        {
            var ifExist = _context.invPurchaseOrderDetail.Where(x => x.poId == poId).FirstOrDefault();

            ifExist.qty = RecValues.qty;
            ifExist.rate = RecValues.rate;
            ifExist.stock = RecValues.stock;
            ifExist.grnQty = RecValues.grnQty;
            ifExist.isActive = RecValues.isActive;
            ifExist.status = RecValues.status;
            _context.SaveChanges();
            return poId;
        }

        #endregion

        #region GRNMasterDetail
        public InvGRNViewModel IndexInvGRN(InvGRNViewModel viewmodel)
        {
            var IfExist = _context.invGRNMaster.ToList();
            var IfExist1 = _context.settingDepartment.ToList();
            var IfExist2 = _context.settingBranch.ToList();
            var IfExist3 = _context.Supplier.ToList();


            viewmodel = new InvGRNViewModel()
            {
                invGRNMasterList = IfExist,
                settingDepartments = IfExist1,
                settingBranches = IfExist2,
                Supplier = IfExist3,

            };
            return viewmodel;
        }

        public InvGRNViewModel InvGRNMasterDetail(InvGRNViewModel viewmodel)
        {
            settingUserInventoryRights getBranchDeptbyUser = getDeptBranchbyUser();
            var ifexist = _context.Supplier.ToList();
            var ifexist2 = _context.settingBranch.ToList();
            var ifexist3 = _context.settingDepartment.ToList();
            var ifexist4 = _context.SettingItem.ToList();
            var ifexist5 = _context.settingUnit.ToList();
            var ifexist6 = _context.invPurchaseOrderMaster.Where(x => x.poId == 0).FirstOrDefault();
            if (getBranchDeptbyUser.UserType == "Admin")
            {
                viewmodel = new InvGRNViewModel()
                {
                    Supplier = ifexist,
                    settingBranches = ifexist2,
                    settingDepartments = ifexist3,
                    settingItems = ifexist4,
                    settingUnit = ifexist5,
                    invPurchaseOrderMaster = ifexist6,
                    UserType = getBranchDeptbyUser.UserType,
                    code = MasterDetailController.GrnCode

                };
                return viewmodel;
            }
            else 
            {
                viewmodel = new InvGRNViewModel()
                {
                    Supplier = ifexist,
                    settingBr = _context.settingBranch.Where(x => x.branchId == branchId).FirstOrDefault(),
                    settingDept = _context.settingDepartment.Where(x => x.departmentId == departmentId).FirstOrDefault(),
                    settingItems = ifexist4,
                    settingUnit = ifexist5,
                    invPurchaseOrderMaster = ifexist6,
                    grnDate = DateTime.Now,
                    code = MasterDetailController.GrnCode
                };
                return viewmodel;
            }
        }

        public Result InvGRNMasterDetailPost(invGRNMaster GRNMaster, List<invGRNDetail> GRNDetail, int added, int userId)
        {
            invGRNMaster model = new invGRNMaster();
            settingUserInventoryRights GetDeptBranchbyUser = getDeptBranchbyUser();
            if (GetDeptBranchbyUser != null)
            {
                model.branchId = GetDeptBranchbyUser.branchId;
                model.departmentId = GetDeptBranchbyUser.departmentId;
            }
            else
            {
                model.branchId = GRNMaster.branchId;
                model.departmentId = GRNMaster.departmentId;
            }
            model.grnDate = GRNMaster.grnDate;
            model.grnNo = GRNMaster.grnNo;
            model.SPId = GRNMaster.SPId;
            model.referenceNo = GRNMaster.referenceNo;
            model.desc = GRNMaster.desc;
            model.dateTime = DateTime.Now;
            model.userId = userId;
            model.totalTax = GRNMaster.totalTax;
            model.discount = GRNMaster.discount;
            model.totalAmount = GRNMaster.totalAmount;

            _context.invGRNMaster.Add(model);
            _context.SaveChanges();
            foreach (var item in GRNDetail)
            {
                invGRNDetail model2 = new invGRNDetail();
                model2.itemId = item.itemId;
                model2.unitId = item.unitId;
                model2.qty = item.qty;
                model2.rate = item.rate;
                model2.tax = item.tax;
                model2.discount = item.discount;
                model2.actualRate = item.actualRate;
                model2.finalRate = item.finalRate;
                model2.poId = item.poId;
                model2.expiryDate = DateTime.Now.AddDays(90);
                model2.grnId = model.grnId;
                tempid = model2.grnId;//TempData["grnid"]

                _context.invGRNDetail.Add(model2);
            }

            added = _context.SaveChanges();

            var Result = new Result()
            {
                TempId = tempid,
                AddedRecord = added,
            };

            return Result;
        }
        public int InvGRNMasterDetailProceed(invGRNMaster GRNMaster, List<invGRNDetail> GRNDetail, int getGrnId, int added)
        {
            var update = _context.invGRNMaster.Where(x => x.grnId == getGrnId).FirstOrDefault();
            update.isPost = true;
            _context.SaveChanges();

            foreach (var item in GRNDetail)
            {
                invWareHouse model2 = new invWareHouse();
                settingUserInventoryRights GetDeptBranchbyUser = getDeptBranchbyUser();
                if (GetDeptBranchbyUser != null)
                {
                    model2.branchId = GetDeptBranchbyUser.branchId;
                    model2.departmentId = GetDeptBranchbyUser.departmentId;
                }
                else
                {
                    model2.branchId = GRNMaster.branchId;
                    model2.departmentId = GRNMaster.departmentId;
                }
                model2.Date = (DateTime)update.grnDate;
                model2.itemId = item.itemId;
                model2.unitId = item.unitId;
                model2.qty = item.qty;
                model2.rate = item.rate;
                model2.AvgRate = item.actualRate;
                model2.Desc = GRNMaster.desc;
                model2.amount = GRNMaster.totalAmount;
                model2.ExpiryDate = DateTime.Now.AddDays(90);
                model2.dateTime = DateTime.Now;
                model2.Desc = GRNMaster.desc;
                model2.workStation = GRNMaster.workStation;
                model2.VoucherId = update.grnId;

                _context.invWareHouse.Add(model2);
            }
            added = _context.SaveChanges();
            return added;
        }
       
        public InvGRNViewModel InvGRNDetails(int grnId, InvGRNViewModel viewmodel)
        {
            var List = _context.invGRNDetail.Where(x => x.grnId == grnId).ToList();
            var IfExist1 = _context.SettingItem.ToList();
            var IfExist2 = _context.settingUnit.ToList();
            viewmodel = new InvGRNViewModel()
            {
                invGRNDetailList = List,
                settingItems = IfExist1,
                settingUnit = IfExist2
            };
            return viewmodel;
        }
        public InvGRNViewModel PV_grnPoWiseDetail(int poId, InvGRNViewModel viewmodel)
        {
            var itemList = _context.SettingItem.ToList();
            var unitList = _context.settingUnit.ToList();
            var getP = _context.invPurchaseOrderMaster.Where(x => x.poId == poId).FirstOrDefault();
            var poid = getP.poId;
            viewmodel = new InvGRNViewModel()
            {
                settingUnit = unitList,
                settingItems = itemList,
                invGRNViewModels = GRNListForInsert().Where(x => x.poId == poId).ToList()

            };
            return viewmodel;
        }
        public List<InvGRNViewModel> GRNListForInsert()
        {
            var Lista = (from ipm in _context.invPurchaseOrderMaster
                         join ipd in _context.invPurchaseOrderDetail on ipm.poId equals ipd.poId
                         join i in _context.SettingItem on ipd.itemId equals i.itemId
                         join u in _context.settingUnit on ipd.unitId equals u.unitId
                         join d in _context.settingDepartment on ipm.departmentId equals d.departmentId
                         select new InvGRNViewModel()
                         {
                             poId = ipm.poId,
                             itemId = i.itemId,
                             itemName = i.itemName,
                             unitId = u.unitId,
                             unitName = u.unitName,
                             departmentId = d.departmentId,
                             departmentName = d.departmentName
                         }).ToList();
            return Lista;
        }
        #endregion

        #region RecipeMethods
        public InvRecipeViewModel InvRecipeMasterDetail(InvRecipeViewModel viewModel)
        {
            settingUserInventoryRights GetDeptBranchbyUser = getDeptBranchbyUser();
            if (GetDeptBranchbyUser.UserType == "Admin")
            {
                viewModel = new InvRecipeViewModel()
                {
                    settingItem = _context.SettingItem.ToList(),
                    UserType = GetDeptBranchbyUser.UserType
                };
                return viewModel;
            }
            else 
            {
                viewModel = new InvRecipeViewModel()
                {
                    settingItem = _context.SettingItem.ToList(),
                    dateTime = DateTime.Now
                };
                return viewModel;
            }           
        }
        public int InvRecipeMasterDetailPost(invRecipeMaster RecipeMasterArray, List<invRecipeDetail> RecipeDetailArray, int added)
        {
            invRecipeMaster model = new invRecipeMaster();
            model.RecipeId = RecipeMasterArray.RecipeId;
            model.dateTime = RecipeMasterArray.dateTime;
            model.Workstation = RecipeMasterArray.Workstation;
            model.Comments = RecipeMasterArray.Comments;
            model.isSubRecipe = RecipeMasterArray.isSubRecipe;
            _context.invRecipeMaster.Add(model);
            _context.SaveChanges();
            foreach (var item in RecipeDetailArray)
            {
                invRecipeDetail model2 = new invRecipeDetail();
                model2.IngredientId = item.IngredientId;
                model2.Qty = item.Qty;
                model2.RecipeId = model.RecipeId;
                _context.invRecipeDetail.Add(model2);
            }
            added = _context.SaveChanges();
            return added;
        }
        #endregion




    }
}