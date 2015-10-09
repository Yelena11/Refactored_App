using System;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Controller class to perform all the ad related actions - View
/// </summary>
using System.Web;
using System.Web.Mvc;
using ACM.BO.Ad;
using ACM.Model.CustomModel;
using ACM.BO;
using System.Collections;

namespace ACM.Controllers.Ad
{

    //AdView controller
    public class AdController : Controller
    {
        ACM.Service.Client.AdServiceRef.AdServiceClient adServiceClient = new Service.Client.AdServiceRef.AdServiceClient();
        Queue<string> queue = new Queue<string>();
        //
        // GET: /Ad/
        public ActionResult AdDashboard(int CampaignId = 0)
        {
            ACM.Model.PartialViewInfo partialView = new Model.PartialViewInfo();
            if (Session["CampaignId"] != null)
                partialView.CampaignId = (Int32)Session["CampaignId"];
            else
                partialView.CampaignId = CampaignId;
            return View(partialView);
        }

        /// <summary>
        /// Post Method to Load Dashboard grid
        /// </summary>
        /// <param name="sidx">the index id to be used in sorting</param>
        /// <param name="sord"> the sort order either ASC or DESC</param>
        /// <param name="page">the current page number</param>
        /// <param name="rows">the number of rows expected in the </param>
        /// <param name="CampaignId">the Campaign ID expected in the </param>
        ///   /// <param name="adStatus">the adStatus expected in the </param>
        /// <returns>as defined by the rowNum option or as selected by the user</returns>

