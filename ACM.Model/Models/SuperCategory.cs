using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class SuperCategory
    {
        public SuperCategory()
        {
            this.Campaigns = new List<Campaign>();
            this.Categories = new List<Category>();
        }

        public int SuperCategoryID { get; set; }
        public string SuperCategoryName { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
