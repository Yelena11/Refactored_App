using System;
using System.Collections.Generic;

namespace ACM.Model
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
