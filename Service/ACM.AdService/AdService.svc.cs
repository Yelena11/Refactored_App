using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ACM.Model;
using ACM.BO.Ad;
using ACM.Model.CustomModel;
//using ACM.Util.ApplicationException;

namespace ACM.AdService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AdService : IAdService
    {

        AdBO adBO = new AdBO();
        public Restrictions GetAdRestrictionCategory()
        {
            return adBO.GetAdRestrictionCategory();
        }


        public List<AdOutStandingTask> GetOutstandingTask(ACM.Model.Ad request)
        {
            return adBO.GetOutstandingTask(request);
        }

        public List<ACM.Model.Ad> AdInfo(ACM.Model.Ad request)
        {
            try
            {
                return adBO.AdInfo(request);
            }
            catch (Exception ex)
            {
                //Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "AdInfo");
                throw;
            }
        }

        public ACM.Model.Ad AdInq(ACM.Model.Ad request)
        {
            return adBO.AdInq(request);
        }


        public ACM.Model.Ad AdAdd(ACM.Model.Ad request)
        {
            return adBO.AdAdd(request);
        }


        public string AdMod(ACM.Model.Ad request)
        {
            return adBO.AdMod(request);
        }

        public string AdDel(ACM.Model.Ad request)
        {
            return adBO.AdDel(request);
        }


        public List<AdlocationList> AdLocationsByCampaign(int campaignId, int adid)
        {
            return adBO.AdLocationsByCampaign(campaignId, adid);
        }


        public Dictionary<string, string> CheckMediaFileTypes(string AdlocationCode)
        {
            AdLocationMediaBO adlocationBO = new AdLocationMediaBO();
            return adlocationBO.CheckMediaFileTypes(AdlocationCode);
        }


        public Dictionary<int, int> GetAdRestrictionFlag(int campaignId, int adid)
        {
            return adBO.GetAdRestrictionFlag(campaignId,adid);
        }

        public string AdAdRestrictionFlagAdd(Ad ad, List<int> flags, bool applyAll = false)
        {
            return adBO.AdAdRestrictionFlagAdd(ad, flags,applyAll);
        }


        public AdInfo AdInfoInq(int campaignId, int adid, int deploymentPeriodId)
        {
            return adBO.AdInfoInq(campaignId, adid, deploymentPeriodId);
        }


        public string UpdateAdRestriction(Ad request)
        {
            return adBO.UpdateAdRestriction(request);
        }

        public List<AdInfo_Result> AdsByCampaign(int campaignId, int deploymentPeriodId)
        {
            return adBO.AdsByCampaign(campaignId, deploymentPeriodId);
        }


        public string AdStatusModify(AdDeploymentPeriod request)
        {
            return adBO.AdStatusModify(request);
        }


        public AdDeploymentPeriod AdStatusInquiry(AdDeploymentPeriod request, int deploymentPeriodId)
        {
            return adBO.AdStatusInquiry(request, deploymentPeriodId);
        }
    }
}