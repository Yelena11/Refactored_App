using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ACM.DAO.Campaign;
using ACM.Model;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.BO.Campaign
{
   public class CampaignTargetFileProviderBO
    {
       CampaignTargetFileProviderDAO campaignTargetFileProviderDAO = new CampaignTargetFileProviderDAO();
        public List<CampaignTargetFileProvider> CampaigTargetFileInfo(CampaignTargetFileProvider request)
        {
            return campaignTargetFileProviderDAO.CampaigTargetFileInfo(request);
        }

        public CampaignTargetFileProvider CampaigTargetFileInq(CampaignTargetFileProvider request)
        {
            return campaignTargetFileProviderDAO.CampaigTargetFileInq(request);
        }

        public string CampaigTargetFileAdd(CampaignTargetFileProvider request)
        {
            return campaignTargetFileProviderDAO.CampaigTargetFileAdd(request);
        }

        public string CampaigTargetFileMod(CampaignTargetFileProvider request)
        {
            string campaignTarget;
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    if (request.FollowUPNeeded == "No")
                        DeleteFollowUp(request);
                    campaignTarget = campaignTargetFileProviderDAO.CampaigTargetFileMod(request);
                    tran.Complete();

                }
                catch (Exception ex)
                {
                    Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaigTargetFileMod-BO");
                    throw;
                }
            }
            return campaignTarget;
        }

        public void DeleteFollowUp(Model.CampaignTargetFileProvider request)
        {
            try
            {
                Model.CampaignFollowUp campaignFollowUp = new Model.CampaignFollowUp();
                CampaignFollowUpDAO campaignFollowUpDAO = new CampaignFollowUpDAO();
                campaignFollowUp.CampaignId = request.CampaignId;
                campaignFollowUp = campaignFollowUpDAO.CampaignFollowUpInq(campaignFollowUp);

                if (campaignFollowUp != null)
                    campaignFollowUpDAO.CampaignFollowUpDel(campaignFollowUp);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "DeleteFollowUp-BO");
                throw;
            }
        }

        public string CampaigTargetFileDel(CampaignTargetFileProvider request)
        {
            return campaignTargetFileProviderDAO.CampaigTargetFileDel(request);
        }
    }
}
