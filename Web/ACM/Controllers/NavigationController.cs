using ACM.BO.Campaign;
using ACM.Service.Client.CampaignServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACM.Controllers
{
    public class NavigationController : Controller
    {
        [ChildActionOnly]
        public ActionResult RenderLeftMenu(int campaignId = 0)
        {
            CampaignClient campaignService = new CampaignClient();
            ACM.Model.PartialViewInfo partialView = new Model.PartialViewInfo();

            if (Session["CampaignId"] != null)
                partialView.CampaignId = (Int32)Session["CampaignId"];
            else
                partialView.CampaignId = campaignId;
            CampaignBO campaignBO = new CampaignBO();
            partialView = campaignBO.CampaignLeftNavigationDetails(partialView.CampaignId);


            if (Session["DeploymentPeriodId"] != null)
            {
                partialView.DeploymentPeriodId = (int)Session["DeploymentPeriodId"];
            }


            return PartialView("_LeftMenu", partialView);
        }
    }
}