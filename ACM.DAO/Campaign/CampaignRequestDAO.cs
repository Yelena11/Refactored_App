using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model;
using ACM.Model.CustomModel;
using System.Transactions;
using System.Data.Entity;


namespace ACM.DAO.Campaign
{
    public class CampaignRequestDAO
    {
        private ACM_Redesign2014Context ACMContex = new ACM_Redesign2014Context();

        public List<ACM.Model.Campaign> GetCampaign(int campaignId)
        {
            ACMContex.Configuration.LazyLoadingEnabled = true;

            List<ACM.Model.Campaign> campaign = ACMContex.Campaigns.ToList();
            List<ACM.Model.Campaign> campaignById = campaign.Where(x => x.CampaignId.Equals(campaignId)).ToList(); ;

            ACMContex.Configuration.ProxyCreationEnabled = false;
            ACMContex.Campaigns.Include("User").ToList();
            ACMContex.Configuration.ProxyCreationEnabled = true;


            return campaignById;
        }

        public List<CampaignTargetFileProvider> GetCampaignTargetFileProvider(int campaignId)
        {
            List<CampaignTargetFileProvider> campaignTargetFileProvider = ACMContex.CampaignTargetFileProviders.ToList();
            List<CampaignTargetFileProvider> campaignTargetFileProviderById = campaignTargetFileProvider.Where(x => x.CampaignId.Equals(campaignId)).ToList(); ;

            return campaignTargetFileProviderById;
        }

        public List<CampaignLocation> GetCampaignLocation(int campaignId)
        {
            List<CampaignLocation> campaignLocation = ACMContex.CampaignLocations.ToList();
            List<CampaignLocation> campaignLocationById = campaignLocation.Where(x => x.CampaignId.Equals(campaignId)).ToList(); ;

            return campaignLocationById;
        }

        public User GetUserDetail(int id)
        {

            ACMContex.Configuration.LazyLoadingEnabled = true;

            var userDetails = ACMContex.Users.Where(x => x.UserId.Equals(id));
            User user = new User();
            foreach (var item in userDetails)
            {
                user.UserId  = item.UserId;
                user.LoginId = item.LoginId;
                user.FirstName = item.FirstName;
                user.LastName = item.LastName;
                user.CreatedBy = item.CreatedBy;
                user.CreatedDate = item.CreatedDate;
                user.LOBId = item.LOBId;
                user.Status = item.Status;
            }

            return user;
        }

        public List<User> GetUserDetails(string loginId)
        {

            ACMContex.Configuration.LazyLoadingEnabled = true;

            List<User> userDetails = ACMContex.Users.ToList();
            List<User> userDetailsByLoginId = userDetails.Where(x => x.LoginId.Contains(loginId)).ToList();


            ACMContex.Configuration.ProxyCreationEnabled = false;
            ACMContex.Users.Include("LOB").ToList();
            ACMContex.Configuration.ProxyCreationEnabled = true;

            return userDetailsByLoginId;
        }
        /*
            select user1.firstName reqName ,user2.firstname pmName from 
            campaign c ,users user1, users user2
            where c.requestorid=user1.id
            and c.assignedpmid=user2.id
         */

