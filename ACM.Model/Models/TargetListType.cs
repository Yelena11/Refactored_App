using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class TargetListType
    {
        public TargetListType()
        {
            this.CampaignMainFrames = new List<CampaignMainFrame>();
        }

        public int TargetListTypeId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public virtual ICollection<CampaignMainFrame> CampaignMainFrames { get; set; }
    }
}
