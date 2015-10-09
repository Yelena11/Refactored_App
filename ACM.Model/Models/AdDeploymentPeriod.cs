using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class AdDeploymentPeriod
    {
        public int Adid { get; set; }
        public int CampaignId { get; set; }
        public int DeploymentPeriodId { get; set; }
        public string AdStatus { get; set; }
        public virtual Ad Ad { get; set; }
        public virtual DeploymentPeriod DeploymentPeriod { get; set; }
    }
}
