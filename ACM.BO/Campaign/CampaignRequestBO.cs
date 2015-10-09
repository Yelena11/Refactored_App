using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.DAO.Campaign;
using ACM.Model;
using ACM.Model.CustomModel;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.BO.Campaign
{
    public class CampaignRequestBO
    {
        public List<ACM.Model.Campaign> GetCampaign(int campaignId)
        {
            CampaignRequestDAO campaignRequestDAO = new CampaignRequestDAO();
            return campaignRequestDAO.GetCampaign(campaignId);

        }

        public List<CampaignTargetFileProvider> GetCampaignTargetFileProvider(int campaignId)
        {
            CampaignRequestDAO campaignRequestDAO = new CampaignRequestDAO();
            return campaignRequestDAO.GetCampaignTargetFileProvider(campaignId);

        }

        public List<CampaignLocation> GetCampaignLocation(int campaignId)
        {
            CampaignRequestDAO campaignRequestDAO = new CampaignRequestDAO();
            return campaignRequestDAO.GetCampaignLocation(campaignId);

        }

        public List<User> GetUserDetails(string loginId)
        {
            CampaignRequestDAO campaignRequestDAO = new CampaignRequestDAO();
            return campaignRequestDAO.GetUserDetails(loginId);

        }

        public IEnumerable<ACM.Model.CampaignRequestor> GetRequestorDashboard(int requestorId, int lobId, string status, bool isLobRequest)
        {
            CampaignRequestDAO campaignRequestDAO = new CampaignRequestDAO();
            //IEnumerable<ACM.Model.Campaign> campaign1 = null;
            IEnumerable<ACM.Model.CampaignRequestor> results = null;

            var campaign = campaignRequestDAO.GetRequestorDashboard(requestorId, lobId, status, isLobRequest);

            results = campaign;
            if (status != "Cancelled")
                results = campaign.Where(x => !x.CampaignStatus.Contains("Cancelled")).ToList();
            else if (status == "Cancelled")
                results = campaign.Where((x => x.CampaignStatus.Contains("Cancelled"))).ToList();
            return results;

        }

        public CampaignDetail CampaignDetials(int CampaignId)
        {
            CampaignRequestDAO campaignRequestDAO = new CampaignRequestDAO();
             return campaignRequestDAO.CampaignDetials(CampaignId);
           
        }

        public void CancelCampaign(int CampaignId)
        {
            CampaignRequestDAO campaignRequestDAO = new CampaignRequestDAO();
            try
            {
                campaignRequestDAO.CancelCampaign(CampaignId);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CancelCampaign-BO");
                throw;
            }
        }




        public List<User> GetRequestorDetails(int userId)
        {
            CampaignRequestDAO campaignRequestDAO = new CampaignRequestDAO();
            return campaignRequestDAO.GetRequestorDetails(userId);

        }

        public List<Region> GetRegions()
        {
            CampaignRequestDAO campaignRequestDAO = new CampaignRequestDAO();
            return campaignRequestDAO.GetRegions();

        }
       

        public void SaveCampaign(ACM.Model.Campaign campaign, ACM.Model.CampaignTargetFileProvider[] campaignTFPL, ACM.Model.CampaignLocation[] campaignLocList)
        {
            CampaignRequestDAO campaignRequestDAO = new CampaignRequestDAO();
            List<CampaignTargetFileProvider> lstcampaignTFPL = new List<CampaignTargetFileProvider>();
            List<CampaignLocation> lstcampaignLocList = new List<CampaignLocation>();
            if (campaignTFPL != null) {
                lstcampaignTFPL = campaignTFPL.ToList();
            }
            if (campaignLocList != null) {
                lstcampaignLocList = campaignLocList.ToList();
            }
            
            campaignRequestDAO.SaveCampaign(campaign, lstcampaignTFPL, lstcampaignLocList);
            return;
        }
      
    }
}
