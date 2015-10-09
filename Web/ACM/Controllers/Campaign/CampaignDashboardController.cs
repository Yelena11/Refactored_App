/******************************************************************
 * Create Date: 03/13/2014
 * Created By: Elena Martirosyan
 * Update Date:
 * Updated By:
 *
 * Purpose: CampaignDashboardController serves CampaignDashboard.cshtml
 * page to display and support CampaignDashboard Grid (view only).
 * ****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACM.Model;
using ACM.Service.Client;
namespace ACM.Controllers.Campaign
{
    public class CampaignDashboardController : Controller
    {
        CampaignServiceClient clientBO = new CampaignServiceClient();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CampaignDashboard()
        {
            List<ACM.Model.Campaign> AcmCampaigns = new List<ACM.Model.Campaign>();
            string loginId = Utility.LoginId(User.Identity.Name);
            AcmCampaigns = clientBO.GetCampaignDashboard(loginId, "Active");
            return View(AcmCampaigns);
        }
    }
}