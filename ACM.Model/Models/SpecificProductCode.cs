using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class SpecificProductCode
    {
        public SpecificProductCode()
        {
            this.AdProductTypes = new List<AdProductType>();
        }

        public int SpecificProductCodesId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public virtual ICollection<AdProductType> AdProductTypes { get; set; }
    }
}