        public JsonResult GetAdDashboardData(string sidx, string sord, int page, int rows, string CampaignId, string adStatus, int deploymentPeriodId, bool disableSorting=false)
        {
            queue.Enqueue(sidx);
            List<ACM.Model.CustomModel.AdInfo_Result> AcmAds = new List<ACM.Model.CustomModel.AdInfo_Result>();
            ACM.Model.Ad ad = new Model.Ad();
            ad.CampaignId = Convert.ToInt32(CampaignId);
            Session["DeploymentPeriodId"] = deploymentPeriodId;
            if (ad.CampaignId < 1)
            {
                var no_records_result = new
                {
                    total = 0, //number of pages
                    page = page, //current page
                    records = 0, //total items
                    rows = new
                    {
                        CampaignId = "",
                        AdId = "",
                        AdName = "",
                        AdLocation = "",
                        Restriction = "",
                        Template = "N/A",
                        StaticMedia = "N/A",
                        Status = "",
                        Action = ""
                    }
                };
                return Json(no_records_result, JsonRequestBehavior.AllowGet);

            }

            AcmAds = adServiceClient.AdsByCampaign(ad.CampaignId, deploymentPeriodId);

            //if (String.Equals(adStatus, "Cancelled"))
            //    AcmAds = AcmAds.Where(i => i.AdStatus == "Cancelled").ToList();
            //else if (String.Equals(adStatus, "Active"))
            //    AcmAds = AcmAds.Where(i => i.AdStatus != "Cancelled").ToList();

            // Sort the items
            if (disableSorting)
            {
                sidx = queue.Peek();
                if (sidx == "Status")
                    sidx = "None";
            }
            switch (sidx.Trim())
            {
                case "AdId":
                    AcmAds = (sord == "asc") ? AcmAds.OrderBy(i => i.AdId).ToList() : AcmAds.OrderByDescending(i => i.AdId).ToList();
                    break;
                case "AdName":
                    AcmAds = (sord == "asc") ? AcmAds.OrderBy(i => i.AdName).ToList() : AcmAds.OrderByDescending(i => i.AdName).ToList();
                    break;
                case "AdLocation":
                    AcmAds = (sord == "asc") ? AcmAds.OrderBy(i => i.AdLocationDesc).ToList() : AcmAds.OrderByDescending(i => i.AdLocationDesc).ToList();
                    break;
                case "Restriction":
                    AcmAds = (sord == "asc") ? AcmAds.OrderBy(i => i.RestrictionNames).ToList() : AcmAds.OrderByDescending(i => i.RestrictionNames).ToList();
                    break;
                case "Status":
                    AcmAds = (sord == "asc") ? AcmAds.OrderBy(i => i.AdStatus).ToList() : AcmAds.OrderByDescending(i => i.AdStatus).ToList();
                    break;
                case "None":
                    break;
                default:
                    AcmAds = (sord == "asc") ? AcmAds.OrderBy(i => i.AdName).ToList() : AcmAds.OrderByDescending(i => i.AdName).ToList();
                    break;

            }
           

            var totalRecords = AcmAds.Count();
            var assets = from a in AcmAds
                         select new
                         {
                             CampaignId = a.CampaignId,
                             AdId = a.AdId,
                             AdName = a.AdName,
                             AdLocation = a.AdLocationDesc,
                             Restriction = a.RestrictionNames,
                             Template = "N/A",
                             StaticMedia = "N/A",
                             Status = a.AdStatus,
                             Action = ""
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
        /// Detail view of the ad view by campaign id and ad id
        /// </summary>
        /// <param name="CampaignId"></param>
        /// <param name="AdId"></param>
        /// <returns></returns>
        public ActionResult AdView(int? CampaignId, int? AdId)
        {
            if (AdId == 0)
                ViewBag.ViewMode = "Add";
            if (Session["CampaignId"] == null)
                Session["CampaignId"] = CampaignId;
            ACM.Model.Ad ad = new Model.Ad();
            ad.CampaignId = Convert.ToInt32(CampaignId);
            ad.AdId = Convert.ToInt32(AdId);

            //ad.CampaignId = CampaignId;
            // ad.AdId = 14001;

            var adInq = adServiceClient.AdInq(ad);

            if (adInq == null)
            {
                adInq = new Model.Ad();
                adInq.CampaignId = (Int32)Session["CampaignId"];
            }
            return View(adInq);
        }

        /// <summary>
        /// Detail view of the ad detail view by ad model
        /// </summary>
        /// <param name="Ad"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult AdDetailView(ACM.Model.Ad ad)
        {
            var adLocation = adServiceClient.AdLocationsByCampaign(ad.CampaignId, ad.AdId);
            ViewBag.adLocation = new SelectList(adLocation, "AdLocationCode", "AdLocationDesc");

            ACM.Service.Client.AdServiceRef.AdServiceClient adProxy = new ACM.Service.Client.AdServiceRef.AdServiceClient();
            ViewBag.restrictions = adServiceClient.GetAdRestrictionCategory();

            var adproductType = ACM.Util.Common.GetDropDownListByID("ProductTypeId", "Description", "AdProductType");
            ViewBag.adproductType = new SelectList(adproductType, "ID", "Name");


            var flags = adServiceClient.GetAdRestrictionFlag(ad.CampaignId, ad.AdId);

            ViewBag.depositoryVal = null;
            ViewBag.eFcutoffVal = null;
            ViewBag.otherVal = null;
            //read restriction flags for edit mode
            foreach (KeyValuePair<int, int> dictItem in flags)
            {
                switch (dictItem.Key)
                {
                    case (Int32)AdRestrictionFlag.DepositoryType:
                        ViewBag.depositoryVal = dictItem.Value;
                        break;
                    case (Int32)AdRestrictionFlag.EFcutoff:
                        ViewBag.eFcutoffVal = dictItem.Value;
                        break;
                    case (Int32)AdRestrictionFlag.Other:
                        ViewBag.otherVal = dictItem.Value;
                        break;
                }
            }

            int deploymentPeriodId = 0;
            AdInfo adInfoInq = new AdInfo();
            if (Session["DeploymentPeriodId"] != null)
                deploymentPeriodId = (int)Session["DeploymentPeriodId"];
            if (ad.AdId > 0)
            {
                adInfoInq = adServiceClient.AdInfoInq(ad.CampaignId, ad.AdId, deploymentPeriodId);


                if (adInfoInq.Ad == null)
                {
                    adInfoInq = new Model.CustomModel.AdInfo();
                    adInfoInq.Ad = new AdInfo_Result();
                    adInfoInq.Ad.CampaignId = (Int32)Session["CampaignId"];
                    adInfoInq.AdRestriction = new List<Model.AdRestrictions>();

                }

                if (adInfoInq.Ad.AdLocationCode != null)
                {
                    var adlocationValue = adLocation.Find(x => x.AdLocationCode == adInfoInq.Ad.AdLocationCode);
                    ViewBag.adlocationName = adlocationValue.AdLocationDesc;
                    ViewBag.adlocationId = adInfoInq.Ad.AdLocationCode;
                }
            }
            else
            {
                adInfoInq = new Model.CustomModel.AdInfo();
                adInfoInq.Ad = new AdInfo_Result();
                adInfoInq.Ad.CampaignId = (Int32)Session["CampaignId"];
                adInfoInq.AdRestriction = new List<Model.AdRestrictions>();
            }

            return PartialView(adInfoInq);
        }
        [ChildActionOnly]
        public ActionResult AdIUtilityConfig()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult AdDisplayRule()
        {
            return PartialView();
        }

        /// <summary>
        /// Get Media Type By Adlocation
        /// </summary>
        /// <param name="adlocationCode"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetMediaTypeByAdlocation(string adlocationCode)
        {
            var mediaType = adServiceClient.CheckMediaFileTypes(adlocationCode);
            //var jsonS = Newtonsoft.Json.JsonConvert.SerializeObject(mediaType);
            return Json(mediaType.Keys);
        }
        //private function to apply ad restrictions for ad insert/modify
        private void UpdateRestrictions(ACM.Model.Ad ad)
        {
            int depositoryVal = 0;
            int eFcutoffVal = 0;
            int otherVal = 0;
            List<int> flags = new List<int>();
            if (!string.IsNullOrEmpty(ad.Field7))
            {
                if (ad.Field7.Contains(','))
                {
                    var split = ad.Field7.Split(',');
                    int outVal = 0;
                    if (int.TryParse(split[0], out outVal))
                    {
                        depositoryVal = Convert.ToInt32(split[0]);
                        ViewBag.depositoryVal = depositoryVal;
                        flags.Add(depositoryVal);
                    }

                    if (int.TryParse(split[1], out outVal))
                    {
                        eFcutoffVal = Convert.ToInt32(split[1]);
                        ViewBag.eFcutoffVal = eFcutoffVal;
                        flags.Add(eFcutoffVal);
                    }

                    if (int.TryParse(split[2], out outVal))
                    {
                        otherVal = Convert.ToInt32(split[2]);
                        ViewBag.otherVal = otherVal;
                        flags.Add(otherVal);
                    }
                    bool applyAll = false;
                    if (ad.Field10 != null && ad.Field10 == 1)
                    {
                        applyAll = true;
                        //var restrictionstatus = adBo.UpdateAdRestriction(ad);
                    }

                    var resName = adServiceClient.AdAdRestrictionFlagAdd(ad, flags, applyAll);
                }
            }
        }
        /// <summary>
        /// Save Ad info by ad model
        /// </summary>
        /// <param name="ad"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveAdInfo(ACM.Model.Ad ad)
        {
            if (!string.IsNullOrEmpty(ad.AdLocationCode) && ad.MediaType != "Select" && ModelState.IsValid)
            {

                string loginId = User.Identity.Name;
                loginId = loginId.Replace("AD-ENT\\", "");
                ACM.BO.Admin.UsersBO usersBO = new ACM.BO.Admin.UsersBO();
                var userDetail = usersBO.GetUserDetail(loginId);

                int depolymentPeriodID = 0;
                if (ad.Field8 != null && ad.Field8 > 0)
                    depolymentPeriodID = (int)ad.Field8;
                if (ad.AdId == 0)
                {

                    Guid gid = Guid.NewGuid();
                    ad.AdGuid = gid.ToString();
                    ad.CreatedDate = DateTime.Now;
                    ad.CreatedBy = userDetail.UserId;
                    ad.CampaignId = (Int32)Session["CampaignId"];
                    ad.AdRestrictionId = 5;
                    ad = adServiceClient.AdAdd(ad);
                    UpdateRestrictions(ad);
                }
                else
                {
                    ad.CreatedDate = DateTime.Now;
                    ad.CreatedBy = userDetail.UserId;
                    ad.AdRestrictionId = 5;
                    ad.CampaignId = (Int32)Session["CampaignId"];

                    adServiceClient.AdMod(ad);

                    UpdateRestrictions(ad);
                    
                }

                bool applyAllDeployments = false;
                if (ad.Field9 != null && ad.Field9 == 1)
                    applyAllDeployments = true;
                if (depolymentPeriodID > 0)
                {
                    DeploymentPeriodBO dpbo = new DeploymentPeriodBO();
                    dpbo.InsertAdDeploymentPeriod(ad.CampaignId, ad.AdId, depolymentPeriodID, applyAllDeployments);
                }
                return Json(ad);
            }
            else
            {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors);
                return Json(errors);
            }
        }

        /// <summary>
        /// Reinstate or Cancel Ad
        /// </summary>
        /// <param name="CampaignId"></param>
        /// <param name="AdId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ReinstateCancelAd(int? AdId = 0, int? CampaignId = 0, int deploymentPeriodId=0)
        {
            ACM.Model.AdDeploymentPeriod ad = new ACM.Model.AdDeploymentPeriod();
            ad.Adid = Convert.ToInt32(AdId);
            ad.CampaignId = Convert.ToInt32(CampaignId);
            var adInq = adServiceClient.AdStatusInquiry(ad, deploymentPeriodId);
            string status = string.Empty;
            if (!string.IsNullOrEmpty(adInq.AdStatus))
                status = adInq.AdStatus.Trim();

            if (status == AdStatus.Cancelled.ToString())
            {
                adInq.AdStatus = AdStatus.Active.ToString();
                adServiceClient.AdStatusModify(adInq);
                adInq.AdStatus = "re-instated";
            }
            else if (status != AdStatus.Cancelled.ToString())
            {
                adInq.AdStatus = AdStatus.Cancelled.ToString();
                adServiceClient.AdStatusModify(adInq);
                adInq.AdStatus = "cancelled";
            }
            return Json(adInq);
        }

        [HttpPost]
        public JsonResult CheckAdStatus(int? AdId = 0, int deploymentPeriodId = 0)
        {
            int campaignId = 0;
            if (Session["CampaignId"] != null)
                campaignId = (Int32)Session["CampaignId"];
            ACM.Model.AdDeploymentPeriod ad = new ACM.Model.AdDeploymentPeriod();
            ad.Adid = Convert.ToInt32(AdId);
            ad.CampaignId = Convert.ToInt32(campaignId);
            var adInq = adServiceClient.AdStatusInquiry(ad, deploymentPeriodId);
            string status = string.Empty;
            if (adInq != null && !string.IsNullOrEmpty(adInq.AdStatus))
                status = adInq.AdStatus.Trim();
            return Json(status);
        }
    }
}