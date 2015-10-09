using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model;
using ACM.Model.CustomModel;
using System.Transactions;
using System.Data.Entity;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.DAO.Campaign
{
    public class CampaignDashboardDAO
    {
        private ACM_Redesign2014Context ACMContex = new ACM_Redesign2014Context();


        public List<ACM.Model.Campaign> GetCampaignDashboard(string AcmUserId, string CampaignStatus)
        {
            try
            {
                ACMContex.Configuration.LazyLoadingEnabled = true;

                ACMContex.Configuration.ProxyCreationEnabled = false;
                List<ACM.Model.Campaign> AcmCampaignList = ACMContex.Campaigns.OrderByDescending(t => t.CampaignId).ToList();

                ACMContex.Configuration.ProxyCreationEnabled = true;

                return AcmCampaignList;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetCampaignDashboard");
                throw;
            }
        }
    }
}
       
