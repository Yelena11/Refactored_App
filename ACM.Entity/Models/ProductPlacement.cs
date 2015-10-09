using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class ProductPlacement
    {
        public ProductPlacement()
        {
            this.Campaigns = new List<Campaign>();
        }

        public int ProductPlacementId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string UIMapping { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
