using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class AdProductType
    {
        public AdProductType()
        {
            this.Ads = new List<Ad>();
        }

        public int ProductTypeId { get; set; }
        public string Description { get; set; }
        public Nullable<int> SpecificProductCodesId { get; set; }
        public Nullable<int> ATMWorldAdType { get; set; }
        public int AdCategoryId { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }
        public virtual AdCategory AdCategory { get; set; }
        public virtual SpecificProductCode SpecificProductCode { get; set; }
    }
}
