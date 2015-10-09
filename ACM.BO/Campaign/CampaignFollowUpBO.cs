using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.DAO.Campaign;
using ACM.Model;

namespace ACM.BO.Campaign
{
    public class CampaignFollowUpBO
    {
        CampaignFollowUpDAO campaignFollowUpDAO = new CampaignFollowUpDAO();

        public List<CampaignFollowUp> CampaignFollowUpInfo(CampaignFollowUp request)
        {
            return campaignFollowUpDAO.CampaignFollowUpInfo(request);
        }

        public CampaignFollowUp CampaignFollowUpInq(CampaignFollowUp request)
        {
            return campaignFollowUpDAO.CampaignFollowUpInq(request);
        }

        public string CampaignFollowUpAdd(CampaignFollowUp request)
        {
            return campaignFollowUpDAO.CampaignFollowUpAdd(request);
        }

        public string CampaignFollowUpMod(CampaignFollowUp request)
        {
            return campaignFollowUpDAO.CampaignFollowUpMod(request);
        }

        public string CampaignFollowUpDel(CampaignFollowUp request)
        {
            return campaignFollowUpDAO.CampaignFollowUpDel(request);
        }
    }
}
