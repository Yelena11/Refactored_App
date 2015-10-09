using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACM.Model
{
    public partial class Ad
    {
        public Ad()
        {
            this.AdDeploymentPeriods = new List<AdDeploymentPeriod>();
            this.AdOutStandingTasks = new List<AdOutStandingTask>();
            this.AdRestrictionAds = new List<AdRestrictionAd>();
            this.AdSchedulingConditions = new List<AdSchedulingCondition>();
            this.ATMAdDisplayRules = new List<ATMAdDisplayRule>();
            this.RegionAdDisplayRules = new List<RegionAdDisplayRule>();
            this.StateAdDisplayRules = new List<StateAdDisplayRule>();
        }

        public int AdId { get; set; }
        [Required]
        public string AdName { get; set; }
        public int CampaignId { get; set; }
        public Nullable<int> AdProductTypeId { get; set; }
        public Nullable<int> DNSScrubLevel { get; set; }
        public Nullable<int> ATMTypeId { get; set; }
        public Nullable<int> MediaVendorId { get; set; }
        public string AdLocationCode { get; set; }
        public Nullable<int> MediaFileIndex { get; set; }
        public string MediaFileTagWeb { get; set; }
        public string MediaFileTagMx { get; set; }
        public string MediaType { get; set; }
        public Nullable<int> AdRestrictionId { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public Nullable<int> Field8 { get; set; }
        public Nullable<int> Field9 { get; set; }
        public Nullable<int> Field10 { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string AdGuid { get; set; }
        public virtual AdLocation AdLocation { get; set; }
        public virtual AdProductType AdProductType { get; set; }
        public virtual ATMType ATMType { get; set; }
        public virtual ICollection<AdDeploymentPeriod> AdDeploymentPeriods { get; set; }
        public virtual ICollection<AdOutStandingTask> AdOutStandingTasks { get; set; }
        public virtual ICollection<AdRestrictionAd> AdRestrictionAds { get; set; }
        public virtual ICollection<AdSchedulingCondition> AdSchedulingConditions { get; set; }
        public virtual ICollection<ATMAdDisplayRule> ATMAdDisplayRules { get; set; }
        public virtual ICollection<RegionAdDisplayRule> RegionAdDisplayRules { get; set; }
        public virtual ICollection<StateAdDisplayRule> StateAdDisplayRules { get; set; }
    }
}
