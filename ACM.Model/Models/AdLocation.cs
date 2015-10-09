using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class AdLocation
    {
        public AdLocation()
        {
            this.Ads = new List<Ad>();
            this.AdLocationMedias = new List<AdLocationMedia>();
            this.AdSchedulingConditions = new List<AdSchedulingCondition>();
            this.RegionAdDisplayRules = new List<RegionAdDisplayRule>();
        }

        public string AdLocationCode { get; set; }
        public string AdLocationDesc { get; set; }
        public int LanguageId { get; set; }
        public int Discontinued { get; set; }
        public Nullable<int> AdLocationOrder { get; set; }
        public string RegistryKeyName { get; set; }
        public string ReportUnderbooked { get; set; }
        public string RegFileCategory { get; set; }
        public string AdType { get; set; }
        public string Category { get; set; }
        public string Verified { get; set; }
        public Nullable<int> VerifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }
        public virtual Language Language { get; set; }
        public virtual ICollection<AdLocationMedia> AdLocationMedias { get; set; }
        public virtual ICollection<AdSchedulingCondition> AdSchedulingConditions { get; set; }
        public virtual ICollection<RegionAdDisplayRule> RegionAdDisplayRules { get; set; }
    }
}
