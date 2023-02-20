using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using WebInventoryProject.ModelFactory;
using WebInventoryProject.Models;
using WebInventoryProject.ViewModel;
using static WebInventoryProject.ViewModel.InvMasterDetailViewModel;

namespace WebInventoryProject.Controllers
{
    //An error occures while updating entires Means you are not sending a Foreign key (5*)
    //which is Required  // opened on 16 My 2022
    public class MasterDetailController : Controller
    {
        public static string Demcode;
        public static string poCode;
        public static string GrnCode;
        public static string IssCode;
        public static string PrCode;
        public static string TrCode;


        public static SqlConnection con;
        public void connection()
        {
            string constr = "Data Source=DESKTOP-NL5BG7N;Initial Catalog= WebInventoryProjectUpdated;uid = sa;pwd = sa123;";//ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            con = new SqlConnection(constr);

        }

        public string GetDemandCode()//go to nuget package and install Dapper package
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                //orderPunchingForm.connection();
                con.Open();
                Demcode = con.ExecuteScalar("GetDemandCode", commandType: CommandType.StoredProcedure).ToString();
                if (Demcode != "")
                {
                    con.Close();
                    return Demcode;
                }
                else
                {
                    MessageBox.Show("No Demand Code Found From Procedure", "Messasge Alert");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messasge Alert");
                return null;
            }
        }

