using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            this.CampaignMainFrames = new List<CampaignMainFrame>();
        }

        public int CustomerTypeId { get; set; }
        public string CustomerTypeDesc { get; set; }
        public string Status { get; set; }
        public virtual ICollection<CampaignMainFrame> CampaignMainFrames { get; set; }
    }
}
