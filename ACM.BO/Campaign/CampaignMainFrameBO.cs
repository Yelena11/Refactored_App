using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.DAO.Campaign;
using ACM.Model;

namespace ACM.BO.Campaign
{
    public class CampaignMainFrameBO
    {
        CampaignMainFrameDAO campaignMainFrameDAO = new CampaignMainFrameDAO();
        public List<CampaignMainFrame> CampaignMainFrameInfo(CampaignMainFrame request)
        {
            return campaignMainFrameDAO.CampaignMainFrameInfo(request);
        }

        public CampaignMainFrame CampaignMainframeInq(CampaignMainFrame request)
        {
            return campaignMainFrameDAO.CampaignMainFrameInq(request);
        }

        public string CampaignMainFrameAdd(CampaignMainFrame request)
        {
            return campaignMainFrameDAO.CampaignMainFrameAdd(request);
        }

        public string CampaignMainFrameMod(CampaignMainFrame request)
        {
            return campaignMainFrameDAO.CampaignMainFrameMod(request);
        }

        public string CampaignMainFrameDel(CampaignMainFrame request)
        {
            return campaignMainFrameDAO.CampaignMainFrameDel(request);
        }
    }
}
