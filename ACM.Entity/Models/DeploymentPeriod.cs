using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class DeploymentPeriod
    {
        public DeploymentPeriod()
        {
            this.AdDeploymentPeriods = new List<AdDeploymentPeriod>();
            this.AdSchedulingConditions = new List<AdSchedulingCondition>();
            this.ATMAdDisplayRules = new List<ATMAdDisplayRule>();
            this.ATMCampaignDisplayRules = new List<ATMCampaignDisplayRule>();
            this.CampaignSchedulingConditions = new List<CampaignSchedulingCondition>();
            this.RegionAdDisplayRules = new List<RegionAdDisplayRule>();
            this.RegionCampaignDisplayRules = new List<RegionCampaignDisplayRule>();
            this.StateAdDisplayRules = new List<StateAdDisplayRule>();
            this.StateCampaignDisplayRules = new List<StateCampaignDisplayRule>();
        }

        public int DeploymentPeriodId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> DeploymentDate { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DefaultStartDate { get; set; }
        public Nullable<System.DateTime> DefaultEndDate { get; set; }
        public string Status { get; set; }
        public string Closed { get; set; }
        public virtual ICollection<AdDeploymentPeriod> AdDeploymentPeriods { get; set; }
        public virtual ICollection<AdSchedulingCondition> AdSchedulingConditions { get; set; }
        public virtual ICollection<ATMAdDisplayRule> ATMAdDisplayRules { get; set; }
        public virtual ICollection<ATMCampaignDisplayRule> ATMCampaignDisplayRules { get; set; }
        public virtual ICollection<CampaignSchedulingCondition> CampaignSchedulingConditions { get; set; }
        public virtual ICollection<RegionAdDisplayRule> RegionAdDisplayRules { get; set; }
        public virtual ICollection<RegionCampaignDisplayRule> RegionCampaignDisplayRules { get; set; }
        public virtual ICollection<StateAdDisplayRule> StateAdDisplayRules { get; set; }
        public virtual ICollection<StateCampaignDisplayRule> StateCampaignDisplayRules { get; set; }
    }
}
