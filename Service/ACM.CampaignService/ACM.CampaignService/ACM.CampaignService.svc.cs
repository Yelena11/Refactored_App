using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ACM.BO.Campaign;
using ACM.Model;
using ACM.Model.CustomModel;
using ACM.Util.ApplicationException;
using ACM.BO;
using System.Diagnostics;
namespace ACM.CampaignService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CampaignService : ICampaign

    {

        public List<Model.Campaign> GetAllCampaings()
        {
            return GetAllCampaings();
        }

        public List<Model.Campaign> GetCampaign(int campaignId)
        {
            try
            {
                CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
                return campaignRequestBO.GetCampaign(campaignId);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetCampaign");
                throw;
            }
        }

        public List<Model.CampaignTargetFileProvider> GetCampaignTargetFileProvider(int campaignId)
        {
            try
            {
                CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
                return campaignRequestBO.GetCampaignTargetFileProvider(campaignId);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetCampaignTargetFileProvider");
                throw;
            }
        }

        public List<Model.CampaignLocation> GetCampaignLocation(int campaignId)
        {
            try
            {
                CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
                return campaignRequestBO.GetCampaignLocation(campaignId);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetCampaignLocation");
                throw;
            }
        }



        public List<Model.Region> GetRegions()
        {
            try
            {
                CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
                return campaignRequestBO.GetRegions();
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetRegions");
                throw;
            }
        }


        public List<Model.User> GetRequestorDetails(int userId)
        {
            try
            {
                CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
                return campaignRequestBO.GetRequestorDetails(userId);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetRequestorDetails");
                throw;
            }
        }


        public IEnumerable<ACM.Model.CampaignRequestor> GetRequestorDashboard(int requestorId, int lobId, string status, bool isLobRequest)
        {
            try
            {
                CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
                return campaignRequestBO.GetRequestorDashboard(requestorId, lobId, status, isLobRequest);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetRequestorDetails");
                throw;
            }
        }

        public void SaveCampaign(ACM.Model.Campaign campaign, ACM.Model.CampaignTargetFileProvider[] campaignTFPL, ACM.Model.CampaignLocation[] campaignLocList)
        {
            try
            {
                CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
                campaignRequestBO.SaveCampaign(campaign, campaignTFPL, campaignLocList);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "SaveCampaign");
                throw;
            }

        }

        public void CancelCampaign(int CampaignId)
        {
            try
            {
                CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
                campaignRequestBO.CancelCampaign(CampaignId);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CancelCampaign");
                throw;
            }
        }

        public CampaignDetail CampaignDetials(int CampaignId)
        {
            try
            {
                CampaignRequestBO campaignRequestBO = new CampaignRequestBO();
                return campaignRequestBO.CampaignDetials(CampaignId);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignDetials");
                throw;
            }
        }




        public Model.Campaign CampaignInq(Model.Campaign request)
        {
            try
            {
                CampaignBO campaignBO = new CampaignBO();
                return campaignBO.CampaignInq(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignInq");
                throw;
            }
        }

        public ACM.Model.Campaign CampaignAdd(Model.Campaign request)
        {
            try
            {
                CampaignBO campaignBO = new CampaignBO();
                return campaignBO.CampaignAdd(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignAdd");
                throw;
            }

        }

        public string CampaignMod(Model.Campaign request)
        {
            try
            {
                CampaignBO campaignBO = new CampaignBO();
                return campaignBO.CampaignMod(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }

        }

        public string CampaignDel(Model.Campaign request)
        {
            try
            {
                CampaignBO campaignBO = new CampaignBO();
                return campaignBO.CampaignDel(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }

        }

        public Model.CampaignMainFrame CampaignMainframeInq(Model.CampaignMainFrame request)
        {
            try
            {
                CampaignMainFrameBO campaignMainFrameBO = new CampaignMainFrameBO();
                return campaignMainFrameBO.CampaignMainframeInq(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public string CampaignMainFrameAdd(Model.CampaignMainFrame request)
        {
            try
            {
                CampaignMainFrameBO campaignMainFrameBO = new CampaignMainFrameBO();
                return campaignMainFrameBO.CampaignMainFrameAdd(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public string CampaignMainFrameMod(Model.CampaignMainFrame request)
        {
            try
            {
                CampaignMainFrameBO campaignMainFrameBO = new CampaignMainFrameBO();
                return campaignMainFrameBO.CampaignMainFrameMod(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }

        }

        public string CampaignMainFrameDel(Model.CampaignMainFrame request)
        {
            try
            {
                CampaignMainFrameBO campaignMainFrameBO = new CampaignMainFrameBO();
                return campaignMainFrameBO.CampaignMainFrameDel(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public List<Model.CampaignFollowUp> CampaignFollowUpInfo(Model.CampaignFollowUp request)
        {
            try
            {
                CampaignFollowUpBO campaignFollowUp = new CampaignFollowUpBO();
                return campaignFollowUp.CampaignFollowUpInfo(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public Model.CampaignFollowUp CampaignFollowUpInq(Model.CampaignFollowUp request)
        {

            try
            {
                CampaignFollowUpBO campaignFollowUp = new CampaignFollowUpBO();
                return campaignFollowUp.CampaignFollowUpInq(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public string CampaignFollowUpAdd(Model.CampaignFollowUp request)
        {
            try
            {

                CampaignFollowUpBO campaignFollowUp = new CampaignFollowUpBO();
                return campaignFollowUp.CampaignFollowUpAdd(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public string CampaignFollowUpMod(Model.CampaignFollowUp request)
        {
            try
            {
                CampaignFollowUpBO campaignFollowUp = new CampaignFollowUpBO();
                return campaignFollowUp.CampaignFollowUpMod(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public string CampaignFollowUpDel(Model.CampaignFollowUp request)
        {
            try
            {
                CampaignFollowUpBO campaignFollowUp = new CampaignFollowUpBO();
                return campaignFollowUp.CampaignFollowUpDel(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public List<Model.CampaignTargetFileProvider> CampaigTargetFileInfo(Model.CampaignTargetFileProvider request)
        {
            try
            {

                CampaignTargetFileProviderBO campaignTargetFileProvider = new CampaignTargetFileProviderBO();
                return campaignTargetFileProvider.CampaigTargetFileInfo(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public Model.CampaignTargetFileProvider CampaigTargetFileInq(Model.CampaignTargetFileProvider request)
        {
            try
            {
                CampaignTargetFileProviderBO campaignTargetFileProvider = new CampaignTargetFileProviderBO();
                return campaignTargetFileProvider.CampaigTargetFileInq(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public string CampaigTargetFileAdd(Model.CampaignTargetFileProvider request)
        {
            try
            {
                CampaignTargetFileProviderBO campaignTargetFileProvider = new CampaignTargetFileProviderBO();
                return campaignTargetFileProvider.CampaigTargetFileAdd(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public string CampaigTargetFileMod(Model.CampaignTargetFileProvider request)
        {
            try
            {
                CampaignTargetFileProviderBO campaignTargetFileProvider = new CampaignTargetFileProviderBO();
                return campaignTargetFileProvider.CampaigTargetFileMod(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }

        public string CampaigTargetFileDel(Model.CampaignTargetFileProvider request)
        {
            try
            {
                CampaignTargetFileProviderBO campaignTargetFileProvider = new CampaignTargetFileProviderBO();
                return campaignTargetFileProvider.CampaigTargetFileDel(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }
        public List<ACM.Model.Campaign> GetCampaignDashboard(string AcmUserId, string CampaignStatus)
        {
            try
            {
                CampaignDashboardBO campaignDashboardBO = new CampaignDashboardBO();
                return campaignDashboardBO.GetCampaignDashboard(AcmUserId, CampaignStatus);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }

        }




        public IEnumerable<GetDataForDropDownList> GetMasterDropDownDataforMasterTables(string MasterTableID, string MasterTableDescription, string MasterTableName)
        {
            try
            {
                CampaignBO campaignBO = new CampaignBO();
                return campaignBO.GetMasterDropDownDataforMasterTables(MasterTableID, MasterTableDescription, MasterTableName);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }


        public List<Model.Campaign> CampaignInfo(Model.Campaign request)
        {
            try
            {
                CampaignBO campaignBO = new CampaignBO();
                return campaignBO.CampaignInfo(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }




        public List<Category> GetCategoryById(int SuperCategoryId)
        {
            try
            {
                CategoryBO categoryBO = new CategoryBO();
                return categoryBO.GetCategoryById(SuperCategoryId);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }


        public List<SubCategory> GetSubCategoryById(int CategoryID)
        {
            try
            {
                SubCategoryBO subCategoryBO = new SubCategoryBO();
                return subCategoryBO.GetSubCategoryById(CategoryID);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod");
                throw;
            }
        }




        public PartialViewInfo CampaignLeftNavigationDetails(int campaignId)
        {
            CampaignBO campaignBO = new CampaignBO();
            return campaignBO.CampaignLeftNavigationDetails(campaignId);
        }
    }
}