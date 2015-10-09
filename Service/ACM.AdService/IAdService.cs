
using ACM.Model;
using ACM.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ACM.Util.WCFUtil;
namespace ACM.AdService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    //[ServiceKnownType(typeof(AdLocation))]
    //[ServiceKnownType(typeof(AdRestriction))]
    //[ServiceKnownType(typeof(List<AdRestrictionAd>))]
    //[ServiceKnownType(typeof(Ad))]
    public interface IAdService
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Restrictions GetAdRestrictionCategory();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<AdOutStandingTask> GetOutstandingTask(ACM.Model.Ad request);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<ACM.Model.Ad> AdInfo(ACM.Model.Ad request);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        ACM.Model.Ad AdInq(ACM.Model.Ad request);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        ACM.Model.Ad AdAdd(ACM.Model.Ad request);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        string AdMod(ACM.Model.Ad request);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        string AdDel(ACM.Model.Ad request);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        string UpdateAdRestriction(ACM.Model.Ad request);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<AdlocationList> AdLocationsByCampaign(int campaignId, int adid);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Dictionary<string, string> CheckMediaFileTypes(string AdlocationCode);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<AdInfo_Result> AdsByCampaign(int campaignId, int deploymentPeriodId);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Dictionary<int, int> GetAdRestrictionFlag(int campaignId, int adid);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        string AdAdRestrictionFlagAdd(ACM.Model.Ad ad, List<int> flags, bool applyAll = false);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        ACM.Model.CustomModel.AdInfo AdInfoInq(int campaignId, int adid, int deploymentPeriodId);

       
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        string AdStatusModify(ACM.Model.AdDeploymentPeriod request);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        ACM.Model.AdDeploymentPeriod AdStatusInquiry(ACM.Model.AdDeploymentPeriod request, int deploymentPeriodId);
    }
}