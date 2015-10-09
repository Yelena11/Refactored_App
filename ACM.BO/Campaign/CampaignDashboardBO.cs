using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.DAO.Campaign;
using ACM.Model;
using ACM.Model.CustomModel;


namespace ACM.BO.Campaign
{
    public class CampaignDashboardBO
    {
        public List<ACM.Model.Campaign> GetCampaignDashboard(string AcmUserId, string CampaignStatus)
        {
            CampaignDashboardDAO CampDashboardDAO = new CampaignDashboardDAO();
            return CampDashboardDAO.GetCampaignDashboard(AcmUserId, CampaignStatus);
        }
    }
}
