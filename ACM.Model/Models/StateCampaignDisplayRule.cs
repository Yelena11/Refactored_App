using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class StateCampaignDisplayRule
    {
        public int ID { get; set; }
        public int DeploymentPeriodId { get; set; }
        public int CampaignId { get; set; }
        public int Ixclude { get; set; }
        public string StateCode { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual DeploymentPeriod DeploymentPeriod { get; set; }
        public virtual State State { get; set; }
    }
}
