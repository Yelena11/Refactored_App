using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            this.ATMCampaignDisplayRules = new List<ATMCampaignDisplayRule>();
            this.CampaignSchedulingConditions = new List<CampaignSchedulingCondition>();
            this.RegionCampaignDisplayRules = new List<RegionCampaignDisplayRule>();
            this.StateCampaignDisplayRules = new List<StateCampaignDisplayRule>();
        }

        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public Nullable<System.DateTime> CampaignStartDate { get; set; }
        public Nullable<System.DateTime> CampaingEndDate { get; set; }
        public Nullable<int> CampaignTypeId { get; set; }
        public string CampaignDescription { get; set; }
        public string CampaignDetails { get; set; }
        public Nullable<int> RequestorId { get; set; }
        public string CampaignStatus { get; set; }
        public Nullable<int> PrimaryProductManagerId { get; set; }
        public Nullable<int> SecondaryProductManagerId { get; set; }
        public Nullable<int> SuperCategoryId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> SubCategoryId { get; set; }
        public Nullable<int> PromoButtonTypeId { get; set; }
        public string TargetAudience { get; set; }
        public string TargetLoadFrequency { get; set; }
        public Nullable<int> ShowLimit { get; set; }
        public string FollowUpRequriements { get; set; }
        public Nullable<int> AssignedPMId { get; set; }
        public string CampaignAdvertisementType { get; set; }
        public Nullable<int> CampaignPriority { get; set; }
        public Nullable<int> CampaignTableStatusId { get; set; }
        public Nullable<int> ProductPlacementId { get; set; }
        public string Notes { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public Nullable<int> Field5 { get; set; }
        public Nullable<int> Field6 { get; set; }
        public Nullable<int> Field7 { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string CampaignGuid { get; set; }
        public string ScheduledByCampaign { get; set; }
        public virtual ICollection<ATMCampaignDisplayRule> ATMCampaignDisplayRules { get; set; }
        public virtual CampaignTableStatu CampaignTableStatu { get; set; }
        public virtual CampaignType CampaignType { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProductPlacement ProductPlacement { get; set; }
        public virtual PromoButton PromoButton { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual SuperCategory SuperCategory { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
        public virtual User User3 { get; set; }
        public virtual CampaignFollowUp CampaignFollowUp { get; set; }
        public virtual CampaignLocation CampaignLocation { get; set; }
        public virtual CampaignMainFrame CampaignMainFrame { get; set; }
        public virtual ICollection<CampaignSchedulingCondition> CampaignSchedulingConditions { get; set; }
        public virtual CampaignTargetFileProvider CampaignTargetFileProvider { get; set; }
        public virtual ETMConfiguration ETMConfiguration { get; set; }
        public virtual ICollection<RegionCampaignDisplayRule> RegionCampaignDisplayRules { get; set; }
        public virtual ICollection<StateCampaignDisplayRule> StateCampaignDisplayRules { get; set; }
    }
}
