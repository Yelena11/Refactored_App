using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class CampaignDeploymentPeriod
    {
        public int CampaignId { get; set; }
        public int DeploymentPeriodId { get; set; }
        public string CampaignStatus { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual DeploymentPeriod DeploymentPeriod { get; set; }
    }
}
