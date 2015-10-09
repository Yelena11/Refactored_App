using ACM.DAO.Ad;
using ACM.Model;
using ACM.Model.CustomModel;
using ACM.Util.ApplicationException;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ACM.Util.ApplicationException;

namespace ACM.BO.Ad
{
    public class AdBO
    {
        AdDAO adDAO = new AdDAO();
        public Restrictions GetAdRestrictionCategory()
        {
            return adDAO.GetAdRestrictionCategory();
        }

        public List<AdOutStandingTask> GetOutstandingTask(ACM.Model.Ad request)
        {
            return adDAO.GetOutstandingTask(request);
        }

        public List<ACM.Model.Ad> AdInfo(ACM.Model.Ad request)
        {
            try
            {
                return adDAO.AdInfo(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "AdInfo");
                throw;
            }
        }

        public ACM.Model.CustomModel.AdInfo AdInfoInq(int campaignId, int adid, int deploymentPeriodId)
        {
            return adDAO.AdInfoInq(campaignId, adid,deploymentPeriodId);
        }

        public ACM.Model.Ad AdInq(ACM.Model.Ad request)
        {
            return adDAO.AdInq(request);
        }

        public ACM.Model.AdDeploymentPeriod AdStatusInquiry(ACM.Model.AdDeploymentPeriod request, int deploymentPeriodId)
        {
            return adDAO.AdStatusInquiry(request, deploymentPeriodId);
        }
        public ACM.Model.Ad AdAdd(ACM.Model.Ad request)
        {
            return adDAO.AdAdd(request);
        }


        public string AdMod(ACM.Model.Ad request)
        {
            return adDAO.AdMod(request);
        }

        public string AdStatusModify(ACM.Model.AdDeploymentPeriod request)
        {
            return adDAO.AdStatusModify(request);
        }
        public string AdDel(ACM.Model.Ad request)
        {
            return adDAO.AdDel(request);
        }

        public string UpdateAdRestriction(ACM.Model.Ad request)
        {
            return adDAO.UpdateAdRestriction(request);
        }

        //util function call 
        public static IEnumerable<GetDataForDropDownList> GetMasterDropDownDataforMasterTables(string MasterTableID, string MasterTableDescription, string MasterTableName)
        {
            return ACM.DAO.Util.Common.GetMasterDropDownDataforMasterTables(MasterTableID, MasterTableDescription, MasterTableName);
        }
        public List<AdlocationList> AdLocationsByCampaign(int campaignId, int adid)
        {
            return adDAO.AdLocationsByCampaign(campaignId, adid);
        }
        public Dictionary<int, int> GetAdRestrictionFlag(int campaignId, int adid)
        {
            return adDAO.GetAdRestrictionFlag(campaignId, adid);
        }


        public string AdAdRestrictionFlagAdd(ACM.Model.Ad ad, List<int> flags, bool applyAll = false)
        {
            List<ACM.Model.AdRestrictionAd> requestRestrictionAds = new List<AdRestrictionAd>();
            ACM.Model.AdRestrictionAd requestRestrictionAd = new AdRestrictionAd();

            return adDAO.AdAdRestrictionFlagAdd(ad.AdId, ad.CampaignId, flags, applyAll);
        }

        public List<AdInfo_Result> AdsByCampaign(int campaignId, int deploymentPeriodId)
        {
            return adDAO.AdsByCampaign(campaignId, deploymentPeriodId);
        }
    }
}