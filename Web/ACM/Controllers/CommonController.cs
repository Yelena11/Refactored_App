using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACM.Controllers
{
    public class CommonController : Controller
    {
        [ChildActionOnly]
        public ActionResult DeploymentPeriods(int defaultDeploymentPeriod = 0)
        {
            ACM.Model.PartialViewInfo partialView = new Model.PartialViewInfo();
            ACM.BO.DeploymentPeriodBO deploymentPeriodBO = new BO.DeploymentPeriodBO();
            if (Session["CampaignId"] != null)
                partialView.CampaignId = (int)Session["CampaignId"];
            var deploymentPeriod = deploymentPeriodBO.GetAvailableDeploymentPeriod(partialView.CampaignId);
            ViewBag.deploymentPeriod = new SelectList(deploymentPeriod, "ID", "Name");

            if (defaultDeploymentPeriod != 0)
                partialView.DeploymentPeriodId = defaultDeploymentPeriod;
            else if (Session["DeploymentPeriodId"] != null)
                partialView.DeploymentPeriodId = (int)Session["DeploymentPeriodId"];
            else if (deploymentPeriod.Count > 0)
                partialView.DeploymentPeriodId = deploymentPeriod[0].ID;
            else
                partialView.DeploymentPeriodId = 0;
            return PartialView("_DeploymentPeriods", partialView);
        }
    }
}