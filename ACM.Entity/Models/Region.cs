using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class Region
    {
        public Region()
        {
            this.CampaignLocations = new List<CampaignLocation>();
            this.RegionAdDisplayRules = new List<RegionAdDisplayRule>();
            this.RegionCampaignDisplayRules = new List<RegionCampaignDisplayRule>();
        }

        public string RegionId { get; set; }
        public string RegionName { get; set; }
        public string SuperRegionId { get; set; }
        public string RegionStatus { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<CampaignLocation> CampaignLocations { get; set; }
        public virtual SuperRegion SuperRegion { get; set; }
        public virtual ICollection<RegionAdDisplayRule> RegionAdDisplayRules { get; set; }
        public virtual ICollection<RegionCampaignDisplayRule> RegionCampaignDisplayRules { get; set; }
    }
}
