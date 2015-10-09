using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model;
using System.ServiceModel;
using ACM.Model.CustomModel;
using ACM.Util.WCFUtil;
namespace ACM.Interfaces.Campaign
{
    [ServiceContract]
    public interface ICampaign
    {
        [OperationContract()]
        List<ACM.Model.Campaign> GetAllCampaings();

        [OperationContract()]
        List<ACM.Model.Campaign> GetCampaign(int campaignId);

        [OperationContract()]
        List<CampaignTargetFileProvider> GetCampaignTargetFileProvider(int campaignId);

        [OperationContract()]
        List<CampaignLocation> GetCampaignLocation(int campaignId);

        [OperationContract()]
        IEnumerable<ACM.Model.CampaignRequestor> GetRequestorDashboard(int requestorId, int lobId, string status, bool isLobRequest);
        [OperationContract()]
        CampaignDetail CampaignDetials(int CampaignId);


        [OperationContract()]
        List<Region> GetRegions();
        [OperationContract()]
        void CancelCampaign(int CampaignId);

        [OperationContract()]
        List<User> GetRequestorDetails(int userId);

        [OperationContract()]
        void SaveCampaign(ACM.Model.Campaign campaign, ACM.Model.CampaignTargetFileProvider[] campaignTFPL, ACM.Model.CampaignLocation[] campaignLocList);


        #region Campaign

        [OperationContract()]
        [ReferencePreservingDataContractFormat]
        ACM.Model.Campaign CampaignInq(ACM.Model.Campaign request);
        [OperationContract()]
        [ReferencePreservingDataContractFormat]
        ACM.Model.Campaign CampaignAdd(ACM.Model.Campaign request);
        [OperationContract()]
        [ReferencePreservingDataContractFormat]
        string CampaignMod(ACM.Model.Campaign request);
        [OperationContract()]
        [ReferencePreservingDataContractFormat]
        string CampaignDel(ACM.Model.Campaign request);

        #endregion

        #region CampaignMainFrame
        [OperationContract()]
        List<ACM.Model.Campaign> CampaignInfo(ACM.Model.Campaign request);
        [OperationContract()]
        CampaignMainFrame CampaignMainframeInq(CampaignMainFrame request);
        [OperationContract()]
        string CampaignMainFrameAdd(CampaignMainFrame request);
        [OperationContract()]
        string CampaignMainFrameMod(CampaignMainFrame request);
        [OperationContract()]
        string CampaignMainFrameDel(CampaignMainFrame request);

        #endregion

        #region Followup
        [OperationContract()]
        List<CampaignFollowUp> CampaignFollowUpInfo(CampaignFollowUp request);
        [OperationContract()]
        CampaignFollowUp CampaignFollowUpInq(CampaignFollowUp request);
        [OperationContract()]
        string CampaignFollowUpAdd(CampaignFollowUp request);
        [OperationContract()]
        string CampaignFollowUpMod(CampaignFollowUp request);
        [OperationContract()]
        string CampaignFollowUpDel(CampaignFollowUp request);
        #endregion

        #region Targetfileprovider
        [OperationContract()]
        List<CampaignTargetFileProvider> CampaigTargetFileInfo(CampaignTargetFileProvider request);
        [OperationContract()]
        CampaignTargetFileProvider CampaigTargetFileInq(CampaignTargetFileProvider request);
        [OperationContract()]
        string CampaigTargetFileAdd(CampaignTargetFileProvider request);
        [OperationContract()]
        string CampaigTargetFileMod(CampaignTargetFileProvider request);
        [OperationContract()]
        string CampaigTargetFileDel(CampaignTargetFileProvider request);

        #endregion

        [OperationContract()]
        List<ACM.Model.Campaign> GetCampaignDashboard(string AcmUserId, string CampaignStatus);
        [OperationContract()]
        IEnumerable<GetDataForDropDownList> GetMasterDropDownDataforMasterTables(string MasterTableID, string MasterTableDescription, string MasterTableName);
        [OperationContract()]
        List<ACM.Model.Category> GetCategoryById(int SuperCategoryId);
        [OperationContract()]
        List<ACM.Model.SubCategory> GetSubCategoryById(int CategoryID);
       
    }
}