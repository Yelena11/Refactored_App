/// <summary>
/// Controller class to perform all the campaign related actions - PM View
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACM.Model;
using ACM.Service.Client;
using System.Diagnostics;


namespace ACM.Controllers.Campaign
{
    public class CampaignViewController : Controller
    {
        public System.DateTime defaultDate { get; set; }
        CampaignServiceClient campaignServiceClient = new CampaignServiceClient();
        /// <summary>
        /// Post Method to Load Dashboard grid
        /// </summary>
        /// <param name="sidx">the index id to be used in sorting</param>
        /// <param name="sord"> the sort order either ASC or DESC</param>
        /// <param name="page">the current page number</param>
        /// <param name="rows">the number of rows expected in the </param>
        /// <returns>as defined by the rowNum option or as selected by the user</returns>
        public JsonResult GetCampaignDashboardData(string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            List<ACM.Model.Campaign> AcmCampaigns = new List<ACM.Model.Campaign>();
            string loginId = Utility.LoginId(User.Identity.Name);

            AcmCampaigns = campaignServiceClient.GetCampaignDashboard(loginId, "Active");

            if (_search)
            {
                if (searchField == "CampaignId")
                {
                    int field = 0;
                    if (int.TryParse(searchString, out field))
                    {
                        AcmCampaigns = AcmCampaigns.Where(x => x.CampaignId.Equals(field)).ToList();
                    }
                }
                else if("CampaignName" == searchField)
                    AcmCampaigns = AcmCampaigns.Where(x => x.CampaignName.Contains(searchString)).ToList();
            }


            switch (sidx.Trim())
            {
                case "CampaignId":
                    AcmCampaigns = (sord == "asc") ? AcmCampaigns.OrderBy(i => i.CampaignId).ToList() : AcmCampaigns.OrderByDescending(i => i.CampaignId).ToList();
                    break;
                case "CampaignName":
                    AcmCampaigns = (sord == "asc") ? AcmCampaigns.OrderBy(i => i.CampaignName).ToList() : AcmCampaigns.OrderByDescending(i => i.CampaignName).ToList();
                    break;
                default:
                    AcmCampaigns = (sord == "asc") ? AcmCampaigns.OrderBy(i => i.CampaignName).ToList() : AcmCampaigns.OrderByDescending(i => i.CampaignName).ToList();
                    break;
            }

            var totalRecords = AcmCampaigns.Count();
            var assets = from a in AcmCampaigns
                         select new
                         {
                             CampaignId = a.CampaignId,
                             CampaignName = a.CampaignName,
                             PendingTasks = "",
                             PriorityList = "",
                             Regions = "",
                             States = ""
                         };
            var result = new
            {
                total = (totalRecords + rows - 1) / rows, //number of pages
                page = page, //current page
                records = totalRecords, //total items
                rows = assets.AsEnumerable().Skip((page - 1) * rows).Take(rows)
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Initial controller to load campaign dashboard
        /// </summary>
        /// <returns></returns>
        public ActionResult CampaignDashboard()
        {
            RedirectToAction("CampaignRequest", "Campaign");
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// CampaignView Section is the Integration part of the CampaignInfo, Targetfile Provider, Followup
        /// Mainframe and Left Navigaton section
        /// </summary>
        /// <returns></returns>
        public ActionResult CampaignView(int? CampaignId)
        {
            if (CampaignId == null) CampaignId = 0;
            Session["CampaignId"] = CampaignId;
            ACM.Model.Campaign campaign = new ACM.Model.Campaign();
            campaign.CampaignId = Convert.ToInt32(CampaignId);
            var campaignInq = campaignServiceClient.CampaignInq(campaign);
            if (campaignInq == null)
                campaignInq = new Model.Campaign();
            if (CampaignId == 0)
                ViewBag.ViewMode = "Add";
            Session["Note"] = campaignInq.Notes;
            return View(campaignInq);
        }

        /// <summary>
        /// Partial view - Campaign Info section 
        /// Load default values for the dropdown
        /// </summary>
        /// <param name="cmp"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult CampaignInfoSection(ACM.Model.Campaign cmp)
        {
            ViewBag.disablecontrols = false;

            ACM.Model.Campaign campaign = new ACM.Model.Campaign();
            campaign.CampaignId = Convert.ToInt32(cmp.CampaignId);

            var campaignInq = campaignServiceClient.CampaignInq(campaign);


            var campaigntypelist = campaignServiceClient.GetMasterDropDownDataforMasterTables("CampaignTypeId", "CampaignTypeName", "CampaignType");
            ViewBag.campaigntypelist = new SelectList(campaigntypelist, "ID", "Name");

            var loblist = campaignServiceClient.GetMasterDropDownDataforMasterTables("LOBId", "LOBName", "LOB");
            ViewBag.loblist = new SelectList(loblist, "ID", "Name");

            var primarypmlist = campaignServiceClient.GetMasterDropDownDataforMasterTables("UserID", "FirstName+ '  ' +LastName", "Users");
            ViewBag.primarypmlist = new SelectList(primarypmlist, "ID", "Name");

            var secondarypmlist = campaignServiceClient.GetMasterDropDownDataforMasterTables("UserID", "FirstName+ '  ' +LastName", "Users");
            ViewBag.secondarypmlist = new SelectList(secondarypmlist, "ID", "Name");

            var promobuttontypelist = campaignServiceClient.GetMasterDropDownDataforMasterTables("PromoButtonTypeId", "PromoButtonName", "PromoButton");
            ViewBag.promobuttontypelist = new SelectList(promobuttontypelist, "ID", "Name");


            var productplacementlist = campaignServiceClient.GetMasterDropDownDataforMasterTables("ProductPlacementId", "Description", "ProductPlacement");
            ViewBag.productplacementlist = new SelectList(productplacementlist, "ID", "Name");

            var supercategory = campaignServiceClient.GetMasterDropDownDataforMasterTables("SuperCategoryID", "SuperCategoryName", "SuperCategory");
            ViewBag.supercategory = new SelectList(supercategory, "ID", "Name");


            var campaignType = campaignServiceClient.GetMasterDropDownDataforMasterTables("SuperCategoryID", "SuperCategoryName", "SuperCategory");
            ViewBag.supercategory = new SelectList(campaignType, "ID", "Name");

            var campaignTableStatuslist = campaignServiceClient.GetMasterDropDownDataforMasterTables("CampaignTableStatusId", "CampaignTableStatusDescription", "CampaignTableStatus");
            ViewBag.campaignTableStatuslist = new SelectList(campaignTableStatuslist, "ID", "Name");

            var category = campaignServiceClient.GetMasterDropDownDataforMasterTables("CategoryID", "CategoryName", "Category");
            ViewBag.category = new SelectList(category, "ID", "Name");
            if (campaignInq != null)
            {
                if (campaignInq.CategoryId != null)
                {
                    ViewBag.categoryName = category.Find(x => x.ID == campaignInq.CategoryId).Name;
                }
            }
    

            var subcategory = campaignServiceClient.GetMasterDropDownDataforMasterTables("SubCategoryID", "SubCategoryName", "SubCategory");
            ViewBag.subcategory = new SelectList(subcategory, "ID", "Name");
            if (campaignInq != null)
            {
                if (campaignInq.SubCategoryId != null)
                {
                    ViewBag.subCategoryName = subcategory.Find(x => x.ID == campaignInq.SubCategoryId).Name;
                }
            }

            var campaignTableStatusList = campaignServiceClient.GetMasterDropDownDataforMasterTables("CampaignTableStatusId", "CampaignTableStatusDescription", "CampaignTableStatus");
            ViewBag.campaignTableStatusList = new SelectList(campaignTableStatusList, "ID", "Name");



            var requestorlist = campaignServiceClient.GetMasterDropDownDataforMasterTables("UserID", "FirstName+ '  ' +LastName", "Users");
            ViewBag.requestorlist = new SelectList(requestorlist, "ID", "Name");



            var eventTrigger = campaignServiceClient.GetMasterDropDownDataforMasterTables("EventTriggerId", "EventTriggerName", "EventTrigger");
            ViewBag.eventTrigger = new SelectList(eventTrigger, "ID", "Name");


            //  var campaign = cmpbo.GetCampaign(100);
            if (campaignInq == null)
            {
                campaignInq = new Model.Campaign();
                CampaignTableStatu campaignTableStatu = new CampaignTableStatu();
                campaignInq.CampaignTableStatu = campaignTableStatu;
            }

          
            if (campaignInq.CampaignTypeId != null)
            {
                var campaignTypeValue = campaigntypelist.Find(x => x.ID == campaignInq.CampaignTypeId);
                ViewBag.campaignTypeName = campaignTypeValue.Name;
                ViewBag.campaignTypeId = campaignInq.CampaignTypeId;
            }


            return PartialView(campaignInq);
        }

        /// <summary>
        /// Partial view - Campaign Target
        /// </summary>
        /// <param name="cmpTargetFileProvider"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult CampaignTargetFileProvider(ACM.Model.CampaignTargetFileProvider cmpTargetFileProvider)
        {

            ACM.Model.CampaignTargetFileProvider CampTargetFileProvider = new ACM.Model.CampaignTargetFileProvider();
            CampTargetFileProvider.CampaignId = Convert.ToInt32(cmpTargetFileProvider.CampaignId);

            var campaignTargetFileProvider = campaignServiceClient.CampaigTargetFileInq(CampTargetFileProvider);

            if (campaignTargetFileProvider == null)
            {
                campaignTargetFileProvider = new Model.CampaignTargetFileProvider();
                campaignTargetFileProvider.CampaignId = CampTargetFileProvider.CampaignId;
            }

            return PartialView(campaignTargetFileProvider);
        }

        /// <summary>
        ///  Partial view - Campaign Target
        /// </summary>
        /// <param name="cmpFollowUp"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult CampaignFollowUp(ACM.Model.CampaignFollowUp cmpFollowUp)
        {

            ACM.Model.CampaignFollowUp CampFollowUp = new ACM.Model.CampaignFollowUp();
            if (cmpFollowUp != null && cmpFollowUp.CampaignId == 0)
                cmpFollowUp.CampaignId = Convert.ToInt32(Session["CampaignId"]);
            else
                CampFollowUp.CampaignId = Convert.ToInt32(cmpFollowUp.CampaignId);

            var campaignFollowUp = campaignServiceClient.CampaignFollowUpInq(CampFollowUp);

            if (campaignFollowUp == null)
            {
                campaignFollowUp = new Model.CampaignFollowUp();
                campaignFollowUp.CampaignId = CampFollowUp.CampaignId;
            }

            var FollowUpList = campaignServiceClient.GetMasterDropDownDataforMasterTables("FollowUpId", "FollowUpDescription", "FollowUp");
            ViewBag.FollowUpList = new SelectList(FollowUpList, "id", "name");

            return PartialView(campaignFollowUp);
        }

        /// <summary>
        /// Partial View - Campaign Mainframe
        /// Load default values for the dropdown list
        /// </summary>
        /// <param name="cmpMainfram"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult CampaignMainFrame(ACM.Model.CampaignMainFrame cmpMainfram)
        {
            ACM.Model.CampaignMainFrame campaign = new ACM.Model.CampaignMainFrame();
            campaign.CampaignId = Convert.ToInt32(cmpMainfram.CampaignId);

            var campaignMainframe = campaignServiceClient.CampaignMainframeInq(campaign);

            var cardTypeList = campaignServiceClient.GetMasterDropDownDataforMasterTables("CardTypeId", "CardDescription", "CardType");
            ViewBag.cardTypeList = new SelectList(cardTypeList, "ID", "Name");

            var customerTypeList = campaignServiceClient.GetMasterDropDownDataforMasterTables("CustomerTypeId", "CustomerTypeDesc", "CustomerType");
            ViewBag.customerTypeList = new SelectList(customerTypeList, "ID", "Name");

            var specialProcessList = campaignServiceClient.GetMasterDropDownDataforMasterTables("SpecialProcessTypeId", "SpecialProcessTypeDesc", "SpecialProcessType");
            ViewBag.specialProcessList = new SelectList(specialProcessList, "ID", "Name");

            if (campaignMainframe == null)
                campaignMainframe = new Model.CampaignMainFrame();

            return PartialView(campaignMainframe);
        }


        /// <summary>
        /// Save campaign target information
        /// </summary>
        /// <param name="CmpTargetFileProvider"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveCampaignTargetFileProvider(ACM.Model.CampaignTargetFileProvider CmpTargetFileProvider)
        {
            CampaignTargetFileProvider campaignTargetFileProvider = new CampaignTargetFileProvider();
            CmpTargetFileProvider.CampaignId = Convert.ToInt32(Session["CampaignId"]);
            campaignTargetFileProvider = campaignServiceClient.CampaigTargetFileInq(CmpTargetFileProvider);

            string loginId = Utility.LoginId(User.Identity.Name);
            ACM.BO.Admin.UsersBO usersBO = new ACM.BO.Admin.UsersBO();
            var userDetail = usersBO.GetUserDetail(loginId);
            CmpTargetFileProvider.ModifiedBy = userDetail.UserId;
            CmpTargetFileProvider.ModifiedDate = DateTime.Now;
            CmpTargetFileProvider.CreatedDate = DateTime.Now;

            if (campaignTargetFileProvider == null)
            {
               // CmpTargetFileProvider.CampaignId = Convert.ToInt32(Session["CampaignId"]);
                CmpTargetFileProvider.CreatedBy = userDetail.UserId;
                CmpTargetFileProvider.CreatedDate = DateTime.Now;
                campaignServiceClient.CampaigTargetFileAdd(CmpTargetFileProvider);
                return Json(CmpTargetFileProvider);
            }
            else
            {
                campaignServiceClient.CampaigTargetFileMod(CmpTargetFileProvider);
                return Json(CmpTargetFileProvider);
            }
        }

        /// <summary>
        /// Save Campaign followup information
        /// </summary>
        /// <param name="CmpFollowUp"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveCampaignFollowUp(ACM.Model.CampaignFollowUp CmpFollowUp)
        {

            string loginId = Utility.LoginId(User.Identity.Name);
            ACM.BO.Admin.UsersBO usersBO = new ACM.BO.Admin.UsersBO();
            var userDetail = usersBO.GetUserDetail(loginId);
            CmpFollowUp.ModifiedBy = userDetail.UserId;
            CmpFollowUp.ModifiedDate = DateTime.Now;

                CampaignFollowUp campaignFollowUp = new CampaignFollowUp();
                campaignFollowUp = campaignServiceClient.CampaignFollowUpInq(CmpFollowUp);
                if (campaignFollowUp == null)
                {
                    CmpFollowUp.CampaignId = Convert.ToInt32(Session["CampaignId"]);
                    CmpFollowUp.CreateBy = userDetail.UserId;
                    CmpFollowUp.CreatedDate = DateTime.Now;
                    campaignServiceClient.CampaignFollowUpAdd(CmpFollowUp);
                    return Json(CmpFollowUp);
                }
                else
                {
                    CmpFollowUp.CreatedDate = DateTime.Now;
                    campaignServiceClient.CampaignFollowUpMod(CmpFollowUp);
                    return Json(CmpFollowUp);
                }
           
        }

       

        /// <summary>
        /// Post method to save campaign information
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveCampaignInfo(ACM.Model.Campaign campaign)
        {
            try
            {
                DateTime minDate = DateTime.Parse("01/01/2000");
                if (campaign.CampaignStartDate < minDate || campaign.CampaingEndDate < minDate)
                {

                    if (campaign.CampaignStartDate < minDate && !campaign.CampaignStartDate.Equals(DateTime.MinValue))
                    {
                        ModelState.AddModelError("Camapaign StartDate", "Invalid date entered in Start Date. Please enter the date over 01/01/2000 ");
                    }
                    if (campaign.CampaingEndDate < minDate && !campaign.CampaingEndDate.Equals(DateTime.MinValue))
                    {
                        ModelState.AddModelError("Camapaign EndtDate", "Invalid date entered in End Date. Please enter the date over 01/01/2000 ");
                    }
                }
                if (!campaign.CampaingEndDate.Equals(DateTime.MinValue))
                {
                    if (campaign.CampaingEndDate <= campaign.CampaignStartDate)
                    {
                        ModelState.AddModelError("Camapaign EndDate", "End Date cannot be prior than Start Date");

                    }
                }
                if (campaign.CampaignTypeId == null)
                {
                    ModelState.AddModelError("CamapaignType", "The CamapaignType field is required.");
                }

                string loginId = Utility.LoginId(User.Identity.Name);
                ACM.BO.Admin.UsersBO usersBO = new ACM.BO.Admin.UsersBO();
                // ACM.BO.Campaign.CampaignRequestBO campaignRequestBO = new ACM.BO.Campaign.CampaignRequestBO();
                ViewBag.test = loginId;
                var userDetail = usersBO.GetUserDetail(loginId);

                if (ModelState.IsValid)
                {
                    DateTime dt;
                    string[] splitDates = campaign.Notes.Split('|');
                
                    if (DateTime.TryParse(splitDates[0], out dt) && DateTime.TryParse(splitDates[0], out dt))
                    {
                        campaign.Notes = string.Empty;
                        if (campaign.CampaignId == 0)
                        {
                            campaign.CreatedBy = userDetail.UserId;
                            Guid gid = Guid.NewGuid();
                            campaign.CampaignGuid = gid.ToString();

                            var campaignInq = campaignServiceClient.CampaignAdd(campaign);
                            Session["CampaignId"] = campaignInq.CampaignId;
                            return Json(campaignInq);
                        }
                        else
                        {
                            campaign.ModifiedBy = userDetail.UserId;

                            campaignServiceClient.CampaignMod(campaign);
                            return Json(campaign);
                        }
                    }
                    else
                        return Json("DateError");
                }
                else
                {
                    IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors);
                    return Json(errors);
                }
            }
            catch
            {
                return Json("Error");
            }

        }

        /// <summary>
        /// Post method to save Note from the left nav
        /// </summary>
        /// <param name="CampaignId"></param>
        /// <param name="Notes"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveCampaignNotes(int CampaignId, string Notes)
        {
            ACM.Model.Campaign campaign = new ACM.Model.Campaign();
            campaign.CampaignId = Convert.ToInt32(CampaignId);
            var campaignInq = campaignServiceClient.CampaignInq(campaign);
            campaignInq.Notes = Notes;
            var Campaignval = campaignServiceClient.CampaignMod(campaignInq);
            return Json(Campaignval, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Post method save Mainframe information
        /// </summary>
        /// <param name="cmpMainfram"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveCampaignMainFrame(ACM.Model.CampaignMainFrame cmpMainfram)
        {
            //  RedirectToAction("CampaignView");

            CampaignMainFrame campaignMainFrame = new CampaignMainFrame();
            campaignMainFrame = campaignServiceClient.CampaignMainframeInq(cmpMainfram);

            if (ModelState.IsValid)
            {
                if (campaignMainFrame == null)
                {


                    campaignServiceClient.CampaignMainFrameAdd(cmpMainfram);
                    return Json(cmpMainfram);

                }
                else
                {

                    campaignServiceClient.CampaignMainFrameMod(cmpMainfram);
                    return Json(cmpMainfram);
                }
            }
            else
            {

                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors);
                ViewBag.error = "Error in the form";
                return Json(cmpMainfram, ViewBag.error);

            }

        }


        /// <summary>
        /// Post method to Activate campaign from the left nav
        /// </summary>
        /// <param name="CampaignId"></param>
        /// <returns></returns>
        ///

        [HttpPost]
        public JsonResult ReinstateCancelCampaign(int? CampaignId = 0)
        {
            try
            {

                if (CampaignId == 0)
                    CampaignId = (Int32)Session["CampaignId"];
                ACM.Model.Campaign campaign = new ACM.Model.Campaign();

                campaign.CampaignId = Convert.ToInt32(CampaignId);
                var campaignInq = campaignServiceClient.CampaignInq(campaign);
                if (campaignInq != null)
                {
                    if (campaignInq.CampaignStatus == "Cancelled")
                    {
                        campaignInq.CampaignStatus = "Active";

                    }
                    else if (campaignInq.CampaignStatus != "Cancelled")
                    {
                        campaignInq.CampaignStatus = "Cancelled";

                    }
                    var Campaignval = campaignServiceClient.CampaignMod(campaignInq);
                    var campaignInq1 = campaignServiceClient.CampaignInq(campaign);
                    return Json(campaignInq1.CampaignStatus, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex) {
                return Json("Error");
            }

        }

        /// <summary>
        /// Post method to get category by the super category selection
        /// </summary>
        /// <param name="SuperCategoryId"></param>
        /// <returns></returns>
        public JsonResult GetAllCategory(int SuperCategoryId)
        {

            IEnumerable<ACM.Model.Category> category = campaignServiceClient.GetCategoryById(SuperCategoryId);
            Category category1 = new Category();
            List<ACM.Model.Category> lst = new List<Category>();
            SelectList supercategory = new SelectList(category, "CategoryID", "CategoryName");

            return Json(supercategory);
        }

        /// <summary>
        /// Post method to get subcategory by the category selection
        /// </summary>
        /// <param name="SuperCategoryId"></param>
        /// <returns></returns>
        public JsonResult GetAllSubCategory(int CategoryId)
        {

            IEnumerable<ACM.Model.SubCategory> subcategory = campaignServiceClient.GetSubCategoryById(CategoryId);
            SubCategory subcategory1 = new SubCategory();
            List<ACM.Model.SubCategory> lst = new List<SubCategory>();
            SelectList category = new SelectList(subcategory, "SubCategoryID", "SubCategoryName");

            return Json(category);
        }
    }
}
