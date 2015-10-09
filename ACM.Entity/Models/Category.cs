using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Campaigns = new List<Campaign>();
            this.SubCategories = new List<SubCategory>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> SuperCategoryID { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual SuperCategory SuperCategory { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
