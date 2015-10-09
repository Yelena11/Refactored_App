using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ACM.Model; 
using ACM.Model.CustomModel ;
namespace ACM.Interfaces.Campaign
{
      [ServiceContract] 
    public interface  ICampaignRequest
    {
        [OperationContract()]
        List<ACM.Model.Campaign> GetAllCampaings();

        [OperationContract()]
        List<ACM.Model.Campaign> GetCampaign(int campaignId);

        [OperationContract()]
        List<CampaignTargetFileProvider> GetCampaignTargetFileProvider(int campaignId);

        [OperationContract()]
        List<CampaignLocation> GetCampaignLocation(int campaignId);

        [OperationContract()]
        IEnumerable<ACM.Model.CampaignRequestor> GetRequestorDashboard(int requestorId, int lobId, string status, bool isLobRequest);
        [OperationContract()]
           CampaignDetail CampaignDetials(int CampaignId);


        [OperationContract()]
        List<Region> GetRegions();
            [OperationContract()]
        void  CancelCampaign(int CampaignId);

            [OperationContract()]
            List<User> GetRequestorDetails(int userId);
          
            [OperationContract()]
            void SaveCampaign(ACM.Model.Campaign campaign, ACM.Model.CampaignTargetFileProvider[] campaignTFPL, ACM.Model.CampaignLocation[] campaignLocList);
    }
}
