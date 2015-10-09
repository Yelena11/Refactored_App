using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class AdCategory
    {
        public AdCategory()
        {
            this.AdProductTypes = new List<AdProductType>();
        }

        public int AdCategoryId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public virtual ICollection<AdProductType> AdProductTypes { get; set; }
    }
}
