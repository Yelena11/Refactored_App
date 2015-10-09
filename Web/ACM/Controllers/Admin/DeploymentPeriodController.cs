using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACM.BO; 
namespace ACM.Controllers.Admin
{
    public class DeploymentPeriodController : Controller
    {
        //
        // GET: /DeploymentPeriod/

        public ActionResult DeploymentPeriodDashboard()
        {

            List<ACM.Model.DeploymentPeriod> deploymentperiod = new List<ACM.Model.DeploymentPeriod>();
            DeploymentPeriodBO deploymentPeriodbo = new DeploymentPeriodBO();
            deploymentperiod = deploymentPeriodbo.GetAllDeploymentPeriods();
            return View(deploymentperiod);
        }
        public JsonResult GetDeploymentPeriodDashboard(string sidx, string sord, int page, int rows)
        {
            List<ACM.Model.DeploymentPeriod> deploymentperiod = new List<ACM.Model.DeploymentPeriod>();
            //string loginId = Utility.LoginId(User.Identity.Name);

            DeploymentPeriodBO deploymentPeriodbo = new DeploymentPeriodBO();
            deploymentperiod = deploymentPeriodbo.GetAllDeploymentPeriods();
            switch (sidx.Trim())
            {
                case "DeploymentStartDate":
                    deploymentperiod = (sord == "asc") ? deploymentperiod.OrderBy(i => i.DeploymentStartDate).ToList() : deploymentperiod.OrderByDescending(i => i.DeploymentStartDate).ToList();
                    break;
                case "DeploymentEndEndDate":
                    deploymentperiod = (sord == "asc") ? deploymentperiod.OrderBy(i => i.DeploymentEndEndDate).ToList() : deploymentperiod.OrderByDescending(i => i.DeploymentEndEndDate).ToList();
                    break;

                case "DeploymentName":
                    deploymentperiod = (sord == "asc") ? deploymentperiod.OrderBy(i => i.DeploymentName).ToList() : deploymentperiod.OrderByDescending(i => i.DeploymentName).ToList();
                    break;

                case "Status":
                    deploymentperiod = (sord == "asc") ? deploymentperiod.OrderBy(i => i.Status).ToList() : deploymentperiod.OrderByDescending(i => i.Status).ToList();
                    break;
                //case "CampaignName":
                //    deploymentperiod = (sord == "asc") ? deploymentperiod.OrderBy(i => i.CampaignName).ToList() : deploymentperiod.OrderByDescending(i => i.CampaignName).ToList();
                //    break;
            }

            var totalRecords = deploymentperiod.Count();
            var assets = from a in deploymentperiod
                         select new
                         {
                             DeploymentPeriodId = a.DeploymentPeriodId,
                             DeploymentName = a.DeploymentName,
                             DeploymentStartDate =  a.DeploymentStartDate.ToShortDateString() ,
                             DeploymentEndEndDate=a.DeploymentEndEndDate.ToShortDateString() ,
                             Status = a.Status ,
                             Action="Edit"
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


        public ActionResult CreateDeploymentPeriod(int? deploymentPeirodId=0)
        {
             ACM.Model.DeploymentPeriod deploymentperiod = new Model.DeploymentPeriod();
            if (deploymentPeirodId == 0)
            {
               
                return View(deploymentperiod);
            }

            else
            {
                ACM.BO.DeploymentPeriodBO deploymentPeriodBO = new DeploymentPeriodBO();
                deploymentperiod.DeploymentPeriodId=Convert.ToInt32( deploymentPeirodId);
              deploymentperiod=   deploymentPeriodBO.DeploymentPeriodInquiry(deploymentperiod);  
              //  deploymentPeriodBO.DeploymenPeriodModification (deploymentperiod); 
 
               // DeploymentPeriodInquiry
              return View(deploymentperiod);
            }

            
        }

        public ActionResult CreateDeploymentPeriod1(int deploymentperiodid)
        {
            ACM.Model.DeploymentPeriod deploymentperiod = new Model.DeploymentPeriod();

            return View(deploymentperiod);
        }
    [HttpPost]
        public JsonResult    SaveDeploymentPeriod(ACM.Model.DeploymentPeriod deploymentperiod)
        {
            //return RedirectToAction("DeploymentPeriodDashboard");
            try
            {
                if (ModelState.IsValid)
                {
                    if (deploymentperiod.DeploymentPeriodId == 0)
                    {
                        deploymentperiod.CreatedDate = DateTime.Now;
                        DeploymentPeriodBO deploymentPeriodBO = new DeploymentPeriodBO();
                        deploymentPeriodBO.DeploymentPeriodAdd(deploymentperiod);
                       // return RedirectToRoute("DeploymentPeriodDashboard"); 
                    //    return RedirectToAction("DeploymentPeriodDashboard","DeploymentPeriod");
                       // return Json(deploymentperiod);
                        return Json(deploymentperiod);
                    }
                    else
                    {
                        deploymentperiod.ModifiedDate  = DateTime.Now ;
                        DeploymentPeriodBO deploymentPeriodBO = new DeploymentPeriodBO();
                      //  deploymentPeriodBO.DeploymentPeriodAdd(deploymentperiod);
                       // deploymentperiod = deploymentPeriodBO.DeploymentPeriodInquiry(deploymentperiod);
                        //deploymentperiod.Closed = "N";
                        //deploymentperiod.Status = "Open";
                         deploymentPeriodBO.DeploymenPeriodModification (deploymentperiod);
                       //  return RedirectToRoute("DeploymentPeriodDashboard"); 
                   //     return RedirectToAction("DeploymentPeriodDashboard","DeploymentPeriod");
                   //     return Json(deploymentperiod);
                     //    return RedirectToAction("DeploymentPeriodDashboard", "DeploymentPeriod");
                         return Json(deploymentperiod);
                    
                    }
                }
                else
                {
                    IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors);
                    return Json(errors);
                }
            }
            catch (Exception ex)
            {
                return Json("Error");
            }
          //  return Json(Url.Action("DeploymentPeriodDashboard", "DeploymentPeriod")); 


           // return RedirectToAction("DeploymentPeriodDashboard", "DeploymentPeriod");
        
        }
    }
}
