using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class AdRestrictionCategory
    {
        public AdRestrictionCategory()
        {
            this.AdRestrictions = new List<AdRestriction>();
        }

        public int AdRestrictionCategoryId { get; set; }
        public string AdRestrictionCategoryName { get; set; }
        public string Status { get; set; }
        public virtual ICollection<AdRestriction> AdRestrictions { get; set; }
    }
}
