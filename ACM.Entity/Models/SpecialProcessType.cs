using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class SpecialProcessType
    {
        public SpecialProcessType()
        {
            this.CampaignMainFrames = new List<CampaignMainFrame>();
        }

        public int SpecialProcessTypeId { get; set; }
        public string SpecialProcessTypeDesc { get; set; }
        public string Status { get; set; }
        public virtual ICollection<CampaignMainFrame> CampaignMainFrames { get; set; }
    }
}
