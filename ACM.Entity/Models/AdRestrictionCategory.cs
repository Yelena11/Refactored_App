using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
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
