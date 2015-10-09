using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Interfaces.Campaign ;
 using ACM.Model.CustomModel ;
namespace ACM.BO.Campaign
{
    public class CampaignMgr : ICampaign
    {
        public List<Model.Campaign> GetAllCampaings()
        {
            return GetAllCampaings();
        }

        public List<Model.Campaign> GetCampaign(int campaignId)
        {
            CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
            return campaignRequestBO.GetCampaign(campaignId);
        }

        public List<Model.CampaignTargetFileProvider> GetCampaignTargetFileProvider(int campaignId)
        {
            CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
            return campaignRequestBO.GetCampaignTargetFileProvider(campaignId);
        }

        public List<Model.CampaignLocation> GetCampaignLocation(int campaignId)
        {
            CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
            return campaignRequestBO.GetCampaignLocation(campaignId);
        }



        public List<Model.Region> GetRegions()
        {
            CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
            return campaignRequestBO.GetRegions();
        }


        public List<Model.User> GetRequestorDetails(int userId)
        {
            CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
            return campaignRequestBO.GetRequestorDetails(userId);
        }


        public IEnumerable<ACM.Model.CampaignRequestor> GetRequestorDashboard(int requestorId, int lobId, string status, bool isLobRequest)
        {
            CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
            return campaignRequestBO.GetRequestorDashboard(requestorId, lobId, status, isLobRequest);
        }

        public void SaveCampaign(ACM.Model.Campaign campaign, ACM.Model.CampaignTargetFileProvider[] campaignTFPL, ACM.Model.CampaignLocation[] campaignLocList)
        {
            CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
             campaignRequestBO.SaveCampaign(campaign,  campaignTFPL,  campaignLocList);
 
        }

        public void CancelCampaign(int CampaignId) {
            CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
            campaignRequestBO.CancelCampaign(CampaignId); 
        
        }

        public CampaignDetail CampaignDetials(int CampaignId)
        {
            CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
           return  campaignRequestBO.CampaignDetials(CampaignId);  

        }




        public Model.Campaign CampaignInq(Model.Campaign request)
        {
            CampaignBO campaignBO = new CampaignBO();
            return campaignBO.CampaignInq(request);  

        }

        public ACM.Model.Campaign CampaignAdd(Model.Campaign request)
        {
            CampaignBO campaignBO = new CampaignBO();
            return campaignBO.CampaignAdd(request);  

        }

        public string CampaignMod(Model.Campaign request)
        {
            CampaignBO campaignBO = new CampaignBO();
            return campaignBO.CampaignMod (request);  

        }

        public string CampaignDel(Model.Campaign request)
        {
            CampaignBO campaignBO = new CampaignBO();
            return campaignBO.CampaignDel (request);  

        }

        public Model.CampaignMainFrame CampaignMainframeInq(Model.CampaignMainFrame request)
        {
            CampaignMainFrameBO campaignMainFrameBO = new CampaignMainFrameBO();
            return campaignMainFrameBO.CampaignMainframeInq(request);  

        }

        public string CampaignMainFrameAdd(Model.CampaignMainFrame request)
        {
            CampaignMainFrameBO campaignMainFrameBO = new CampaignMainFrameBO();
            return campaignMainFrameBO.CampaignMainFrameAdd(request);  

        }

        public string CampaignMainFrameMod(Model.CampaignMainFrame request)
        {
            CampaignMainFrameBO campaignMainFrameBO = new CampaignMainFrameBO();
            return campaignMainFrameBO.CampaignMainFrameMod(request);  

        }

        public string CampaignMainFrameDel(Model.CampaignMainFrame request)
        {
            CampaignMainFrameBO campaignMainFrameBO = new CampaignMainFrameBO();
            return campaignMainFrameBO.CampaignMainFrameDel (request);  

        }

        public List<Model.CampaignFollowUp> CampaignFollowUpInfo(Model.CampaignFollowUp request)
        {
            CampaignFollowUpBO campaignFollowUp = new CampaignFollowUpBO();
            return campaignFollowUp.CampaignFollowUpInfo(request);  

        }

        public Model.CampaignFollowUp CampaignFollowUpInq(Model.CampaignFollowUp request)
        {
            CampaignFollowUpBO campaignFollowUp = new CampaignFollowUpBO();
            return campaignFollowUp.CampaignFollowUpInq(request);
        }

        public string CampaignFollowUpAdd(Model.CampaignFollowUp request)
        {

            CampaignFollowUpBO campaignFollowUp = new CampaignFollowUpBO();
            return campaignFollowUp.CampaignFollowUpAdd(request);
        }

        public string CampaignFollowUpMod(Model.CampaignFollowUp request)
        {

            CampaignFollowUpBO campaignFollowUp = new CampaignFollowUpBO();
            return campaignFollowUp.CampaignFollowUpMod(request);
        }

        public string CampaignFollowUpDel(Model.CampaignFollowUp request)
        {

            CampaignFollowUpBO campaignFollowUp = new CampaignFollowUpBO();
            return campaignFollowUp.CampaignFollowUpDel(request);
        }

        public List<Model.CampaignTargetFileProvider> CampaigTargetFileInfo(Model.CampaignTargetFileProvider request)
        {

            CampaignTargetFileProviderBO campaignTargetFileProvider = new CampaignTargetFileProviderBO();
            return campaignTargetFileProvider.CampaigTargetFileInfo(request);
        }

        public Model.CampaignTargetFileProvider CampaigTargetFileInq(Model.CampaignTargetFileProvider request)
        {

            CampaignTargetFileProviderBO campaignTargetFileProvider = new CampaignTargetFileProviderBO();
            return campaignTargetFileProvider.CampaigTargetFileInq(request);
        }

        public string CampaigTargetFileAdd(Model.CampaignTargetFileProvider request)
        {

            CampaignTargetFileProviderBO campaignTargetFileProvider = new CampaignTargetFileProviderBO();
            return campaignTargetFileProvider.CampaigTargetFileAdd(request);
        }

        public string CampaigTargetFileMod(Model.CampaignTargetFileProvider request)
        {

            CampaignTargetFileProviderBO campaignTargetFileProvider = new CampaignTargetFileProviderBO();
            return campaignTargetFileProvider.CampaigTargetFileMod(request);
        }

        public string CampaigTargetFileDel(Model.CampaignTargetFileProvider request)
        {
            CampaignTargetFileProviderBO campaignTargetFileProvider = new CampaignTargetFileProviderBO();
            return campaignTargetFileProvider.CampaigTargetFileDel(request);
        }
        public List<ACM.Model.Campaign> GetCampaignDashboard(string AcmUserId, string CampaignStatus)
        {
            CampaignDashboardBO campaignDashboardBO = new CampaignDashboardBO();
            return  campaignDashboardBO.GetCampaignDashboard(AcmUserId, CampaignStatus);
        
        }




        public IEnumerable<GetDataForDropDownList> GetMasterDropDownDataforMasterTables(string MasterTableID, string MasterTableDescription, string MasterTableName)
        {
            CampaignBO campaignBO = new CampaignBO();
            return campaignBO.GetMasterDropDownDataforMasterTables(MasterTableID, MasterTableDescription, MasterTableName);
        }


        public List<Model.Campaign> CampaignInfo(Model.Campaign request)
        {
            CampaignBO campaignBO = new CampaignBO();
            return campaignBO.CampaignInfo(request );
        }
    }
}
