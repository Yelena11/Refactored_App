using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class CampaignLocation
    {
        public int CampaignId { get; set; }
        public string SuperRegionId { get; set; }
        public string RegionId { get; set; }
        public string StateCode { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string SpecifyRegionName { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual Region Region { get; set; }
        public virtual State State { get; set; }
        public virtual SuperRegion SuperRegion { get; set; }
    }
}
