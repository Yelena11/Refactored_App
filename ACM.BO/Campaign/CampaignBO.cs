using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ACM.DAO.Campaign;
using ACM.Model.CustomModel;
using System.Diagnostics;
using ACM.Util.ApplicationException;

namespace ACM.BO.Campaign
{
 public   class CampaignBO
 {
        CampaignDAO campaignDAO = new CampaignDAO();

        public ACM.Model.Campaign GetCampaignInfoById(int campaignId)
        {
            return campaignDAO.GetCampaignInfoById(campaignId);
        }

        public IEnumerable<GetDataForDropDownList> GetMasterDropDownDataforMasterTables(string MasterTableID, string MasterTableDescription, string MasterTableName)
        {
            return campaignDAO.GetMasterDropDownDataforMasterTables(MasterTableID, MasterTableDescription, MasterTableName);
        }
        public List<ACM.Model.Campaign> CampaignInfo(ACM.Model.Campaign request)
        {
            return campaignDAO.CampaignInfo(request);
        }

        public ACM.Model.Campaign CampaignInq(ACM.Model.Campaign request)
        {
            return campaignDAO.CampaignInq(request);
        }
        public ACM.Model.PartialViewInfo CampaignLeftNavigationDetails(int campaignId)
        {
            return campaignDAO.CampaignLeftNavigationDetails(campaignId);
        }

        public ACM.Model.Campaign CampaignAdd(ACM.Model.Campaign request)
        {
            return campaignDAO.CampaignAdd(request);
        }

        public string CampaignMod(ACM.Model.Campaign request)
        {
            string camMod;
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {

                    var checkthecampaigntype = campaignDAO.CampaignInq(request);
                    if (checkthecampaigntype.CampaignTypeId != request.CampaignTypeId)
                        DeleteByCampaignType(request);

                    camMod = campaignDAO.CampaignMod(request);
                    tran.Complete();
                }
                catch (Exception ex)
                {
                    Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMod-BO");
                    throw new Exception(ex.Message.ToString());

                }
            }
            return camMod;
        }

        private void DeleteByCampaignType(Model.Campaign request)
        {
            try
            {
                Model.CampaignMainFrame campaignMainFrame = new Model.CampaignMainFrame();
                CampaignMainFrameDAO campaignMainFrameDAO = new CampaignMainFrameDAO();
                campaignMainFrame.CampaignId = request.CampaignId;
                campaignMainFrame = campaignMainFrameDAO.CampaignMainFrameInq(campaignMainFrame);

                if (campaignMainFrame != null)
                    campaignMainFrameDAO.CampaignMainFrameDel(campaignMainFrame);

                Model.CampaignFollowUp campaignFollowUp = new Model.CampaignFollowUp();
                CampaignFollowUpDAO campaignFollowUpDAO = new CampaignFollowUpDAO();
                campaignFollowUp.CampaignId = request.CampaignId;
                campaignFollowUp = campaignFollowUpDAO.CampaignFollowUpInq(campaignFollowUp);

                if (campaignFollowUp != null)
                    campaignFollowUpDAO.CampaignFollowUpDel(campaignFollowUp);

                Model.CampaignTargetFileProvider campaignTargetFileProvider = new Model.CampaignTargetFileProvider();
                CampaignTargetFileProviderDAO campaignTargetFileProviderDAO = new CampaignTargetFileProviderDAO();
                campaignTargetFileProvider.CampaignId = request.CampaignId;
                campaignTargetFileProvider = campaignTargetFileProviderDAO.CampaigTargetFileInq(campaignTargetFileProvider);

                if (campaignTargetFileProvider != null)
                    campaignTargetFileProviderDAO.CampaigTargetFileDel(campaignTargetFileProvider);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "DeleteByCampaignType-BO");
                throw new Exception(ex.Message.ToString());
            }
        }

        public string CampaignDel(ACM.Model.Campaign request)
        {
            return campaignDAO.CampaignDel(request);
        }

    }
}