        public string GetPOCode()//go to nuget package and install Dapper package
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                //orderPunchingForm.connection();
                con.Open();
                poCode = con.ExecuteScalar("GetPOCode", commandType: CommandType.StoredProcedure).ToString();
                if (poCode != "")
                {
                    con.Close();
                    return poCode;
                }
                else
                {
                    MessageBox.Show("No Purchase Order Code Found From Procedure", "Messasge Alert");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messasge Alert");
                return null;
            }
        }

        public string GetGRNCode()//go to nuget package and install Dapper package
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                //orderPunchingForm.connection();
                con.Open();
                GrnCode = con.ExecuteScalar("GetGRNCode", commandType: CommandType.StoredProcedure).ToString();
                if (GrnCode != "")
                {
                    con.Close();
                    return GrnCode;
                }
                else
                {
                    MessageBox.Show("No Purchase Order Code Found From Procedure", "Messasge Alert");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messasge Alert");
                return null;
            }
        }

        public string GetIssuanceCode()//go to nuget package and install Dapper package
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                //orderPunchingForm.connection();
                con.Open();
                IssCode = con.ExecuteScalar("GetIssuanceCode", commandType: CommandType.StoredProcedure).ToString();
                if (IssCode != "")
                {
                    con.Close();
                    return IssCode;
                }
                else
                {
                    MessageBox.Show("No Purchase Order Code Found From Procedure", "Messasge Alert");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messasge Alert");
                return null;
            }
        }
        

        public string GetProductionCode()//go to nuget package and install Dapper package
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                //orderPunchingForm.connection();
                con.Open();
                PrCode = con.ExecuteScalar("GetProductionCode", commandType: CommandType.StoredProcedure).ToString();
                if (PrCode != "")
                {
                    con.Close();
                    return PrCode;
                }
                else
                {
                    MessageBox.Show("No Procedure Code Found From Procedure", "Messasge Alert");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messasge Alert");
                return null;
            }
        }
        public string GetTransferCode()//go to nuget package and install Dapper package
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                //orderPunchingForm.connection();
                con.Open();
                TrCode = con.ExecuteScalar("GetTransferCode", commandType: CommandType.StoredProcedure).ToString();
                if (IssCode != "")
                {
                    con.Close();
                    return TrCode;
                }
                else
                {
                    MessageBox.Show("No Transfer Code Found From Procedure", "Messasge Alert");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messasge Alert");
                return null;
            }
        }


        DbContextClass _context = new DbContextClass();
        MasterDetailmodelFacotry mfObj = new MasterDetailmodelFacotry();
        string result = "";
        int getGrnId;
        int getDemandId;
        int getIssId;
        int getIssReturnId;
        int getprId;
        int getwastageId;
        int getdiscardId;
        int saved = 0;
        public int added = 0;

        #region InvDemandMasterDetail
        // GET: MasterDetail

        //public List<InvDemandMasterDetail> InvDemandMasterDetails()
        //{
        //    var Lista = (from a in _context.invDemandDetail
        //                 join b in _context.invDemandMaster on a.demand_Id equals b.demand_Id 
        //                 join d in _context.settingDepartment on b.departmentId equals d.departmentId 
        //                 join br in _context.settingBranch on b.branchId equals br.branchId
        //                 join It in _context.SettingItem on a.itemId equals It.itemId
        //                 join U in _context.settingUnit on a.unitId equals U.unitId


        //                 select new InvDemandMasterDetail()
        //                 {
        //                     demand_Id = b.demand_Id,
        //                     demandDate = b.demandDate,
        //                     demandNo = b.demandNo,
        //                     branchId = b.branchId,
        //                     departmentId = b.departmentId,
        //                     departmentName = d.departmentName,
        //                     branchName = br.branchName,
        //                     userId = b.userId,
        //                     dateTime = b.dateTime,
        //                     isActive = b.isActive,
        //                     workStation = b.workStation,   
        //                     itemId = a.itemId,
        //                     unitId = a.unitId,
        //                     itemName = It.itemName,
        //                     unitName = U.unitName,
        //                     qty = a.qty,
        //                     balance = a.balance,                          
        //                     stock = a.stock


        //                 }).ToList();
        //    return Lista;
        //}

        public settingUserInventoryRights CheckUserRights()
        {
            var userId = WebInventoryProject.Controllers.UserController.UserId;
            var user = _context.settingUserInventoryRights.Where(x => x.userId == userId).FirstOrDefault();
            if (user != null){ return user;}
            return null;//user
        }
        public ActionResult Index()
        {
            var IfExist = _context.invDemandMaster.ToList();
            return View(IfExist);
        }
        public ActionResult InvDemandDetails(int demand_Id)
        {
            var List = _context.invDemandDetail.Where(x => x.demand_Id == demand_Id).ToList();
            return View(List);
        }
        public ActionResult InvDemandMasterDetail()
        {
            var user = CheckUserRights();
            
            if (user == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("Index", "MasterDetail");
            }
            connection();
            GetDemandCode();
            var viewModel = new InvMasterDetailViewModel();
            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            viewModel = obj.InvDemandMasterDetail(viewModel);
            return View(viewModel);

        }
        [HttpPost]
        public ActionResult InvDemandMasterDetail(invDemandMaster OrderMasterArray, List<invDemandDetail> OrderDetailArray)
        {
            int r = 0;
            
            if (r == 0)
            {
                if (OrderMasterArray == null || OrderDetailArray == null)
                {
                    result = "Error! Order Is Not Complete!";
                    return RedirectToAction("InvDemandMasterDetail", "MasterDetail");
                }
                r += 1;
            }
           
            using (DbContextTransaction dbTransaction = _context.Database
                .BeginTransaction())
            {
                if (Convert.ToInt32(TempData["demand_id"]) == 0)
                {
                    MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
                    Result result = obj.InvDemandMasterDetailPost(OrderMasterArray, OrderDetailArray, added);

                    if (result.AddedRecord > 0)
                    {
                        dbTransaction.Commit();
                        TempData["demand_id"] = result.TempId;
                        TempData["Success"] = "Added Successfully!";
                        return Json(added);
                    }
                    else
                    {
                        dbTransaction.Rollback();
                        TempData["Success"] = "Error! ForeignKeys Must be Missing";
                        return Json(added);
                    }
                }
                else
                {
                    getDemandId = Convert.ToInt32(TempData["demand_id"].ToString());
                    MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
                    added = obj.InvDemMasterDetailProceed(getDemandId, added);
                    if (added > 0)
                    {
                        dbTransaction.Commit();
                        TempData["Success"] = "Proceed Successfully !";
                        return RedirectToAction("IndexInvDemand", "MasterDetail");
                    }
                    else
                    {
                        dbTransaction.Rollback();
                        TempData["Success"] = "Not Proceed !";
                        return View();
                    }
                }
            }
        }
        [HttpPost]
        public ActionResult EditDemandDetail(int demand_Id, invDemandDetail RecValues)
        {

            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            added = obj.EditDemandDetail(demand_Id, RecValues, added);
            if (added > 0)
            {
                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Success"] = "Not Updated";
                return RedirectToAction("Index");
            }

        }
        #endregion

        #region InvPurchaseMasterDetail
        public ActionResult IndexInvPurchaseOrder()
        {
            var viewmodel = new InvPurchaseOrderViewModel();
            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            viewmodel = obj.IndexInvPurchaseOrder(viewmodel);
            return View(viewmodel);
        }
        public ActionResult InvPurchaseDetails(int poId)
        {
            var viewmodel = new InvPurchaseOrderViewModel();
            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            viewmodel = obj.InvPurchaseDetails(poId, viewmodel);
            return View(viewmodel);
        }
        public ActionResult InvPurchaseOrderMasterDetail()
        {
            var user = CheckUserRights();
            if (user == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("IndexInvPurchaseOrder", "MasterDetail");
            }
            connection();
            GetPOCode();
            var viewmodel = new InvPurchaseOrderViewModel();
            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            viewmodel = obj.InvPurchaseOrderMasterDetail(viewmodel);
            return View(viewmodel);
            //else
            //{

            //    var ifexist = _context.invPurchaseOrderMaster.Where(x => x.poId == poId).FirstOrDefault();
            //    var ifexist1 = _context.invPurchaseOrderDetail.Where(x => x.poId == poId).ToList();
            //    var viewModel = new InvPurchaseOrderViewModel()
            //    {
            //        invPurchaseOrderMaster = ifexist,
            //        PurchaseOrderDetailList = ifexist1,
            //        settingBranches = _context.settingBranch.ToList(),
            //        settingDepartments = _context.settingDepartment.ToList(),
            //        settingItems = _context.SettingItem.ToList(),
            //        settingUnit = _context.settingUnit.ToList(),
            //        Supplier = _context.Supplier.ToList()

            //    };
            //    return View(viewModel);
            //}
        }
        [HttpPost]
        public ActionResult InvPurchaseOrderMasterDetail(invPurchaseOrderMaster OrderMasterArray, List<invPurchaseOrderDetail> OrderDetailArray)
        {
            if (OrderMasterArray == null && OrderDetailArray == null)
            {
                result = "Error! Order Is Not Complete!";
                return RedirectToAction("InvPurchaseOrderMasterDetail", "MasterDetail");
            }
            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            added = obj.InvPurchaseOrderMasterDetailPost(OrderMasterArray, OrderDetailArray, added);

            if (added > 0)
            { TempData["Success"] = "Added Successfully!"; return Json(added); }
            else
                TempData["Success"] = "Not Added!";

            return View();


        }
        [HttpPost]
        public ActionResult EditPurhaseOrderDetail(int poId, invPurchaseOrderDetail RecValues)
        {
            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            added = obj.EditPurhaseOrderDetail(poId, RecValues);
            //check you need to add remaining fields like Modified by,Modified Date
            if (added > 0)
            {
                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("IndexInvPurchaseOrder", "MasterDetail");
            }
            else
                TempData["Success"] = "Not Updated";
            return View();
        }

        #endregion

        #region InvRecipeMasterDetail
        public ActionResult IndexInvRecipe()
        {
            var ifExist = _context.invRecipeMaster.ToList();
            return View(ifExist);
        }
        public ActionResult InvRecipeDetails(int RecipeId)
        {
            var List = _context.invRecipeDetail.Where(x => x.RecipeId == RecipeId).ToList();
            return View(List);
        }
        public ActionResult InvRecipeMasterDetail()
        {
            var user = CheckUserRights();
            if (user == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("IndexInvRecipe", "MasterDetail");
            }
            var viewModel = new InvRecipeViewModel();
            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            viewModel = obj.InvRecipeMasterDetail(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult InvRecipeMasterDetail(invRecipeMaster RecipeMasterArray, List<invRecipeDetail> RecipeDetailArray)
        {
            if (RecipeMasterArray == null && RecipeDetailArray == null)
            {
                result = "Error! Order Is Not Complete!";
                return RedirectToAction("InvRecipeMasterDetail", "MasterDetail");
            }

            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            added = obj.InvRecipeMasterDetailPost(RecipeMasterArray, RecipeDetailArray, added);

            if (added > 0)
            { TempData["Success"] = "Added Successfully!"; return Json(added); }
            else
                TempData["Success"] = "Error!"; return Json(added);
        }
        #endregion

        #region InvGRNMasterDetail
        [HttpGet]
        public ActionResult IndexInvGRN()//To get grn list
        {
            var viewmodel = new InvGRNViewModel();
            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            viewmodel = obj.IndexInvGRN(viewmodel);
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult InvGRNDetails(int grnId) // To edit grn details only
        {
            var viewmodel = new InvGRNViewModel();
            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            viewmodel = obj.InvGRNDetails(grnId, viewmodel);
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult InvGRNMasterDetail()// Create Master Detail View
        {
            var user = CheckUserRights();
            if (user == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("IndexInvPurchaseOrder", "MasterDetail");
            }
            connection();
            GetGRNCode();
            var viewmodel = new InvGRNViewModel();
            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            viewmodel = obj.InvGRNMasterDetail(viewmodel);
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult InvGRNMasterDetail(invGRNMaster GRNMaster, List<invGRNDetail> GRNDetail)//Post Master Detail View
        {
            if (GRNMaster == null || GRNDetail == null || Session["userId"] == null)
            {
                result = "Error! Order Is Not Complete!";
                return RedirectToAction("IndexInvGRN", "MasterDetail");
            }
            if (Convert.ToInt32(TempData["grnid"]) == 0)
            {

                var userId = int.Parse(Session["userId"].ToString());
                MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
                Result result = obj.InvGRNMasterDetailPost(GRNMaster, GRNDetail, added, userId);
                if (result.AddedRecord > 0)
                {
                    TempData["grnid"] = result.TempId;
                    TempData["Success"] = "Added Successfully!";
                    return Json(added);
                }
                return View();
            }
            else
            {
                getGrnId = Convert.ToInt32(TempData["grnid"].ToString());
                MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
                added = obj.InvGRNMasterDetailProceed(GRNMaster, GRNDetail, getGrnId, added);
                if (added > 0)
                {
                    TempData["Success"] = "Proceed Successfully !";
                    return RedirectToAction("IndexInvGRN","MasterDetail");
                }
                else
                    TempData["Success"] = "Not Proceed !";
            }
            return View();
        }



        [HttpPost]
        public ActionResult getPONObyVendor(int SPId)
        {
            var getPO = _context.invPurchaseOrderMaster.Where(x => x.SPId == SPId).ToList();
            ViewBag.POList = new SelectList(getPO, "poId", "poNo");
            return PartialView("PV_getPONoList");
        }

        public ActionResult PV_grnPoWiseDetail(int poId)
        {
            var viewmodel = new InvGRNViewModel();
            MasterDetailmodelFacotry obj = new MasterDetailmodelFacotry();
            viewmodel = obj.PV_grnPoWiseDetail(poId, viewmodel);
            return PartialView("PV_grnPoWiseDetail", viewmodel);
        }
        #endregion

        #region InvTransferMasterDetail

        public ActionResult IndexInvTransfer()
        {

            var IfExist = _context.invTransferMaster.ToList();
            return View(IfExist);
        }
        public ActionResult InvTransferDetails(int trId)
        {
            var List = _context.invTransferDetail.Where(x => x.trId == trId).ToList();
            return View(List);
        }
        public ActionResult InvTransferMasterDetail()
        {
            var user = CheckUserRights();
            if (user == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("IndexInvPurchaseOrder", "MasterDetail");
            }
            connection();
            GetTransferCode();
            if (user.UserType == "Admin")
            {
                var viewModel = new InvTransferMasterDetailViewModel()
                {
                    settingBranches = _context.settingBranch.ToList(),
                    settingDepartments = _context.settingDepartment.ToList(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    UserType = user.UserType,
                    code = MasterDetailController.TrCode
                    

                };
                return View(viewModel);
            }
            else {
                var viewModel = new InvTransferMasterDetailViewModel()
                {
                    settingBr = _context.settingBranch.Where(x => x.branchId == user.branchId).FirstOrDefault(),
                    settingDept = _context.settingDepartment.Where(x => x.departmentId == user.departmentId).FirstOrDefault(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    date = DateTime.Now,
                    code = MasterDetailController.TrCode

                };
                return View(viewModel);
            }


        }
        [HttpPost]
        public ActionResult InvTransferMasterDetail(invTransferMaster MasterArray, List<invTransferDetail> DetailArray)
        {
            try
            {
                var user = CheckUserRights();

                if (Session["userId"] == null)
                {
                    return RedirectToAction("Index", "Accounts");
                }
                if (MasterArray == null || DetailArray == null)
                {
                    result = "Error! Order Is Not Complete!";
                    return RedirectToAction("InvDemandMasterDetail", "MasterDetail");
                }


                invTransferMaster model = new invTransferMaster();
                var date = MasterArray.trDate.ToShortDateString();
                var date1 = DateTime.Now.ToShortDateString();

                model.trNo = MasterArray.trNo;
                model.trDate = Convert.ToDateTime(date);
                model.fromBranchId = MasterArray.fromBranchId;
                model.toBranchId = MasterArray.toBranchId;
                model.fromDepartmentId = MasterArray.fromDepartmentId;
                model.toDepartmentId = MasterArray.toDepartmentId;

                if (user != null)
                {
                    model.toBranchId = user.branchId;
                    model.fromBranchId = user.branchId;
                    model.toDepartmentId = user.departmentId;
                    model.fromDepartmentId = user.departmentId;
                }
                else
                {
                    model.toBranchId = MasterArray.toBranchId;
                    model.fromBranchId = MasterArray.fromBranchId;
                    model.toDepartmentId = MasterArray.toDepartmentId;
                    model.fromDepartmentId = MasterArray.fromDepartmentId;

                    //model.BranchId = MasterArray.BranchId;
                    //model.DepartmentId = MasterArray.DepartmentId;
                }

                model.dateTime = Convert.ToDateTime(date1);
                model.modifiedBy = 2;//what should i do here it needs id when inserting ForeignKey5
                model.isReceive = MasterArray.isReceive;
                model.userId = int.Parse(Session["userId"].ToString());
                _context.invTransferMaster.Add(model);
                _context.SaveChanges();
                foreach (var item in DetailArray)
                {
                    invTransferDetail model2 = new invTransferDetail();
                    model2.itemId = item.itemId;
                    model2.unitId = item.unitId;
                    model2.qty = item.qty;
                    model2.rate = item.rate;
                    model2.trId = model.trId;

                    _context.invTransferDetail.Add(model2);
                }
            }
            catch (Exception)
            { }
            var added = _context.SaveChanges();
            if (added > 0)
            {
                TempData["Success"] = "Added Successfully!";
                return Json(added);
            }
            else
            {
                TempData["Success"] = "Error!";
                return Json(added);
                return Json(added);
            }

        }
        [HttpPost]
        public ActionResult EditTransferDetail(int trId, invTransferDetail RecValues)
        {
            var ifExist = _context.invTransferDetail.Where(x => x.trId == trId).FirstOrDefault();

            ifExist.qty = RecValues.qty;
            ifExist.rate = RecValues.rate;
            _context.SaveChanges();
            TempData["Success"] = "Updated Successfully";
            return RedirectToAction("IndexInvTransfer");
        }
        #endregion

        #region InvOpeningMasterDetail

        public ActionResult IndexInvOpening()
        {

            var IfExist = _context.invOpeningMaster.ToList();
            return View(IfExist);
        }
        public ActionResult InvOpeningDetails(int openInvId)
        {
            var List = _context.invOpeningDetail.Where(x => x.openInvId == openInvId).ToList();
            return View(List);
        }
        public ActionResult InvOpeningMasterDetail(int openInvId = 0)
        {
            var user = CheckUserRights();
            if (user == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("IndexInvPurchaseOrder", "MasterDetail");
            }
            if (user.UserType == "Admin")
            {
                var viewModel = new invOpeningMasterDetailViewModel()
                {
                    settingBranches = _context.settingBranch.ToList(),
                    settingDepartments = _context.settingDepartment.ToList(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    UserType = user.UserType
                };
                return View(viewModel);
            }
            else
            {
                var viewModel = new invOpeningMasterDetailViewModel()
                {
                    settingBr = _context.settingBranch.Where(x => x.branchId == user.branchId).FirstOrDefault(),
                    settingDept = _context.settingDepartment.Where(x => x.departmentId == user.departmentId).FirstOrDefault(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    date = DateTime.Now

                };

                return View(viewModel);
            }

        }
        [HttpPost]
        public ActionResult InvOpeningMasterDetail(invOpeningMaster MasterArray, List<invOpeningDetail> DetailArray)
        {
            try
            {
                var user = CheckUserRights();
                if (Session["userId"] == null)
                {
                    return RedirectToAction("Index", "Accounts");
                }
                if (MasterArray == null || DetailArray == null)
                {
                    result = "Error! Order Is Not Complete!";
                    return RedirectToAction("InvOpeningMasterDetail", "MasterDetail");
                }

                invOpeningMaster model = new invOpeningMaster();
                var date = MasterArray.date.ToShortDateString();
                var date1 = DateTime.Now.ToShortDateString();
                model.date = Convert.ToDateTime(date);
                model.BranchId = MasterArray.BranchId;
                model.DepartmentId = MasterArray.DepartmentId;
                if (user != null)
                {
                    model.BranchId = user.branchId;
                    model.DepartmentId = user.departmentId;
                }
                else
                {
                    model.BranchId = MasterArray.BranchId;
                    model.DepartmentId = MasterArray.DepartmentId;
                }
                model.dateTime = Convert.ToDateTime(date1);
                model.modifiedBy = 2;//what should i do here it needs id when inserting ForeignKey5                
                model.userId = int.Parse(Session["userId"].ToString());
                _context.invOpeningMaster.Add(model);
                _context.SaveChanges();
                foreach (var item in DetailArray)
                {
                    invOpeningDetail model2 = new invOpeningDetail();
                    model2.itemId = item.itemId;
                    model2.unitId = item.unitId;
                    model2.qty = item.qty;
                    model2.rate = item.rate;
                    model2.openInvId = model.openInvId;

                    _context.invOpeningDetail.Add(model2);
                }
            }
            catch (Exception)
            { }
            var added = _context.SaveChanges();
            if (added > 0)
            {
                TempData["Success"] = "Added Successfully!";
                return Json(added);
            }
            else
            {
                TempData["Error"] = "Error!";
                return Json(added);
            }

        }
        [HttpPost]
        public ActionResult EditOpeningDetail(int openInvId, invOpeningDetail RecValues)
        {
            var ifExist = _context.invOpeningDetail.Where(x => x.openInvId == openInvId).FirstOrDefault();

            ifExist.qty = RecValues.qty;
            ifExist.rate = RecValues.rate;
            _context.SaveChanges();
            TempData["Success"] = "Updated Successfully";
            return RedirectToAction("IndexInvOpening");
        }
        #endregion

        #region InvPhysicalStockMasterDetail

        public ActionResult IndexInvPhysicalStock()
        {

            var IfExist = _context.invPhysicalStockMaster.ToList();
            return View(IfExist);
        }
        public ActionResult InvPhysicalStockDetails(int psId)
        {
            var List = _context.invPhysicalStockDetail.Where(x => x.psId == psId).ToList();
            return View(List);
        }
        public ActionResult InvPhysicalStockMasterDetail()
        {
            var user = CheckUserRights();
            if (user == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("InvPhysicalStockMasterDetail", "MasterDetail");
            }
            if (user.UserType == "Admin")
            {
                var viewModel = new invPhysicalStockMasterDetailViewModel()
                {
                    settingBranches = _context.settingBranch.ToList(),
                    settingDepartments = _context.settingDepartment.ToList(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    UserType = user.UserType
                };
                return View(viewModel);
            }
            else
            {
                settingUserInventoryRights getDeptnBr = mfObj.getDeptBranchbyUser();
                var viewModel = new invPhysicalStockMasterDetailViewModel()
                {
                    settingBr = _context.settingBranch.Where(x => x.branchId == getDeptnBr.branchId).FirstOrDefault(),
                    settingDept = _context.settingDepartment.Where(x => x.departmentId == getDeptnBr.departmentId).FirstOrDefault(),
                    settingItems = _context.SettingItem.ToList(),
                    psDate = DateTime.Now,
                    settingUnit = _context.settingUnit.ToList(),

                };
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult InvPhysicalStockMasterDetail(invPhysicalStockMaster MasterArray, List<invPhysicalStockDetail> DetailArray)
        {
            try
            {
                if (Session["userId"] == null)
                {
                    return RedirectToAction("SignUpUser", "User");
                }
                if (MasterArray == null || DetailArray == null)
                {
                    result = "Error! Order Is Not Complete!";
                    return RedirectToAction("InvPhysicalStockMasterDetail", "MasterDetail");
                }
                var user = mfObj.getDeptBranchbyUser();
                invPhysicalStockMaster model = new invPhysicalStockMaster();
                var date = MasterArray.psDate.ToShortDateString();
                var date1 = DateTime.Now.ToShortDateString();
                model.psDate = Convert.ToDateTime(date);
                model.psNo = MasterArray.psNo;
                if (user != null)
                {
                    model.BranchId = user.branchId;
                    model.DepartmentId = user.departmentId;
                }
                else
                {
                    model.BranchId = MasterArray.BranchId;
                    model.DepartmentId = MasterArray.DepartmentId;
                }
                model.dateTime = Convert.ToDateTime(date1);
                model.modifiedBy = 2;//what should i do here it needs id when inserting ForeignKey5                
                model.userId = int.Parse(Session["userId"].ToString());
                _context.invPhysicalStockMaster.Add(model);
                _context.SaveChanges();
                foreach (var item in DetailArray)
                {
                    invPhysicalStockDetail model2 = new invPhysicalStockDetail();
                    model2.itemId = item.itemId;
                    model2.unitId = item.unitId;
                    model2.qty = item.qty;
                    model2.rate = item.rate;
                    model2.psId = model.psId;

                    _context.invPhysicalStockDetail.Add(model2);
                }
            }
            catch (Exception)
            { }
            var added = _context.SaveChanges();
            if (added > 0)
            {
                TempData["Success"] = "Added Successfully!";
                return Json(added);
            }
            else
            {
                TempData["Error"] = "Error!";
                return Json(added);
            }

        }
        [HttpPost]
        public ActionResult EditPhysicalStockDetail(int psId, invOpeningDetail RecValues)
        {
            var ifExist = _context.invPhysicalStockDetail.Where(x => x.psId == psId).FirstOrDefault();

            ifExist.qty = RecValues.qty;
            ifExist.rate = RecValues.rate;
            var inserted = _context.SaveChanges();
            if (inserted > 0)
            {
                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("IndexInvPhysicalStock");
            }
            else 
            {
                TempData["Error"] = "Not Updated";
                return RedirectToAction("IndexInvPhysicalStock");
            }
           
        }
        #endregion

        #region InvDirectPurchaseMasterDetail

        public ActionResult IndexInvDirectPurchase()
        {

            var IfExist = _context.invDirectPurchaseMaster.ToList();
            return View(IfExist);
        }
        public ActionResult InvDirectPurchaseDetails(int directPurchaseId)
        {
            var List = _context.invDirectPurchaseDetail.Where(x => x.directPurchaseId == directPurchaseId).ToList();
            return View(List);
        }
        public ActionResult InvDirectPurchaseMasterDetail()
        {
            var user = CheckUserRights();
            if (user == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("Index", "IndexInvDiscard");
            }
            if (user.UserType == "Admin")
            {
                var viewModel = new invDirectPurchaseMasterDetailViewModel()
                {
                    settingBranches = _context.settingBranch.ToList(),
                    settingDepartments = _context.settingDepartment.ToList(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    UserType = user.UserType
                };
                return View(viewModel);
            }
            else 
            {
                settingUserInventoryRights getDeptnBr = mfObj.getDeptBranchbyUser();
                var viewModel = new invDirectPurchaseMasterDetailViewModel()
                {
                    settingBr = _context.settingBranch.Where(x => x.branchId == getDeptnBr.branchId).FirstOrDefault(),
                    settingDept = _context.settingDepartment.Where(x => x.departmentId == getDeptnBr.departmentId).FirstOrDefault(),
                    settingItems = _context.SettingItem.ToList(),
                    directPurchaseDate = DateTime.Now,
                    settingUnit = _context.settingUnit.ToList()

                };
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult InvDirectPurchaseMasterDetail(invDirectPurchaseMaster MasterArray, List<invDirectPurchaseDetail> DetailArray)
        {
            try
            {

                if (Session["userId"] == null)
                {
                    return RedirectToAction("SingUp", "User");
                }
                if (MasterArray == null || DetailArray == null)
                {
                    result = "Error! Order Is Not Complete!";
                    return RedirectToAction("InvPhysicalStockMasterDetail", "MasterDetail");
                }
                var user = mfObj.getDeptBranchbyUser();
                using (DbContextTransaction transaction = _context.Database.BeginTransaction())
                {
                    invDirectPurchaseMaster model = new invDirectPurchaseMaster();
                    var date = MasterArray.directPurchaseDate.ToShortDateString();
                    var date1 = DateTime.Now.ToShortDateString();
                    model.directPurchaseDate = Convert.ToDateTime(date);
                    model.directPurchaseNo = MasterArray.directPurchaseNo;
                    
                    if (user != null)
                    {
                        model.BranchId = user.branchId;
                        model.DepartmentId = user.departmentId;
                    }
                    else
                    {
                        model.BranchId = MasterArray.BranchId;
                        model.DepartmentId = MasterArray.DepartmentId;
                    }
                    model.dateTime = Convert.ToDateTime(date1);
                    model.modifiedBy = 2;//what should i do here it needs id when inserting ForeignKey5                
                    model.userId = int.Parse(Session["userId"].ToString());
                    model.postUserId = int.Parse(Session["userId"].ToString());
                    _context.invDirectPurchaseMaster.Add(model);
                    _context.SaveChanges();
                    foreach (var item in DetailArray)
                    {
                        invDirectPurchaseDetail model2 = new invDirectPurchaseDetail();
                        model2.itemId = item.itemId;
                        model2.unitId = item.unitId;
                        model2.qty = item.qty;
                        model2.rate = item.rate;
                        model2.directPurchaseId = model.directPurchaseId;

                        _context.invDirectPurchaseDetail.Add(model2);
                    }

                    var added = _context.SaveChanges();
                    if (added > 0)
                    {
                        TempData["Success"] = "Added Successfully!";
                        transaction.Commit();
                        return Json(added);
                    }
                    else
                    {
                        TempData["Error"] = "Error!";
                        transaction.Rollback();
                        return Json(added);
                    }
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                return View();
            
            }
        }  
        
        [HttpPost]
        public ActionResult EditDirectPurchaseDetail(int directPurchaseId, invDirectPurchaseDetail RecValues)
        {
            var ifExist = _context.invDirectPurchaseDetail.Where(x => x.directPurchaseId == directPurchaseId).FirstOrDefault();

            ifExist.qty = RecValues.qty;
            ifExist.rate = RecValues.rate;
            _context.SaveChanges();
            TempData["Success"] = "Updated Successfully";
            return RedirectToAction("IndexInvPhysicalStock");
        }
        #endregion

        #region InvIssuanceMasterDetail

        public ActionResult IndexInvIssuance()
        {
            var IfExist = _context.invIssuanceMaster.ToList();
            return View(IfExist);
        }

        public ActionResult InvIssuanceDetails(int issuanceId)
        {
            var List = _context.invIssuanceDetail.Where(x => x.issuanceId == issuanceId).ToList();
            return View(List);
        }
        public List<DemandList> invDirectItemList()
        {
            var List = (from a in _context.SettingItem
                        join b in _context.settingUnit on a.purchaseUnitId equals b.unitId
                        select new DemandList
                        {
                            ItemId = a.itemId,
                            unitId = b.unitId,
                            unitName = b.unitName,
                            ItemName = a.itemName
                        }).ToList();
            return List;
        }
        public PartialViewResult LoadDetailModal()
        {
            var viewModel = new InvMasterDetailViewModel()
            {
                DemandLists = invDirectItemList()
            };
            return PartialView("Pv_DirectDetails", viewModel);

        }
        public virtual invIssuanceMasterDetailViewModel GetinvIssViewModel(string UserType) 
        {
            var viewModel = new invIssuanceMasterDetailViewModel()
            {
                settingBranches = _context.settingBranch.ToList(),
                settingDepartments = _context.settingDepartment.ToList(),
                settingItems = _context.SettingItem.ToList(),
                settingUnit = _context.settingUnit.ToList(),
                invDemandMaster = _context.invDemandMaster.ToList(),
                UserType = UserType,
                code = MasterDetailController.IssCode


            };
            return viewModel;
        }   
        public  invIssuanceMasterDetailViewModel GetinvIssViewM() 
        {
            var viewModel = new invIssuanceMasterDetailViewModel()
            {
                settingBranches = _context.settingBranch.ToList(),
                settingDepartments = _context.settingDepartment.ToList(),
                settingItems = _context.SettingItem.ToList(),
                settingUnit = _context.settingUnit.ToList(),
                invDemandMaster = _context.invDemandMaster.ToList(),
                issuanceDate = DateTime.Now,
                code = MasterDetailController.IssCode
            };
            return viewModel;
        }
        [HttpGet]
        public ActionResult InvIssuanceMasterDetail()
        {
            settingUserInventoryRights GetDeptBranchbyUser = CheckUserRights();
            if (GetDeptBranchbyUser == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("IndexInvIssuance", "MasterDetail");
            }
            connection();
            GetIssuanceCode();
            if (GetDeptBranchbyUser.UserType == "Admin")
            {
                var viewModel = GetinvIssViewModel(GetDeptBranchbyUser.UserType);
                return View(viewModel);
            }
            else 
            {
                var viewModel = GetinvIssViewM();
                return View(viewModel);
            }
        } //check why we are not geting demandid

        [HttpPost]
        public ActionResult InvIssuanceMasterDetail(invIssuanceMaster MasterArray, List<invIssuanceDetail> DetailArray)
        {
            using (DbContextTransaction dbTransaction = _context.Database
              .BeginTransaction())
            {
                try
                {
                    if (Session["userId"] == null)
                    {
                        return RedirectToAction("SignUp", "User");
                    }
                    if (MasterArray == null || DetailArray == null)
                    {
                        result = "Error! Order Is Not Complete!";
                        return RedirectToAction("InvIssuanceMasterDetail", "MasterDetail");
                    }
                    if (Convert.ToInt32(TempData["issuanceId"]) == 0)
                    {
                        invIssuanceMaster model = new invIssuanceMaster();

                        var date1 = DateTime.Now.ToShortDateString();
                        model.issuanceNo = MasterArray.issuanceNo;
                        model.issuanceDate = MasterArray.issuanceDate;
                        model.fromBranchId = MasterArray.fromBranchId;
                        model.toBranchId = MasterArray.toBranchId;
                        model.fromDepartmentId = MasterArray.fromDepartmentId;
                        model.toDepartmentId = MasterArray.toDepartmentId;
                        model.dateTime = Convert.ToDateTime(date1);
                        model.modifiedBy = 2;//what should i do here it needs id when inserting ForeignKey5
                        model.isReceive = MasterArray.isReceive;
                        model.userId = int.Parse(Session["userId"].ToString());
                        _context.invIssuanceMaster.Add(model);
                        _context.SaveChanges();
                        foreach (var item in DetailArray)
                        {
                            invIssuanceDetail model2 = new invIssuanceDetail();
                            model2.itemId = item.itemId;
                            model2.unitId = item.unitId;
                            model2.qty = item.qty;
                            model2.rate = item.rate;
                            model2.demandId = item.demandId;
                            model2.issuanceId = model.issuanceId;
                            TempData["issuanceId"] = model.issuanceId;
                            _context.invIssuanceDetail.Add(model2);
                        }
                        var added = _context.SaveChanges();
                        if (added > 0)
                        {
                            dbTransaction.Commit();
                            TempData["Success"] = "Added Successfully!";
                            //return Json(added);
                            return RedirectToAction("IndexInvIssuance", "MasterDetail");
                        }
                        else
                        {
                            dbTransaction.Rollback();
                            TempData["Error"] = "Error!";
                            //return Json(added);
                            return RedirectToAction("IndexInvIssuance", "MasterDetail");
                        }

                    }
                    else
                    {
                        getIssId = Convert.ToInt32(TempData["issuanceId"].ToString());
                        var update = _context.invIssuanceMaster.Where(x => x.issuanceId == getIssId).FirstOrDefault();
                        update.isPost = true;
                        _context.SaveChanges();

                        foreach (var item in DetailArray)
                        {
                            invWareHouse model2 = new invWareHouse();
                            model2.Date = MasterArray.issuanceDate;
                            model2.itemId = item.itemId;
                            model2.unitId = item.unitId;
                            model2.qty = item.qty;
                            model2.rate = item.rate;
                            model2.branchId = MasterArray.toBranchId;
                            model2.departmentId = MasterArray.toDepartmentId;
                            model2.Type = "Inn";
                            model2.dateTime = DateTime.Now;
                            model2.VoucherId = update.issuanceId;

                            _context.invWareHouse.Add(model2);
                            _context.SaveChanges();
                        }
                        foreach (var item in DetailArray)
                        {
                            invWareHouse model2 = new invWareHouse();
                            model2.Date = MasterArray.issuanceDate;
                            model2.itemId = item.itemId;
                            model2.unitId = item.unitId;
                            model2.qty = item.qty;
                            model2.rate = item.rate;
                            model2.branchId = MasterArray.toBranchId;
                            model2.departmentId = MasterArray.toDepartmentId;
                            model2.Type = "Out";
                            model2.dateTime = DateTime.Now;
                            model2.VoucherId = update.issuanceId;

                            _context.invWareHouse.Add(model2);
                        }
                        var saved = _context.SaveChanges();

                        if (saved > 0)
                        {
                            dbTransaction.Commit();
                            TempData["issuanceId"] = "";
                            TempData["Success"] = "Proceed Successfully !";
                            return RedirectToAction("IndexInvIssuance", "MasterDetail");
                        }
                        else
                        {
                            dbTransaction.Rollback();
                            TempData["issuanceId"] = "";
                            TempData["Error"] = "Not Proceed !";
                            return Json(saved);
                        }

                    }

                }

                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    TempData["issuanceId"] = 0;
                    TempData["Error"] = "Error! + " + ex + " ";
                }
            }
            return View();

        }
        [HttpPost]
        public ActionResult EditIssunaceDetail(int issuanceId, invIssuanceDetail RecValues)
        {
            var ifExist = _context.invIssuanceDetail.Where(x => x.issuanceId == issuanceId).FirstOrDefault();

            ifExist.qty = RecValues.qty;
            ifExist.rate = RecValues.rate;
            _context.SaveChanges();
            TempData["Success"] = "Updated Successfully";
            return RedirectToAction("IndexInvIssuance");
        }
        #endregion     

        #region InvProductionMasterDetail

        public ActionResult IndexInvProduction()
        {
            var IfExist = _context.invProductionMaster.ToList();
            return View(IfExist);
        }
        public ActionResult InvProductionDetails(int prId)
        {
            var List = _context.invProductionDetail.Where(x => x.prId == prId).ToList();
            return View(List);
        }
        public ActionResult InvProductionMasterDetail()
        {
            var user = CheckUserRights();
            if (user == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("IndexInvPurchaseOrder", "MasterDetail");
            }
            connection();
            GetProductionCode();
            if (user.UserType == "Admin")
            {
                var viewModel = new invProductionMasterDetailViewModel()
                {
                    settingBranches = _context.settingBranch.ToList(),
                    settingDepartments = _context.settingDepartment.ToList(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    UserType = user.UserType,
                    code = MasterDetailController.PrCode


                };
                return View(viewModel);
            }
            else
            {
                var viewModel = new invProductionMasterDetailViewModel()
                {
                    settingBr = _context.settingBranch.Where(x => x.branchId == user.branchId).FirstOrDefault(),
                    settingDept = _context.settingDepartment.Where(x => x.departmentId == user.departmentId).FirstOrDefault(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    date = DateTime.Now,
                    code = MasterDetailController.PrCode
                };
                return View(viewModel);
            }
                
        }

        [HttpPost]
        public ActionResult InvProductionMasterDetail(invProductionMaster MasterArray, List<invProductionDetail> DetailArray)
        {
            var date = MasterArray.prDate.ToShortDateString();
            try
            {
                var user = CheckUserRights();

                if (Session["userId"] == null)
                {
                    return RedirectToAction("Index", "Accounts");
                }
                if (MasterArray == null || DetailArray == null)
                {
                    result = "Error! Order Is Not Complete!";
                    return RedirectToAction("IndexInvProduction", "MasterDetail");
                }

                if (Convert.ToInt32(TempData["prId"]) == 0)
                {
                    invProductionMaster model = new invProductionMaster();

                    var date1 = DateTime.Now.ToShortDateString();

                    model.prNo = MasterArray.prNo;
                    model.prDate = Convert.ToDateTime(date1);
                    model.branchId = MasterArray.branchId;
                    model.departmentId = MasterArray.departmentId;
                    if (user != null)
                    {
                        model.branchId = user.branchId;
                       
                        model.departmentId = user.departmentId;
                        
                    }
                    else
                    {

                        model.branchId = MasterArray.branchId;
                        model.departmentId = MasterArray.departmentId;
                    }
                    model.dateTime = Convert.ToDateTime(date1);
                    model.modifiedBy = int.Parse(Session["userId"].ToString());
                    model.userId = int.Parse(Session["userId"].ToString());
                    model.postUserId = int.Parse(Session["userId"].ToString());//no idea
                    _context.invProductionMaster.Add(model);
                    _context.SaveChanges();
                    foreach (var item in DetailArray)
                    {
                        invProductionDetail model2 = new invProductionDetail();
                        model2.itemId = item.itemId;
                        model2.unitId = item.unitId;
                        model2.qty = item.qty;
                        model2.rate = item.rate;
                        model2.prId = model.prId;
                        TempData["prId"] = model.prId;
                        _context.invProductionDetail.Add(model2);
                    }
                    var added = _context.SaveChanges();
                    if (added > 0)
                    {
                        TempData["Success"] = "Added Successfully!";
                        return Json(added);

                    }

                    else
                    {
                        TempData["Success"] = "Error!";
                        return Json(added);
                    }

                }
                else
                {
                    getprId = Convert.ToInt32(TempData["prId"].ToString());
                    var update = _context.invProductionMaster.Where(x => x.prId == getprId).FirstOrDefault();
                    update.isPost = true;
                    _context.SaveChanges();

                    foreach (var item in DetailArray)
                    {
                        invWareHouse model2 = new invWareHouse();
                        model2.Date = DateTime.Now;
                        model2.itemId = item.itemId;
                        model2.unitId = item.unitId;
                        model2.qty = item.qty;
                        model2.rate = item.rate;
                        model2.branchId = MasterArray.branchId;
                        model2.departmentId = MasterArray.departmentId;
                        model2.Type = "In";
                        model2.dateTime = DateTime.Now;
                        model2.VoucherId = update.prId;
                        _context.invWareHouse.Add(model2);
                    }

                    var saved = _context.SaveChanges();

                    if (saved > 0)
                    {
                        TempData["prId"] = null;
                        TempData["Success"] = "Proceed Successfully !";
                        return Json(saved);
                    }

                }
            }

            catch (Exception)
            { }
            return RedirectToAction("IndexInvProduction");

        }
        [HttpPost]
        public ActionResult EditProductionDetail(int prId, invProductionDetail RecValues)
        {
            var ifExist = _context.invProductionDetail.Where(x => x.prId == prId).FirstOrDefault();

            ifExist.qty = RecValues.qty;
            ifExist.rate = RecValues.rate;
            _context.SaveChanges();
            TempData["Success"] = "Updated Successfully";
            return RedirectToAction("IndexInvProduction");
        }
        #endregion

        #region InvIssuanceReturnMasterDetail

        public ActionResult IndexInvIssuanceReturn()
        {
            var IfExist = _context.invIssuanceReturnMaster.ToList();
            return View(IfExist);
        }
        public ActionResult InvIssuanceReturnDetails(int issuanceRId)
        {
            var List = _context.invIssuanceReturnDetail.Where(x => x.issuanceReturnId == issuanceRId).ToList();
            return View(List);
        }
        public ActionResult InvIssuanceReturnMasterDetail()
        {

            var viewModel = new invIssuanceReturnMasterDetailViewModel()
            {
                settingBranches = _context.settingBranch.ToList(),
                settingDepartments = _context.settingDepartment.ToList(),
                settingItems = _context.SettingItem.ToList(),
                settingUnit = _context.settingUnit.ToList(),
                invIssuanceMaster = _context.invIssuanceMaster.ToList(),

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult InvIssuanceReturnMasterDetail(invIssuanceReturnMaster MasterArray, List<invIssuanceReturnDetail> DetailArray)
        {
            var date = MasterArray.issuanceReturnDate.ToShortDateString();
            try
            {
                if (Session["userId"] == null)
                {
                    return RedirectToAction("Index", "Accounts");
                }
                if (MasterArray == null || DetailArray == null)
                {
                    result = "Error! Order Is Not Complete!";
                    return RedirectToAction("InvDemandMasterDetail", "MasterDetail");
                }

                if (Convert.ToInt32(TempData["issuanceReturnId"]) == 0)
                {
                    invIssuanceReturnMaster model = new invIssuanceReturnMaster();

                    var date1 = DateTime.Now.ToShortDateString();

                    model.issuanceReturnNo = MasterArray.issuanceReturnNo;
                    model.issuanceReturnDate = Convert.ToDateTime(date1);
                    model.branchId = MasterArray.branchId;
                    model.departmentId = MasterArray.departmentId;
                    model.issuanceId = MasterArray.issuanceId;
                    model.dateTime = Convert.ToDateTime(date1);
                    model.modifiedBy = int.Parse(Session["userId"].ToString());
                    model.userId = int.Parse(Session["userId"].ToString());
                    model.postUserId = int.Parse(Session["userId"].ToString());//no idea
                    _context.invIssuanceReturnMaster.Add(model);
                    _context.SaveChanges();
                    foreach (var item in DetailArray)
                    {
                        invIssuanceReturnDetail model2 = new invIssuanceReturnDetail();
                        model2.itemId = item.itemId;
                        model2.unitId = item.unitId;
                        model2.qty = item.qty;
                        model2.rate = item.rate;
                        model2.issuanceReturnId = model.issuanceReturnId;
                        TempData["issuanceReturnId"] = model.issuanceReturnId;
                        _context.invIssuanceReturnDetail.Add(model2);
                    }
                    var added = _context.SaveChanges();
                    if (added > 0)
                    {
                        TempData["Success"] = "Added Successfully!";
                        return Json(added);

                    }

                    else
                    {
                        TempData["Success"] = "Error!";
                        return Json(added);
                    }

                }
                else
                {
                    getIssReturnId = Convert.ToInt32(TempData["issuanceReturnId"].ToString());
                    var update = _context.invIssuanceReturnMaster.Where(x => x.issuanceReturnId == getIssReturnId).FirstOrDefault();
                    update.isPost = true;
                    _context.SaveChanges();

                    foreach (var item in DetailArray)
                    {
                        invWareHouse model2 = new invWareHouse();
                        model2.Date = Convert.ToDateTime(date);
                        model2.itemId = item.itemId;
                        model2.unitId = item.unitId;
                        model2.qty = item.qty;
                        model2.rate = item.rate;
                        model2.branchId = MasterArray.branchId;
                        model2.departmentId = MasterArray.departmentId;
                        model2.Type = "Out";
                        model2.dateTime = DateTime.Now;
                        model2.VoucherId = update.issuanceReturnId;

                        _context.invWareHouse.Add(model2);
                        saved = _context.SaveChanges();
                    }

                    if (saved > 0)
                    {
                        TempData["Success"] = "Proceed Successfully !";
                        return Json(saved);
                    }

                }
            }

            catch (Exception)
            { }
            return RedirectToAction("IndexInvIssuanceReturn");

        }
        [HttpPost]
        public ActionResult EditIssunaceReturnDetail(int issuanceReturnId, invIssuanceReturnDetail RecValues)
        {
            var ifExist = _context.invIssuanceReturnDetail.Where(x => x.issuanceReturnId == issuanceReturnId).FirstOrDefault();

            ifExist.qty = RecValues.qty;
            ifExist.rate = RecValues.rate;
            _context.SaveChanges();
            TempData["Success"] = "Updated Successfully";
            return RedirectToAction("IndexInvIssuanceReturn");
        }
        #endregion

        #region InvWastageMasterDetail

        public ActionResult IndexInvwastage()
        {
            var IfExist = _context.invWastageMaster.ToList();
            return View(IfExist);
        }
        public ActionResult InvwastageDetails(int wastageId)
        {
            var List = _context.invWastageDetail.Where(x => x.wastageId == wastageId).ToList();
            return View(List);
        }
        public ActionResult InvwastageMasterDetail()
        {
            var user = CheckUserRights();
            if (user == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("Index", "IndexInvDiscard");
            }
            if (user.UserType == "Admin")
            {
                var viewModel = new invWastageMasterDetailViewModel()
                {
                    settingBranches = _context.settingBranch.ToList(),
                    settingDepartments = _context.settingDepartment.ToList(),
                    settingItems = _context.SettingItem.ToList(),
                    settingUnit = _context.settingUnit.ToList(),
                    UserType = user.UserType

                };
                return View(viewModel);
            }
            else 
            {
                settingUserInventoryRights getDeptnBr = mfObj.getDeptBranchbyUser();
                var viewModel = new invWastageMasterDetailViewModel()
                {
                    settingBr = _context.settingBranch.Where(x => x.branchId == getDeptnBr.branchId).FirstOrDefault(),
                    settingDept = _context.settingDepartment.Where(x => x.departmentId == getDeptnBr.departmentId).FirstOrDefault(),
                    settingItems = _context.SettingItem.ToList(),
                    wastageDate = DateTime.Now,
                    settingUnit = _context.settingUnit.ToList(),

                };
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult InvwastageMasterDetail(invWastageMaster MasterArray, List<invWastageDetail> DetailArray)
        {
            var date = MasterArray.wastageDate.ToShortDateString();
            try
            {
                if (Session["userId"] == null)
                {
                    return RedirectToAction("SignUpUser", "User");
                }
                if (MasterArray == null || DetailArray == null)
                {
                    result = "Error! Order Is Not Complete!";
                    return RedirectToAction("InvwastageMasterDetail", "MasterDetail");
                }
                var user = mfObj.getDeptBranchbyUser();
                using (DbContextTransaction transaction = _context.Database.BeginTransaction())
                {
                    string tempid = TempData["wastageId"].ToString();
                    if (tempid == "")
                    {
                        invWastageMaster model = new invWastageMaster();
                        model.wastageNo = MasterArray.wastageNo;
                        model.wastageDate = MasterArray.wastageDate;
                        if (user != null)
                        {
                            model.branchId = user.branchId;
                            model.departmentId = user.departmentId;
                        }
                        else
                        {
                            model.branchId = MasterArray.branchId;
                            model.departmentId = MasterArray.departmentId;
                        }
                        model.dateTime = DateTime.Now;
                        model.modifiedBy = int.Parse(Session["userId"].ToString());
                        model.userId = int.Parse(Session["userId"].ToString());
                        model.postUserId = int.Parse(Session["userId"].ToString());//no idea
                        _context.invWastageMaster.Add(model);
                        _context.SaveChanges();
                        foreach (var item in DetailArray)
                        {
                            invWastageDetail model2 = new invWastageDetail();
                            model2.itemId = item.itemId;
                            model2.unitId = item.unitId;
                            model2.qty = item.qty;
                            model2.rate = item.rate;
                            model2.wastageId = model.wastageId;
                            TempData["wastageId"] = model.wastageId;
                            _context.invWastageDetail.Add(model2);
                        }
                        var added = _context.SaveChanges();
                        if (added > 0)
                        {
                            transaction.Commit();
                            TempData["Success"] = "Added Successfully!";
                            return Json(added);

                        }
                        else
                        {
                            transaction.Rollback();
                            TempData["Error"] = "Error!";
                            return Json(added);
                        }
                    }
                    else
                    {

                        getwastageId = Convert.ToInt32(TempData["wastageId"].ToString());
                        var update = _context.invWastageMaster.Where(x => x.wastageId == getwastageId).FirstOrDefault();
                        update.isPost = true;
                        _context.SaveChanges();

                        foreach (var item in DetailArray)
                        {
                            invWareHouse model2 = new invWareHouse();
                            model2.Date = DateTime.Now;
                            model2.itemId = item.itemId;
                            model2.unitId = item.unitId;
                            model2.qty = item.qty;
                            model2.rate = item.rate;
                            if (user != null)
                            {
                                model2.branchId = user.branchId;
                                model2.departmentId = user.departmentId;
                            }
                            else
                            {
                                model2.branchId = MasterArray.branchId;
                                model2.departmentId = MasterArray.departmentId;
                            }
                            model2.Type = "Out";
                            model2.dateTime = DateTime.Now;
                            model2.VoucherId = update.wastageId;
                            model2.ExpiryDate = DateTime.Now.AddDays(30);

                            _context.invWareHouse.Add(model2);
                            saved = _context.SaveChanges();
                        }

                        if (saved > 0)
                        {
                            transaction.Commit();
                            TempData["wastageId"] = null;
                            TempData["Success"] = "Proceed Successfully !";
                            return Json(saved);
                        }
                        else
                            transaction.Rollback();
                            TempData["wastageId"] = null;
                            TempData["Error"] = "Not Proceed !";
                            return RedirectToAction("InvwastageMasterDetail");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("IndexInvwastage");
        }
        [HttpPost]
        public ActionResult EditwastageDetail(int wastageId, invWastageDetail RecValues)
        {
            var ifExist = _context.invWastageDetail.Where(x => x.wastageId == wastageId).FirstOrDefault();

            ifExist.qty = RecValues.qty;
            ifExist.rate = RecValues.rate;
            _context.SaveChanges();
            TempData["Success"] = "Updated Successfully";
            return RedirectToAction("InvwastageDetails", new { id = wastageId });
        }

        #endregion

        #region InvDiscardMasterDetail

        public ActionResult IndexInvDiscard()
        {
            var IfExist = _context.invDiscardMaster.ToList();
            return View(IfExist);
        }
        public ActionResult InvDiscardDetails(int discardId)
        {
            var List = _context.invDiscardDetail.Where(x => x.discardId == discardId).ToList();
            return View(List);
        }
        public ActionResult InvDiscardMasterDetail()
        {
            var user = CheckUserRights();
            if (user == null)
            {
                TempData["Error"] = "Set User Rights First";
                return RedirectToAction("Index", "IndexInvDiscard");
            }
            if (user.UserType == "Admin")
            {
                var viewModel = new InvDiscardMasterDetailViewModel()
                {
                    settingBranch = _context.settingBranch.ToList(),
                    settingDepartment = _context.settingDepartment.ToList(),
                    settingItem = _context.SettingItem.ToList(),
                    UserType = user.UserType
                };
                return View(viewModel);
            }
            else 
            {
                settingUserInventoryRights getDeptnBr = mfObj.getDeptBranchbyUser();
                var viewModel = new InvDiscardMasterDetailViewModel()
                {                   
                    settingBr = _context.settingBranch.Where(x => x.branchId == getDeptnBr.branchId).FirstOrDefault(),
                    settingDept = _context.settingDepartment.Where(x => x.departmentId == getDeptnBr.departmentId).FirstOrDefault(),
                    settingItem = _context.SettingItem.ToList(),
                    discardDate = DateTime.Now

                };
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult InvDiscardMasterDetail(invDiscardMaster MasterArray, List<invDiscardDetail> DetailArray, List<invDiscardDetail> DetailforProceed)
        {
            try
            {
                //not works cause Accounts controller is corupt//good
                if (Session["userId"] == null)
                {
                    return RedirectToAction("SignUpUser", "User");
                }
                if (MasterArray == null)
                {
                    result = "Error! Order Is Not Complete!";
                    return RedirectToAction("InvDiscardMasterDetail", "MasterDetail");
                }
                settingUserInventoryRights user = mfObj.getDeptBranchbyUser();
                //Convert.ToInt32(TempData["getdiscardId"]) == 0
                using (DbContextTransaction transaction = _context.Database.BeginTransaction())
                {
                    if (DetailforProceed == null)
                    {
                        invDiscardMaster model = new invDiscardMaster();

                        model.discardNo = MasterArray.discardNo;
                        model.discardDate = MasterArray.discardDate;
                        if (user != null)
                        {
                            model.branchId = user.branchId;
                            model.departmentId = user.departmentId;
                        }
                        else
                        {
                            model.branchId = MasterArray.branchId;
                            model.departmentId = MasterArray.departmentId;
                        }
                        model.dateTime = DateTime.Now;
                        model.modifiedBy = int.Parse(Session["userId"].ToString());
                        model.userId = int.Parse(Session["userId"].ToString());
                        model.postUserId = int.Parse(Session["userId"].ToString());//no idea
                        _context.invDiscardMaster.Add(model);
                        _context.SaveChanges();
                        foreach (var item in DetailArray)
                        {
                            invDiscardDetail model2 = new invDiscardDetail();
                            model2.itemId = item.itemId;
                            model2.qty = item.qty;
                            model2.desc = item.desc;
                            model2.discardId = model.discardId;
                            _context.invDiscardDetail.Add(model2);
                            getdiscardId = model2.discardId;
                            TempData["getdiscardId"] = getdiscardId;
                        }
                        var added = _context.SaveChanges();
                        if (added > 0)
                        {
                            transaction.Commit();
                            TempData["Success"] = "Added Successfully!";
                            return Json(added);

                        }
                        else
                        {
                            transaction.Rollback();
                            TempData["Error"] = "Error!";
                            return Json(added);
                        }

                    }
                    else
                    {
                        getdiscardId = Convert.ToInt32(TempData["getdiscardId"]);
                        var update = _context.invDiscardMaster.Where(x => x.discardId == getdiscardId).FirstOrDefault();
                        update.isPost = true;
                        _context.SaveChanges();

                        foreach (var item in DetailforProceed)
                        {
                            invWareHouse model2 = new invWareHouse();
                            model2.Date = DateTime.Now;
                            model2.itemId = item.itemId;
                            model2.unitId = 1;  //sending dummy record//foreignkeys issues when u r not sending foreign keys data it will brake
                            model2.qty = item.qty;   //ann error occured while updating the entries                                                       
                            model2.rate = 0;
                            model2.Desc = item.desc;
                            if (user != null)
                            {
                                model2.branchId = user.branchId;
                                model2.departmentId = user.departmentId;
                            }
                            else
                            {
                                model2.branchId = MasterArray.branchId;
                                model2.departmentId = MasterArray.departmentId;
                            }
                            model2.Type = "Out";
                            model2.dateTime = DateTime.Now;
                            model2.VoucherId = update.discardId;
                            model2.ExpiryDate = DateTime.Now.AddDays(30);

                            _context.invWareHouse.Add(model2);
                            saved = _context.SaveChanges();
                        }

                        if (saved > 0)
                        {
                            transaction.Commit();
                            TempData["Success"] = "Proceed Successfully !";
                            return RedirectToAction("InvDiscardMasterDetail");
                        }
                        else
                            transaction.Rollback();
                        TempData["Success"] = "Not Proceed !";
                        return RedirectToAction("InvDiscardMasterDetail");

                    }
                }
            }

            catch (Exception)
            {
                TempData["Success"] = "";
                TempData["Error"] = "";
            }
            return RedirectToAction("IndexInvDiscard");

        }

        [HttpPost]
        public ActionResult EditDiscardDetail(int discardId, invDiscardDetail RecValues)
        {
            var ifExist = _context.invDiscardDetail.Where(x => x.discardId == discardId).FirstOrDefault();

            ifExist.qty = RecValues.qty;
            ifExist.desc = RecValues.desc;
            _context.SaveChanges();
            TempData["Success"] = "Updated Successfully";
            return RedirectToAction("InvDiscardDetails", new { discardId = discardId });//Redirect ot Action with a value
        }

        #endregion

    }

}

