using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class View_CampaignDetials
    {
        public Nullable<int> CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CampaignDetails { get; set; }
        public string TargetAudience { get; set; }
        public string FollowUpRequriements { get; set; }
        public Nullable<System.DateTime> CampaignStartDate { get; set; }
        public Nullable<System.DateTime> CampaingEndDate { get; set; }
        public Nullable<int> AssignedPMId { get; set; }
        public string CampaignStatus { get; set; }
        public string LOBName { get; set; }
        public string CampaignTypeName { get; set; }
        public string SuperRegionName { get; set; }
        public string RegionName { get; set; }
        public string TargetFileProviderDesc { get; set; }
        public string Frequency { get; set; }
        public int CreatedBy { get; set; }
    }
}