        public List<ACM.Model.CampaignRequestor> GetRequestorDashboard(int requestorId, int lobId, string status, bool isLobRequest)
        {
            ACM.Model.CampaignRequestor campaignRequestor = new ACM.Model.CampaignRequestor();
            List<ACM.Model.CampaignRequestor> campaignRequestorList = new List<ACM.Model.CampaignRequestor>();
            
            if (isLobRequest)
            {
                var result = (from camp in ACMContex.Campaigns
                              from user1 in ACMContex.Users
                              from user2 in ACMContex.Users
                              where camp.RequestorId == user1.UserId && camp.AssignedPMId == user2.UserId
                              select new { camp, firstname = user1.FirstName, lastname = user1.LastName, status = user1.Status, user1.LastName, firstname1 = user2.FirstName, firstname2 = user2.LastName }).ToList();
                foreach (var data in result)
                {
                    campaignRequestor = new ACM.Model.CampaignRequestor();
                    campaignRequestor.CampaignId = data.camp.CampaignId;
                    campaignRequestor.CampaignName = data.camp.CampaignName;
                    campaignRequestor.AssignedPMId = data.camp.AssignedPMId;

                    //int maxid = ACMContex.Users.Select(r => r.CampaignId).Max();
                     
                    //shravan changes to sprint 2
                    campaignRequestor.LOBId = data.camp.User.UserId ;
                    campaignRequestor.AssignedPMFirstName = data.firstname1;
                    campaignRequestor.AssignedPMLastName = data.firstname2;
                    campaignRequestor.RequestorId =Convert.ToInt32 (  data.camp.RequestorId);
                    campaignRequestor.CampaignStartDate =Convert.ToDateTime(  data.camp.CampaignStartDate);
                    campaignRequestor.CampaingEndDate = Convert.ToDateTime(  data.camp.CampaingEndDate);
                    campaignRequestor.RequestorFirstName = data.firstname;
                    campaignRequestor.RequestorLastName = data.lastname;
                    campaignRequestor.CampaignStatus = data.camp.CampaignStatus;

                    if ((campaignRequestor.CampaignStatus == "Pending Review" && campaignRequestor.RequestorId == requestorId))
                        campaignRequestor.Action = "Cancel";
                    else
                        campaignRequestor.Action = "";

                    campaignRequestorList.Add(campaignRequestor);

                }
            }
            else
            {
                var result = (from camp in ACMContex.Campaigns
                              from user1 in ACMContex.Users
                              from user2 in ACMContex.Users
                              where camp.RequestorId == user1.UserId && camp.AssignedPMId == user2.UserId && camp.RequestorId == requestorId
                              select new { camp, firstname = user1.FirstName, lastname = user1.LastName, status = user1.Status, user1.LastName, firstname1 = user2.FirstName, firstname2 = user2.LastName }).ToList();
                foreach (var data in result)
                {
                    campaignRequestor = new ACM.Model.CampaignRequestor();
                    campaignRequestor.CampaignId = data.camp.CampaignId;
                    campaignRequestor.CampaignName = data.camp.CampaignName;
                    campaignRequestor.AssignedPMId = data.camp.AssignedPMId;
                   
                     
                    campaignRequestor.LOBId = data.camp.User.UserId ;
                    campaignRequestor.AssignedPMFirstName = data.firstname1;
                    campaignRequestor.AssignedPMLastName = data.firstname2;
                    campaignRequestor.RequestorId = Convert.ToInt32(  data.camp.RequestorId);
                    campaignRequestor.CampaignStartDate = Convert.ToDateTime(data.camp.CampaignStartDate);
                    campaignRequestor.CampaingEndDate =Convert.ToDateTime( data.camp.CampaingEndDate);
                    campaignRequestor.RequestorFirstName = data.firstname;
                    campaignRequestor.RequestorLastName = data.lastname;
                    campaignRequestor.CampaignStatus = data.camp.CampaignStatus;

                    if ((campaignRequestor.CampaignStatus == "Pending Review" && campaignRequestor.RequestorId == requestorId))
                        campaignRequestor.Action = "Cancel";
                    else
                        campaignRequestor.Action = "";

                    campaignRequestorList.Add(campaignRequestor);

                }
            }


            return campaignRequestorList;
        }

        public List<User> GetRequestorDetails(int userId)
        {
            ACMContex.Configuration.LazyLoadingEnabled = true;

            List<User> userDetails = ACMContex.Users.ToList();
            List<User> userDetailsById = userDetails.Where(x => x.LoginId.Equals(userId)).ToList(); ;

            ACMContex.Configuration.ProxyCreationEnabled = false;
            ACMContex.Campaigns.Include("LOB").ToList();
            ACMContex.Configuration.ProxyCreationEnabled = true;

            return userDetailsById;
        }


        public List<Region> GetRegions()
        {
            ACMContex.Configuration.LazyLoadingEnabled = true;

            List<Region> regions = ACMContex.Regions.OrderBy(t => t.SuperRegionId).ToList();

            ACMContex.Configuration.ProxyCreationEnabled = false;
            ACMContex.Regions.Include("SuperRegion").ToList();
            ACMContex.Configuration.ProxyCreationEnabled = true;

            return regions;
        }

