using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model;
using ACM.Model.CustomModel;
using System.Transactions;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.DAO.Campaign
{
   public  class CampaignDAO
    {
       private ACM_Redesign2014Context ACMContex = new ACM_Redesign2014Context();
       
       public ACM.Model.Campaign GetCampaignInfoById(int campaignId)
       {
           try
           {
               ACMContex.Configuration.LazyLoadingEnabled = true;
               ACM.Model.Campaign campaign = ACMContex.Campaigns.Find(campaignId);
               return campaign;
           }
           catch (Exception ex)
           {
               Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetCampaignInfoById");
               throw;
           }
       }
       public IEnumerable<GetDataForDropDownList> GetMasterDropDownDataforMasterTables(string MasterTableID, string MasterTableDescription, string MasterTableName)
       {
           try
           {
               var listItems = (ACMContex.Database.SqlQuery<GetDataForDropDownList>("exec GetListforDropDown @Param1,@Param2,@Param3",
                  new SqlParameter("Param1", MasterTableID),
                  new SqlParameter("Param2", MasterTableDescription),
                  new SqlParameter("Param3", MasterTableName)

                  )).ToList();
               return listItems;
           }
           catch (Exception ex)
           {
               Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetMasterDropDownDataforMasterTables");
               throw;
           }
       }


       public List<ACM.Model.Campaign> CampaignInfo(ACM.Model.Campaign request)
       {
           List<ACM.Model.Campaign> response = new List<ACM.Model.Campaign>();
           try
           {
               using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
               {

                   ctx.Configuration.ProxyCreationEnabled = false;
                   if (request != null && request.RequestorId != null && request.RequestorId != 0)
                   {
                       response = (from campaign in ctx.Campaigns
                                   where campaign.RequestorId == request.RequestorId
                                   select campaign).ToList();
                   }
                   else
                       response = (from campaign in ctx.Campaigns
                                   select campaign).ToList();
                   ctx.Configuration.ProxyCreationEnabled = true;
               }
           }
           catch (Exception ex)
           {
               Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignInfo");
               throw;
           }

           return response;
       }



       public PartialViewInfo CampaignLeftNavigationDetails(int campaignId)
       {
           ACM.Model.Campaign response = new ACM.Model.Campaign();
           PartialViewInfo partialInfo = new PartialViewInfo();
           try
           {
               using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
               {
                   var listItems = (ctx.Database.SqlQuery<GetLeftNavDetails_Result>("GetLeftNavDetails  @CampaignId",
                     new SqlParameter("CampaignId", campaignId)

                     )).ToList();


                   foreach (var item in listItems)
                   {
                       partialInfo.CampaignId = item.campaignId;
                       partialInfo.CampaignType = item.CampaignTypeName;
                       partialInfo.CampaignName = item.campaignname;
                       partialInfo.ATMPM = item.primaryPMName;
                       partialInfo.SecondaryPM = item.secondaryPMName;
                       partialInfo.PromoButton = item.PromoButtonName;
                       partialInfo.Note = item.Notes;
                       partialInfo.Status = item.campaignstatus;
                   }

                   return partialInfo;
                       
               }
           }
           catch (Exception ex)
           {
               Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignLeftNavigationDetails");
               throw;
           }
       }
       public ACM.Model.Campaign CampaignInq(ACM.Model.Campaign request)
       {
           ACM.Model.Campaign response = new ACM.Model.Campaign();
           try
           {
               using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
               {
                   ctx.Configuration.LazyLoadingEnabled = true;
                   ctx.Configuration.ProxyCreationEnabled = false;
                   if (request != null)
                   {
                       response = ctx.Campaigns.Find(request.CampaignId);
                       ctx.Campaigns.Include("CampaignTableStatu").ToList();
                   }
               }
           }
           catch (Exception ex)
           {
               Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignInq");
               throw;
           }
           return response;
       }

       public ACM.Model.Campaign CampaignAdd(ACM.Model.Campaign request)
       {
           ACM.Model.Campaign response = new ACM.Model.Campaign();
           try
           {
               using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
               {
                   request.CreatedDate = DateTime.Now;


                   ctx.Campaigns.Add(request);
                   ctx.SaveChanges();
                   ctx.Configuration.ProxyCreationEnabled = false;
                   response = (from campaign in ctx.Campaigns
                               where campaign.CampaignGuid == request.CampaignGuid
                               orderby campaign.CampaignId descending
                               select campaign).First();
                   ctx.Configuration.ProxyCreationEnabled = true;
               }
           }
           catch (Exception ex)
           {
               Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignAdd");
               throw;
           }
           return response;
       }


       public string CampaignMod(ACM.Model.Campaign request)
       {
           try
           {
               using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
               {
                   request.ModifiedDate = DateTime.Now;
                   ctx.Entry(request).State = EntityState.Modified;
                   ctx.SaveChanges();
               }
           }
           catch (Exception ex)
           {
               Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
               throw;
           }
           return "Successfully updated";
       }

       public string CampaignDel(ACM.Model.Campaign request)
       {
           try
           {
               using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
               {
                   ACM.Model.Campaign campaign = ctx.Campaigns.Find(request.CampaignId);
                   ctx.Campaigns.Remove(request);
                   ctx.SaveChanges();

               }
           }
           catch (Exception ex)
           {
               Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignDel");
               throw;
           }
           return "Successfully deleted";
       }
    }
}
