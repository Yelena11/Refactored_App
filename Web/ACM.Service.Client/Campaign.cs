using ACM.Model;
using ACM.Service.Client.CampaignServiceRef;
using ACM.Util.WCFUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ACM.Service.Client
{
    public class CampaignServiceClient
    {
        CampaignClient campaignProxy = new CampaignClient();
        public List<Campaign> GetAllCampaings()
        {
            
            return campaignProxy.GetAllCampaings();
        }

        public List<Campaign> GetCampaign(int campaignId)
        {
            
            return campaignProxy.GetCampaign(campaignId);
        }

        public List<CampaignTargetFileProvider> GetCampaignTargetFileProvider(int campaignId)
        {
            
            return campaignProxy.GetCampaignTargetFileProvider(campaignId);
        }


        public List<CampaignLocation> GetCampaignLocation(int campaignId)
        {
            
            return campaignProxy.GetCampaignLocation(campaignId);
        }

        public List<Region> GetRegions()
        {
            
            return campaignProxy.GetRegions();
        }


        public List<User> GetRequestorDetails(int userId)
        {
            
            return campaignProxy.GetRequestorDetails(userId);

        }

        public IEnumerable<CampaignRequestor> GetRequestorDashboard(int requestorId, int lobId, string status, bool isLobRequest)
        {
            
            return campaignProxy.GetRequestorDashboard(requestorId, lobId, status, isLobRequest);

        }

        public Model.CustomModel.CampaignDetail CampaignDetials(int CampaignId)
        {
            try
            {
                
                return campaignProxy.CampaignDetials(CampaignId);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, System.Reflection.MethodInfo.GetCurrentMethod().Name);
                throw new Exception(exp.ToString());
            }
        }

        public void CancelCampaign(int CampaignId)
        {
            try
            {
                campaignProxy.CancelCampaign(CampaignId);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CancelCampaign");
                throw new Exception(exp.ToString());
            }
        }



        public void SaveCampaign(Campaign campaign, List<CampaignTargetFileProvider> campaignTFPL, List<CampaignLocation> campaignLocList)
        {
            try
            {
                
                campaignProxy.SaveCampaign(campaign, campaignTFPL, campaignLocList);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "SaveCampaign");
                throw new Exception(exp.ToString());
            }
        }


        public Campaign CampaignInq(Campaign request)
        {
            try
            {
                
                return campaignProxy.CampaignInq(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignInq");
                throw new Exception(exp.ToString());
            }

        }

        public ACM.Model.Campaign CampaignAdd(Campaign request)
        {
            try
            {
                
                return campaignProxy.CampaignAdd(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignAdd");
                throw new Exception(exp.ToString());
            }
        }

        public string CampaignMod(Campaign request)
        {
            try
            {
                
                return campaignProxy.CampaignMod(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignMod");
                throw new Exception(exp.ToString());
            }
        }

        public string CampaignDel(Campaign request)
        {
            try
            {
                
                return campaignProxy.CampaignDel(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignDel");
                throw new Exception(exp.ToString());
            }
        }

        public CampaignMainFrame CampaignMainframeInq(CampaignMainFrame request)
        {
            try
            {
                
                return campaignProxy.CampaignMainframeInq(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignMainframeInq");
                throw new Exception(exp.ToString());
            }
        }

        public string CampaignMainFrameAdd(CampaignMainFrame request)
        {
            try
            {
                
                return campaignProxy.CampaignMainFrameAdd(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignMainFrameAdd");
                throw new Exception(exp.ToString());
            }
        }

        public string CampaignMainFrameMod(CampaignMainFrame request)
        {
            try
            {
                
                return campaignProxy.CampaignMainFrameMod(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignMainFrameMod");
                throw new Exception(exp.ToString());
            }
        }

        public string CampaignMainFrameDel(CampaignMainFrame request)
        {
            try
            {
                
                return campaignProxy.CampaignMainFrameDel(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignMainFrameDel");
                throw new Exception(exp.ToString());
            }
        }

        public List<CampaignFollowUp> CampaignFollowUpInfo(CampaignFollowUp request)
        {
            try
            {
                
                return campaignProxy.CampaignFollowUpInfo(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignFollowUpInfo");
                throw new Exception(exp.ToString());
            }
        }

        public CampaignFollowUp CampaignFollowUpInq(CampaignFollowUp request)
        {
            try
            {
                
                return campaignProxy.CampaignFollowUpInq(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignFollowUpInq");
                throw new Exception(exp.ToString());
            }
        }

        public string CampaignFollowUpAdd(CampaignFollowUp request)
        {
            try
            {
                
                return campaignProxy.CampaignFollowUpAdd(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignFollowUpAdd");
                throw new Exception(exp.ToString());
            }
        }

        public string CampaignFollowUpMod(CampaignFollowUp request)
        {
            try
            {
                
                return campaignProxy.CampaignFollowUpMod(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignFollowUpMod");
                throw new Exception(exp.ToString());
            }
        }

        public string CampaignFollowUpDel(CampaignFollowUp request)
        {
            try
            {
                
                return campaignProxy.CampaignFollowUpDel(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignFollowUpDel");
                throw new Exception(exp.ToString());
            }
        }

        public List<CampaignTargetFileProvider> CampaigTargetFileInfo(CampaignTargetFileProvider request)
        {
            try
            {
                
                return campaignProxy.CampaigTargetFileInfo(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaigTargetFileInfo");
                throw new Exception(exp.ToString());
            }
        }

        public CampaignTargetFileProvider CampaigTargetFileInq(CampaignTargetFileProvider request)
        {
            try
            {
                
                return campaignProxy.CampaigTargetFileInq(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaigTargetFileInq");
                throw new Exception(exp.ToString());
            }
        }

        public string CampaigTargetFileAdd(CampaignTargetFileProvider request)
        {
            try
            {
                
                return campaignProxy.CampaigTargetFileAdd(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaigTargetFileAdd");
                throw new Exception(exp.ToString());
            }
        }

        public string CampaigTargetFileMod(CampaignTargetFileProvider request)
        {
            try
            {
                
                return campaignProxy.CampaigTargetFileMod(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaigTargetFileMod");
                throw new Exception(exp.ToString());
            }
        }

        public string CampaigTargetFileDel(CampaignTargetFileProvider request)
        {
            try
            {
                
                return campaignProxy.CampaigTargetFileDel(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaigTargetFileDel");
                throw new Exception(exp.ToString());
            }
        }


        public List<Campaign> GetCampaignDashboard(string AcmUserId, string CampaignStatus)
        {
            try
            {
                
                return campaignProxy.GetCampaignDashboard(AcmUserId, CampaignStatus);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "GetCampaignDashboard");
                throw new Exception(exp.ToString());
            }
        }


        public List<Model.CustomModel.GetDataForDropDownList> GetMasterDropDownDataforMasterTables(string MasterTableID, string MasterTableDescription, string MasterTableName)
        {
            try
            {
                
                return campaignProxy.GetMasterDropDownDataforMasterTables(MasterTableID, MasterTableDescription, MasterTableName);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "GetMasterDropDownDataforMasterTables");
                throw new Exception(exp.ToString());
            }
        }


        public List<Campaign> CampaignInfo(Campaign request)
        {
            try
            {
                
                return campaignProxy.CampaignInfo(request);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "CampaignInfo");
                throw new Exception(exp.ToString());
            }
        }
        public List<ACM.Model.Category> GetCategoryById(int SuperCategoryId)
        {
            try
            {

                return campaignProxy.GetCategoryById(SuperCategoryId);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "GetCategoryById");
                throw new Exception(exp.ToString());
            }
        }

        public List<ACM.Model.SubCategory> GetSubCategoryById(int CategoryId)
        {
            try
            {

                return campaignProxy.GetSubCategoryById(CategoryId);
            }
            catch (Exception exp)
            {
                WCFFaultException.GetClientException(exp, "GetSubCategoryById");
                throw new Exception(exp.ToString());
            }
        }
    }
}