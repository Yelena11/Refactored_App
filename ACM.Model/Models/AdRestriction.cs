using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class AdRestriction
    {
        public AdRestriction()
        {
            this.AdRestrictionAds = new List<AdRestrictionAd>();
        }

        public int AdRestrictionId { get; set; }
        public string RestrictionName { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ACMCategoryId { get; set; }
        public string ACMName { get; set; }
        public virtual AdRestrictionCategory AdRestrictionCategory { get; set; }
        public virtual ICollection<AdRestrictionAd> AdRestrictionAds { get; set; }
    }
}
