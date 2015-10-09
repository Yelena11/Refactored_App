/// <summary>
/// Controller class to perform all the campaign related actions - Requestor View
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
using ACM.Model;
using ACM.Service.Client;

namespace ACM.Controllers.Campaign
{
    public class CampaignController : Controller
    {
        CampaignServiceClient clientBO = new CampaignServiceClient();
        /// <summary>
        /// default action
        /// </summary>
        /// <returns></returns>
        public ActionResult CampaignRequest()
        {

            string loginId = Utility.LoginId(User.Identity.Name);

            ACM.BO.Admin.UsersBO usersBO = new ACM.BO.Admin.UsersBO();

            var userDetail = usersBO.GetUserDetail(loginId);
            string status = "Cancelled";
            int lobID = (Int32)userDetail.LOBId;
            int userID = userDetail.UserId;
            var campaign = clientBO.GetRequestorDashboard(userID, lobID, status, false);
            ViewBag.test = loginId;
            return View(campaign);
        }

        /// <summary>
        /// Post Method to Load Dashboard grid
        /// </summary>
        /// <param name="sidx">the index id to be used in sorting</param>
        /// <param name="sord"> the sort order either ASC or DESC</param>
        /// <param name="page">the current page number</param>
        /// <param name="rows">the number of rows expected in the </param>
        /// <returns>as defined by the rowNum option or as selected by the user</returns>
        [HttpPost]
        public JsonResult CampaignRequestView(string displayID, string filterID, string sidx, string sord, int page, int rows)
        {
            string loginId = Utility.LoginId(User.Identity.Name);
            ACM.BO.Admin.UsersBO usersBO = new ACM.BO.Admin.UsersBO();
            ViewBag.test = loginId;
            var userDetail = usersBO.GetUserDetail(loginId);
            int requestorId = 0;
            int lobId = (Int32)userDetail.LOBId;
            string status = filterID;

            bool isLobRequest = false;
            if (!string.IsNullOrEmpty(displayID))
            {
                if (displayID.Equals("requestorId"))
                    requestorId = userDetail.UserId;
                else if (displayID.Equals("lobId"))
                {
                    requestorId = userDetail.UserId;
                    isLobRequest = true;
                }
            }
            var results = clientBO.GetRequestorDashboard(requestorId, lobId, status, isLobRequest);
            var totalRecords = results.Count();

            switch (sidx.Trim())
            {
                default:
                    results = results.OrderBy(i => i.Id);
                    break;
                case "CampaignId":
                    results = (sord == "desc") ? results.OrderBy(i => i.CampaignId) : results.OrderByDescending(i => i.CampaignId);
                    break;
                case "CampaignName":
                    results = (sord == "asc") ? results.OrderBy(i => i.CampaignName) : results.OrderByDescending(i => i.CampaignName);
                    break;
                case "AssignedPMId":
                    results = (sord == "asc") ? results.OrderBy(i => i.AssignedPMId) : results.OrderByDescending(i => i.AssignedPMId);
                    break;
                case "RequestorId":
                    results = (sord == "asc") ? results.OrderBy(i => i.RequestorId) : results.OrderByDescending(i => i.RequestorId);
                    break;
                case "CampaignStartDate":
                    results = (sord == "asc") ? results.OrderBy(i => i.CampaignStartDate) : results.OrderByDescending(i => i.CampaignStartDate);
                    break;
                case "CampaingEndDate":
                    results = (sord == "asc") ? results.OrderBy(i => i.CampaingEndDate) : results.OrderByDescending(i => i.CampaingEndDate);
                    break;
                case "Status":
                    results = (sord == "asc") ? results.OrderBy(i => i.CampaignStatus) : results.OrderByDescending(i => i.CampaignStatus);
                    break;
            }


            var assets = from a in results
                         select new
                         {

                             CampaignId = a.CampaignId,
                             CampaignName = a.CampaignName,
                             AssignedPMName = a.AssignedPMFirstName + " " + a.AssignedPMLastName,
                             CampaignStartDate = a.CampaignStartDate.ToShortDateString(),
                             CampaingEndDate = a.CampaingEndDate.ToShortDateString(),
                             RequestorName = a.RequestorFirstName + " " + a.RequestorLastName,
                             CampaignStatus = a.CampaignStatus,
                             Action = a.Action
                         };

            var result = new
            {
                total = (totalRecords + rows - 1) / rows, //number of pages
                page = page, //current page
                records = totalRecords, //total items
                rows = assets.AsEnumerable().Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(rows)).Take(Convert.ToInt32(rows))
            };


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Cancel campaign
        /// </summary>
        /// <param name="CampaignId"></param>
        /// <returns></returns>
        public ActionResult CancelCampaign(int CampaignId)
        {
            clientBO.CancelCampaign(CampaignId);
            return RedirectToAction("CampaignRequest");
        }

        /// <summary>
        /// Detail view of the campaign by campaign id
        /// </summary>
        /// <param name="CampaignId"></param>
        /// <returns></returns>
        public ActionResult CampaignDetail(int CampaignId)
        {
            var campaignDetail = clientBO.CampaignDetials(CampaignId);
            return View(campaignDetail);
        }
    }
}