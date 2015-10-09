using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            this.Campaigns = new List<Campaign>();
        }

        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual Category Category { get; set; }
    }
}
