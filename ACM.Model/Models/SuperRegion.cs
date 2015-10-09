using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class SuperRegion
    {
        public SuperRegion()
        {
            this.CampaignLocations = new List<CampaignLocation>();
            this.Regions = new List<Region>();
        }

        public string SuperRegionId { get; set; }
        public string SuperRegionName { get; set; }
        public string SuperRegionStatus { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<CampaignLocation> CampaignLocations { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}
