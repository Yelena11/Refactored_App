using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ServiceModel.DomainServices.Server;

namespace ACM.Model
{
    public partial class Campaign
    {
        public Campaign()
        {
            this.ATMCampaignDisplayRules = new List<ATMCampaignDisplayRule>();
            this.CampaignDeploymentPeriods = new List<CampaignDeploymentPeriod>();
            this.CampaignSchedulingConditions = new List<CampaignSchedulingCondition>();
            this.RegionCampaignDisplayRules = new List<RegionCampaignDisplayRule>();
            this.StateCampaignDisplayRules = new List<StateCampaignDisplayRule>();
        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CampaignId { get; set; }
        [Required]
        public string CampaignName { get; set; }
        [Required]
        public System.DateTime CampaignStartDate { get; set; }
        [Required]
        public System.DateTime CampaingEndDate { get; set; }

        public Nullable<int> CampaignTypeId { get; set; }
        [StringLength(1000, ErrorMessage = "Campaign Description cannot be longer than 1000 characters.")]
        public string CampaignDescription { get; set; }
        [StringLength(1000, ErrorMessage = "Campaign Details cannot be longer than 1000 characters.")]
        public string CampaignDetails { get; set; }

        public Nullable<int> RequestorId { get; set; }
        public string CampaignStatus { get; set; }
        public Nullable<int> PrimaryProductManagerId { get; set; }
        public Nullable<int> SecondaryProductManagerId { get; set; }
        public Nullable<int> SuperCategoryId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> SubCategoryId { get; set; }
        public Nullable<int> PromoButtonTypeId { get; set; }
        [StringLength(1000, ErrorMessage = "Target Audience cannot be longer than 1000 characters.")]
        public string TargetAudience { get; set; }
        public string TargetLoadFrequency { get; set; }
        [Range(1, 999, ErrorMessage = "Show Limit must be greater than 0 and less than 1000")]
        [RegularExpression(@"^[0-9]{1,4}$",
         ErrorMessage = "Must be 1-4 numeric characters only.")]

        public Nullable<int> ShowLimit { get; set; }

        public string FollowUpRequriements { get; set; }
        public Nullable<int> AssignedPMId { get; set; }
        public string CampaignAdvertisementType { get; set; }
        [Range(1, 999, ErrorMessage = "Campaign Priority must be greater than 0 and less than 1000")]
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
        [Include]
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
        public virtual ICollection<CampaignDeploymentPeriod> CampaignDeploymentPeriods { get; set; }
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