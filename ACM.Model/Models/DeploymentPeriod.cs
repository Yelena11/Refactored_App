using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACM.Model
{
    public partial class DeploymentPeriod
    {
        public DeploymentPeriod()
        {
            this.AdDeploymentPeriods = new List<AdDeploymentPeriod>();
            this.AdSchedulingConditions = new List<AdSchedulingCondition>();
            this.ATMAdDisplayRules = new List<ATMAdDisplayRule>();
            this.ATMCampaignDisplayRules = new List<ATMCampaignDisplayRule>();
            this.CampaignDeploymentPeriods = new List<CampaignDeploymentPeriod>();
            this.CampaignSchedulingConditions = new List<CampaignSchedulingCondition>();
            this.RegionAdDisplayRules = new List<RegionAdDisplayRule>();
            this.RegionCampaignDisplayRules = new List<RegionCampaignDisplayRule>();
            this.StateAdDisplayRules = new List<StateAdDisplayRule>();
            this.StateCampaignDisplayRules = new List<StateCampaignDisplayRule>();
        }
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DeploymentPeriodId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        [Required]
        [MaxLength(50)]
        public string DeploymentName { get; set; }
              [Required]
        public System.DateTime DeploymentStartDate { get; set; }
              [Required]
        public System.DateTime DeploymentEndEndDate { get; set; }
      
        public string Status { get; set; }
        public string Closed { get; set; }
        public virtual ICollection<AdDeploymentPeriod> AdDeploymentPeriods { get; set; }
        public virtual ICollection<AdSchedulingCondition> AdSchedulingConditions { get; set; }
        public virtual ICollection<ATMAdDisplayRule> ATMAdDisplayRules { get; set; }
        public virtual ICollection<ATMCampaignDisplayRule> ATMCampaignDisplayRules { get; set; }
        public virtual ICollection<CampaignDeploymentPeriod> CampaignDeploymentPeriods { get; set; }
        public virtual ICollection<CampaignSchedulingCondition> CampaignSchedulingConditions { get; set; }
        public virtual ICollection<RegionAdDisplayRule> RegionAdDisplayRules { get; set; }
        public virtual ICollection<RegionCampaignDisplayRule> RegionCampaignDisplayRules { get; set; }
        public virtual ICollection<StateAdDisplayRule> StateAdDisplayRules { get; set; }
        public virtual ICollection<StateCampaignDisplayRule> StateCampaignDisplayRules { get; set; }
    }
}
