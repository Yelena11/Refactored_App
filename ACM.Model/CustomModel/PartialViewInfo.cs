using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.Model
{
    public class PartialViewInfo
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string CampaignType { get; set; }
        public string  ATMPM { get; set; }
        public string SecondaryPM { get; set; }
        public string Status { get; set; }
        public int Adid { get; set; }
        public int DeploymentPeriodId { get; set; }
        public string PromoButton { get; set; }
        public string Note { get; set; }
    }
    public partial class GetLeftNavDetails_Result
    {
        public int campaignId { get; set; }
        public string campaignname { get; set; }
        public string CampaignTypeName { get; set; }
        public string PromoButtonName { get; set; }
        public string primaryPMName { get; set; }
        public string secondaryPMName { get; set; }
        public string campaignstatus { get; set; }
        public string Notes { get; set; }
    }
}