        public void CancelCampaign(int CampaignId)
        {

            try
            {

                ACM.Model.Campaign campaign = ACMContex.Campaigns.First(i => i.CampaignId == CampaignId);

                campaign.CampaignStatus = "Cancelled";

                List<CampaignTargetFileProvider> campaignTargetFileProviderList = ACMContex.CampaignTargetFileProviders.ToList();
                List<CampaignTargetFileProvider> campaignTargetFileProviderListByCampaignId = campaignTargetFileProviderList.Where(x => x.CampaignId.Equals(CampaignId)).ToList();
                //shravan changes for sprint 2
                //if (campaignTargetFileProviderListByCampaignId != null)
                //{

                //    foreach (CampaignTargetFileProvider campaignTargetFileProvider in campaignTargetFileProviderListByCampaignId)
                //    {
                //        campaignTargetFileProvider.Status = "Cancelled";

                //    }
                //}
                //List<CampaignLocation> campaignLocationList = ACMContex.CampaignLocations.ToList();
                //List<CampaignLocation> campaignLocationListByCampaignId = campaignLocationList.Where(x => x.CampaignId.Equals(CampaignId)).ToList();

                //if (campaignLocationListByCampaignId != null)
                //{

                //    foreach (CampaignLocation campaignTargetFileProvider in campaignLocationListByCampaignId)
                //    {
                //        campaignTargetFileProvider.Status = "Cancelled";

                //    }
                //}

                ACMContex.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public LOB GetLobDetail(int id)
        {

            ACMContex.Configuration.LazyLoadingEnabled = true;

            var Lobs = ACMContex.LOBs.Where(x => x.LOBId.Equals(id));
            LOB lob = new LOB();
            foreach (var item in Lobs)
            {
                lob.LOBId = item.LOBId;
                lob.LOBName = item.LOBName;
                lob.Status = item.Status;
                lob.CreatedBy = item.CreatedBy;
                lob.CreatedDate = item.CreatedDate;
            }
            return lob;
        }

        public CampaignDetail CampaignDetials(int CampaignId)
        {
            ACMContex.Configuration.LazyLoadingEnabled = true;
            ACM.Model.User user = new ACM.Model.User();
            LOB lob = new LOB();

            CampaignDetail campaignObj = new CampaignDetail();

            var campaign = ACMContex.Campaigns.Where(x => x.CampaignId.Equals(CampaignId));
            
            foreach (var item in campaign)
            {
                campaignObj.CampaignId = item.CampaignId;
                
                campaignObj.RequestorId = item.RequestorId;
                int requestorId = (Int32)item.RequestorId;
 
                if (requestorId != 0)
                {
                    user = GetUserDetail(requestorId);
                    campaignObj.RequestorFirstName = user.FirstName;
                    campaignObj.RequestorLastName = user.LastName;
                    campaignObj.RequestorName = campaignObj.RequestorFirstName +" "+ campaignObj.RequestorLastName;
                }
                campaignObj.LOBId = item.User.LOBId;
                int lobId = (Int32)item.User.LOBId;
                if (lobId != 0)
                {
                    lob = GetLobDetail(lobId);
                    campaignObj.LOBName = lob.LOBName;
                }

                campaignObj.AssignedPMId = item.AssignedPMId;
                int assignedPMId =(Int32) item.AssignedPMId;
                if (assignedPMId != 0)
                {
                    user = GetUserDetail(assignedPMId);
                    campaignObj.AssignedPMFirstName = user.FirstName;
                    campaignObj.AssignedPMLastName = user.LastName;
                    campaignObj.AssignedPMName = campaignObj.AssignedPMFirstName +" "+ campaignObj.AssignedPMLastName;
                }
                campaignObj.CampaignName = item.CampaignName;
                if (item.ModifiedBy != 0 && item.ModifiedDate != null)
                {
                    int modifyBy = item.ModifiedBy;
                    user = GetUserDetail(modifyBy);
                    campaignObj.ModifiedBy = item.ModifiedBy;  
                    campaignObj.ModifiedByFirstName = user.FirstName;
                    campaignObj.ModifiedByLastName = user.LastName;
                    campaignObj.ModifiedByName = campaignObj.ModifiedByFirstName +" "+ campaignObj.ModifiedByLastName; 
                    campaignObj.ModifiedDate = Convert.ToDateTime(item.ModifiedDate);
                }
                campaignObj.CampaignDetails = item.CampaignDetails;
                
                campaignObj.CampaignTypeId = Convert.ToInt32(item.CampaignTypeId);
                if (item.CampaignTypeId.Equals(1))
                    campaignObj.CampaignTypeName = "Yes";
                if (item.CampaignTypeId.Equals(2))
                    campaignObj.CampaignTypeName = "No";
                
                campaignObj.TargetAudience = item.TargetAudience;
                campaignObj.FollowUpRequriements = item.FollowUpRequriements;

                campaignObj.CampaignStartDate =Convert.ToDateTime( item.CampaignStartDate);
                campaignObj.CampaingEndDate = Convert.ToDateTime(item.CampaingEndDate);
                
            }

            var campaignTargetFileProviderList = ACMContex.CampaignTargetFileProviders.Where(x => x.CampaignId.Equals(CampaignId));
           
            if (campaignTargetFileProviderList != null)
            {
                campaignObj.CampaignTargetFileProvider = new List<CampaignTargetFileProvider>(campaignTargetFileProviderList);
                /*
                CampaignTargetFileProvider campaignTargetFileProvider = new CampaignTargetFileProvider();

                foreach (var item in campaignTargetFileProviderList)
                {
                    campaignTargetFileProvider = new CampaignTargetFileProvider();

                    campaignTargetFileProvider.CampaignId = item.CampaignId;
                    campaignTargetFileProvider.Frequency = item.Frequency;
                    campaignTargetFileProvider.TargetFileProviderDesc = item.TargetFileProviderDesc;

                    campaignObj.CampaignTargetFileProvider.Add(campaignTargetFileProvider);

                }
                */

            }
                var campaignLocationList = ACMContex.CampaignLocations.Where(x => x.CampaignId.Equals(CampaignId));

                if (campaignLocationList != null)
                {
                    campaignObj.CampaignLocation = new List<CampaignLocation>(campaignLocationList);
                   /*
                    CampaignLocation campaignLocation = new CampaignLocation();

                    foreach (var item in campaignLocationList)
                    {
                        campaignLocation = new CampaignLocation();
                        campaignLocation.CampaignId = item.CampaignId;

                        campaignObj.CampaignLocation.Add(campaignLocation);
                    }
                    */
                }

            return campaignObj;
        }



        public void SaveCampaign(ACM.Model.Campaign campaign, List<CampaignTargetFileProvider> campaignTargetFileProviderList, List<CampaignLocation> campaignLocationList)
        {

            try
            {

                /*
                   ACM.Model.Campaign campaignObj = new ACM.Model.Campaign();
                   {
                       campaignObj.CampaignId = campaign.CampaignId;
                       campaignObj.RequestorId = campaign.RequestorId;
                       campaignObj.LOBId = campaign.LOBId;
                       campaignObj.CampaignName = campaign.CampaignName;
                   }

                   ACMContex.Campaigns.Add(campaignObj);
                */

                // ACMContex.Entry(campaign).State = EntityState.Modified;

                int maxid = ACMContex.Campaigns.Select(r => r.CampaignId).Max();
                campaign.CampaignId = maxid + 1;

                ACMContex.Campaigns.Add(campaign);

                if (campaignTargetFileProviderList != null)
                {
                    foreach (CampaignTargetFileProvider campaignTargetFileProvider in campaignTargetFileProviderList)
                    {

                        CampaignTargetFileProvider campaignTargetFileProviderObj = new CampaignTargetFileProvider();
                        campaignTargetFileProvider.CampaignId = maxid + 1;


                        //int CampaignLocationId = ACMContex.CampaignTargetFileProviders .Select(r => r.Id).Max();
                        //campaignTargetFileProvider.Id = CampaignLocationId + 1;

                        /*
                       campaignTargetFileProviderObj.CampaignId = campaignTargetFileProvider.CampaignId;
                       campaignTargetFileProviderObj.TargetFileProviderDesc = campaignTargetFileProvider.TargetFileProviderDesc;
                       campaignTargetFileProviderObj.Frequency = campaignTargetFileProvider.Frequency;
                       campaignTargetFileProviderObj.CreatedBy = campaignTargetFileProvider.CreatedBy;
                       campaignTargetFileProviderObj.CreatedDate = campaignTargetFileProvider.CreatedDate;
                       campaignTargetFileProviderObj.ModifiedBy = campaignTargetFileProvider.ModifiedBy;
                       campaignTargetFileProviderObj.ModifiedDate = campaignTargetFileProvider.ModifiedDate;
                       campaignTargetFileProviderObj.Status = campaignTargetFileProvider.Status;
                       */
                        campaignTargetFileProvider.Status = "Active";
                        ACMContex.CampaignTargetFileProviders.Add(campaignTargetFileProvider);
                    }
                }

                if (campaignLocationList != null)
                {
                    foreach (CampaignLocation campaignLocation in campaignLocationList)
                    {
                        CampaignLocation campaignLocationObj = new CampaignLocation();
                        campaignLocationObj.CampaignId = maxid + 1;  
                    //    campaignLocationObj.CampaignId = campaignLocation.CampaignId;
                        campaignLocationObj.RegionId = campaignLocation.RegionId;
                        campaignLocationObj.SuperRegionId = campaignLocation.SuperRegionId;
                        //campaignLocationObj.SpecifyRegionName = campaignLocation.SpecifyRegionName;
                        campaignLocationObj.CreatedBy = campaignLocation.CreatedBy;
                        campaignLocationObj.CreatedDate = campaignLocation.CreatedDate;
                        campaignLocationObj.ModifiedBy = campaignLocation.ModifiedBy;
                        campaignLocationObj.ModifiedDate = campaignLocation.ModifiedDate;
                     //   campaignLocationObj.Status = campaignLocation.Status;

                        ACMContex.CampaignLocations.Add(campaignLocationObj);

                    }
                }
                //ACMContex.Campaigns.Add   
                ACMContex.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }


        public Model.Campaign GetCampaignInfoById(int campaignId)
        {
            throw new NotImplementedException();
        }
    }
}
