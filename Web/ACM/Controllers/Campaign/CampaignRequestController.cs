/******************************************************************
 * Create Date: 03/04/2014
 * Created By: Elena Martirosyan
 * Update Date:
 * Updated By:
 *
 * Purpose: CampaignRequestController serves CampaignRequestEntry.cshtml
 * page to perform CRUD operations using RESTfull API.
 * ****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACM.BO.Campaign;
using ACM.Model;
//using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace ACM.Controllers.Campaign
{
    public class CampaignRequestController : Controller
    {
        // GET: /CampaignRequest/
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CampaignRequestEntry()
        {
            //Logger.SetLogWriter(new LogWriterFactory().Create());
            //LogEntry entry = new LogEntry();
            //entry.Message = "I am logging";
            
            //Logger.Write(entry);

           return View();
        }

        /// <summary>
        /// Load Users() function designed to handle AJAX call from 
        /// the application client and respond with the object in json 
        /// formatted. User initialization is done based on ad-ent id
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadUser()
        {
            //define local variables
            string LoginId = User.Identity.Name;
     
            List<User> AcmUser = new List<User>();
            CampaignRequestBO CampRequestBO = new CampaignRequestBO();

            LoginId = LoginId.Replace("AD-ENT\\", "");
            //Request the BO logic to handle existing user
            AcmUser = CampRequestBO.GetUserDetails(LoginId);

            //perform null check before accessing data
            //if not emty list will contain 1 list member associated
            //with ad-ent login
            if (AcmUser != null)
            {
                var UserResult = new
                {
                    Id = AcmUser[0].UserId,
                    LoginId = AcmUser[0].LoginId,
                    FirstName = AcmUser[0].FirstName,
                    LastName = AcmUser[0].LastName,
                    LOBId = AcmUser[0].LOBId,
                    LOBName = AcmUser[0].LOB.LOBName
                };
                return Json(UserResult, JsonRequestBehavior.AllowGet);
            }

            //provide empty list for none existing user
            var EmptyResult = new
            {
                FirstName = "Unknown",
                LastName = "User"
            };
            return Json(EmptyResult, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// LoadRegionTreeView() designed to format combined data 
        /// from 2 tables related to regions and super-regions into
        /// nested child nodes in json format
        /// example[{Childs=[{Childs=[{}, {}]}]}]
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadRegionTreeView()
        {
             //list local variables
            CampaignRequestBO CampRequestBO = new CampaignRequestBO();
            IEnumerable<Region> AcmRegions = (IEnumerable<Region>)CampRequestBO.GetRegions();
            List<object> RegionsTopNode = new List<object>();
            string CurrentSuperRegionId = "";
            
            //loop through region records and create a tree structure for 
            //interface tree view control. 
            //represent DisplayID as combination of SuperRegionId + "$" + RegionId
            foreach (var region in AcmRegions)
            {
                if (CurrentSuperRegionId != region.SuperRegionId.Trim())
                {
                    CurrentSuperRegionId = region.SuperRegionId.Trim();
                    //select all region id's that belog to  currently selected super region id
                    IEnumerable<Region> CurrentRegions = AcmRegions.Where(x => x.SuperRegionId.Trim() == CurrentSuperRegionId);
                    
                    //add fetched nodes to top node structure
                    RegionsTopNode.Add(new
                    {
                        displayID = region.SuperRegionId.Trim(),
                        displayText = region.SuperRegion.SuperRegionName,
                        defaultState= false,
                        Childs = (from item in CurrentRegions
                                  select new { displayID = CurrentSuperRegionId + "$" + item.RegionId, displayText = item.RegionName, defaultState = false, Childs = "" }).ToList()
                    });
                }
            }

           //create top level node to assotiate client control with data 
            //fetched from database
           var TreeViewResult = new
           {
               displayID = "", displayText = "All regions", defaultState = false, Childs = RegionsTopNode
           };
           return Json(TreeViewResult, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// SaveCampaign(ACM.Model.Campaign, ACM.Model.CampaignTargetFileProvider[], ACM.Model.CampaignLocation[])
        /// function was created to perform insert operation againsted combined pool of database tables[Campaign, CampaignTargetFileProviders, CampaignLocation]
        /// </summary>
        /// <param name="NewCampaign"> </param> new Campaign object
        /// <param name="NewCampaignTFPList"></param> list of target list providers 
        /// <param name=" NewCampaignLocationList"></param> list of campaign locations
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveCampaign(ACM.Model.Campaign NewCampaign, ACM.Model.CampaignTargetFileProvider[] NewCampaignTFPList, ACM.Model.CampaignLocation[] NewCampaignLocationList)
        {
            //list local variables

            CampaignRequestBO CampRequestBO = new CampaignRequestBO();
            CampRequestBO.SaveCampaign(NewCampaign, NewCampaignTFPList, NewCampaignLocationList);
            var SaveResult = new { result = "Changes Saved!" };

            return Json(SaveResult, JsonRequestBehavior.AllowGet);
        }
        
       }
}
