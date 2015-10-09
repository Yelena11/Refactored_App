using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model;
using System.Data;
using ACM.Model.CustomModel;
using ACM.Util.ApplicationException;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ACM.DAO.Ad
{

    public class AdDAO
    {
        private ACM_Redesign2014Context ctx = null;
        public Restrictions GetAdRestrictionCategory()
        {
            Restrictions restriction = new Restrictions();
            try
            {
                using (ctx = new ACM_Redesign2014Context())
                {
                    ctx.Configuration.LazyLoadingEnabled = true;
                    var response = (from adres in ctx.AdRestrictions
                                    group adres by new { adres.ACMName, adres.AdRestrictionId } into r
                                    select new { ACMName = r.Key.ACMName, RestrictionID = r.Key.AdRestrictionId, ACMCategoryId = r.Max(d => d.ACMCategoryId) }).ToList();


                    List<Restrictions> restrictionList = new List<Restrictions>();
                    restriction.DepositoryType = new Dictionary<int, string>();
                    restriction.EFcutoff = new Dictionary<int, string>();
                    restriction.Other = new Dictionary<int, string>();

                    foreach (var item in response)
                    {
                        switch (item.ACMCategoryId)
                        {
                            case (Int32)AdRestrictionFlag.DepositoryType:
                                restriction.DepositoryType.Add(item.RestrictionID, item.ACMName);
                                break;
                            case (Int32)AdRestrictionFlag.EFcutoff:
                                restriction.EFcutoff.Add(item.RestrictionID, item.ACMName);
                                break;
                            case (Int32)AdRestrictionFlag.Other:
                                restriction.Other.Add(item.RestrictionID, item.ACMName);
                                break;
                        }
                    }
                }
                return restriction;
            }

            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetAdRestrictionCategory");
                throw;
            }
        }

        public List<AdOutStandingTask> GetOutstandingTask(ACM.Model.Ad request)
        {
            List<AdOutStandingTask> response = new List<AdOutStandingTask>();
            try
            {

                using (ctx = new ACM_Redesign2014Context())
                {
                    ctx.Configuration.LazyLoadingEnabled = true;
                    response = (from tasks in ctx.AdOutStandingTasks
                                where tasks.AdId == request.AdId
                                select tasks).ToList();
                }
                return response;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetOutstandingTask");
                throw;
            }
        }

        public List<ACM.Model.Ad> AdInfo(ACM.Model.Ad request)
        {
            try
            {
                List<ACM.Model.Ad> response = new List<ACM.Model.Ad>();
                using (ctx = new ACM_Redesign2014Context())
                {
                    ctx.Configuration.LazyLoadingEnabled = true;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    response = (from ad in ctx.Ads
                                where ad.CampaignId == request.CampaignId
                                select ad).ToList();
                    //  ctx.Ads.Include("AdRestriction").ToList();
                    ctx.Ads.Include("AdLocation").ToList();
                    ctx.Ads.Include("AdProductType").ToList();
                    ctx.Configuration.ProxyCreationEnabled = true;

                }
                return response;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "AdInfo");
                throw;
            }
        }

        public ACM.Model.Ad AdInq(ACM.Model.Ad request)
        {
            ACM.Model.Ad response = new ACM.Model.Ad();
            try
            {
                using (ctx = new ACM_Redesign2014Context())
                {
                    ctx.Configuration.LazyLoadingEnabled = true;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    response = (from ad in ctx.Ads
                                where ad.CampaignId == request.CampaignId && ad.AdId == request.AdId
                                select ad).FirstOrDefault();
                    //   /ctx.Ads.Include("AdRestriction").ToList();
                    ctx.Ads.Include("AdLocation").ToList();
                    ctx.Ads.Include("AdProductType").ToList();
                    ctx.Configuration.ProxyCreationEnabled = true;
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "AdInq");
                throw;
            }
            return response;
        }

        public ACM.Model.AdDeploymentPeriod AdStatusInquiry(ACM.Model.AdDeploymentPeriod request, int deploymentPeriodId)
        {
            ACM.Model.AdDeploymentPeriod response = new ACM.Model.AdDeploymentPeriod();
            try
            {
                using (ctx = new ACM_Redesign2014Context())
                {
                    ctx.Configuration.LazyLoadingEnabled = true;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    response = (from ad in ctx.AdDeploymentPeriods
                                where ad.CampaignId == request.CampaignId && ad.Adid == request.Adid && ad.DeploymentPeriodId== deploymentPeriodId
                                select ad).FirstOrDefault();
                    ctx.Configuration.ProxyCreationEnabled = true;
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "AdInq");
                throw;
            }
            return response;
        }

        public ACM.Model.CustomModel.AdInfo AdInfoInq(int campaignId, int adid, int deploymentPeriodId)
        {
            ACM.Model.CustomModel.AdInfo adInfo = new Model.CustomModel.AdInfo();
            List<AdRestrictions> listRes = new List<AdRestrictions>();
            try
            {
                using (ctx = new ACM_Redesign2014Context())
                {
                    var listItems = (ctx.Database.SqlQuery<AdInfo_Result>("AdInfo @DeploymentPeriodId, @CampaignId, @Adid",
                                        new SqlParameter("DeploymentPeriodId", deploymentPeriodId),
                                        new SqlParameter("CampaignId", campaignId),
                                        new SqlParameter("Adid", adid)

                      )).SingleOrDefault();

                    adInfo.Ad = listItems;
                    var adResInfo = (from ad in ctx.AdRestrictionAds
                                     where ad.CampaignId == campaignId && ad.AdId == adid
                                     select new { Id = ad.Id, AdRestrictionId = ad.AdRestrictionId, AdId = ad.AdId, CampaignId = ad.CampaignId }).ToList();

                    AdRestrictions adRes = new AdRestrictions();
                    foreach (var item in adResInfo)
                    {
                        adRes = new AdRestrictions();
                        adRes.AdId = item.AdId;
                        adRes.AdRestrictionId = item.AdRestrictionId;
                        adRes.CampaignId = item.CampaignId;
                        adRes.Id = item.Id;
                        listRes.Add(adRes);
                    }

                    adInfo.AdRestriction = listRes;
                }
                return adInfo;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetMasterDropDownDataforMasterTables");
                throw;
            }
        }




        public ACM.Model.Ad AdAdd(ACM.Model.Ad request)
        {
            ACM.Model.Ad response = new ACM.Model.Ad();
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.Ads.Add(request);
                    ctx.SaveChanges();

                    response = (from ad in ctx.Ads
                                where ad.AdGuid == request.AdGuid
                                orderby ad.AdId descending
                                select ad).First();
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "AdAdd");
                throw;
            }
            return response;
        }


        public string AdMod(ACM.Model.Ad request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.Entry(request).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "AdMod");
                throw;
            }
            return "Successfully updated";
        }

        public string AdStatusModify(ACM.Model.AdDeploymentPeriod request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.Entry(request).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "AdMod");
                throw;
            }
            return "Successfully updated";
        }

        public string AdDel(ACM.Model.Ad request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ACM.Model.Ad ad = ctx.Ads.Find(request.AdId);
                    ctx.Ads.Remove(ad);
                    ctx.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "AdDel");
                throw;
            }
            return "Successfully deleted";
        }

        public string UpdateAdRestriction(ACM.Model.Ad request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    var listAd = (from ads in ctx.Ads
                                  where ads.CampaignId == request.CampaignId
                                  select ads.AdId).ToList();

                    var some = ctx.Ads.Where(x => listAd.Contains(x.AdId)).ToList();
                    some.ForEach(a => a.AdRestrictionId = request.AdRestrictionId);

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "UpdateAdRestriction");
                throw;
            }
            return "Ad restriction applied for the campaign";
        }

        public List<AdlocationList> AdLocationsByCampaign(int campaignId, int adid)
        {
            string status = "Edit";
            if (adid == 0)
                status = "New";

            try
            {
                using (ctx = new ACM_Redesign2014Context())
                {
                    var listItems = (ctx.Database.SqlQuery<AdlocationList>("SP_GetAdLocationsByCampaignType @CampaignId, @Status,@adid",
                      new SqlParameter("CampaignId", campaignId),
                      new SqlParameter("Status", status),
                      new SqlParameter("adid",adid)
                      )).ToList();
                    return listItems;
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetMasterDropDownDataforMasterTables");
                throw;
            }
        }


        public List<AdInfo_Result> AdsByCampaign(int campaignId, int deploymentPeriodId)
        {
            try
            {
                using (ctx = new ACM_Redesign2014Context())
                {
                    var listItems = (ctx.Database.SqlQuery<AdInfo_Result>("AdInfo @DeploymentPeriodId, @CampaignId",
                         new SqlParameter("DeploymentPeriodId", deploymentPeriodId),
                      new SqlParameter("CampaignId", campaignId)

                      )).ToList();

                    return listItems;
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetMasterDropDownDataforMasterTables");
                throw;
            }
        }

        public Dictionary<int, int> GetAdRestrictionFlag(int campaignId, int adid)
        {
            string adRestrictionIds = string.Empty;
            Dictionary<int, int> res = new Dictionary<int, int>();
            try
            {
                using (ctx = new ACM_Redesign2014Context())
                {
                    var result = (ctx.Database.SqlQuery<GetRestrictionFlag>("SP_GetAdRestrictionFlag @campaignId, @adid",
                      new SqlParameter("campaignId", campaignId),
                   new SqlParameter("adid", adid)

                   )).ToList();



                    foreach (var item in result)
                    {
                        res.Add(item.CategoryID, item.RestrictionID);
                    }

                    adRestrictionIds = string.Join(",", result);
                }
                return res;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetAdRestrictionCode");
                throw;
            }
        }
        public string AdAdRestrictionFlagAdd(int adid, int campaignId, List<int> flags, bool applyAll = false)
        {

            string retVal = string.Empty;
            try
            {
                if (flags.Count > 0)
                {
                    var splitFlag = string.Join(",", flags);
                    int applyToAllAd = 0;
                    if (applyAll)
                        applyToAllAd = 1;
                    using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                    {
                        ctx.Database.ExecuteSqlCommand("SP_Adrestrictions @AdRestrictionId, @AdId, @CampaignId, @applyAll",
                          new SqlParameter("AdRestrictionId", splitFlag),
                           new SqlParameter("AdId", adid),
                            new SqlParameter("CampaignId", campaignId),
                             new SqlParameter("applyAll", applyToAllAd)
                          );
                    }
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "AdAdd");
                throw;
            }
            return retVal;
        }

    }
}