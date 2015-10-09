using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class ETMConfiguration
    {
        public int CampaignId { get; set; }
        public string ETMDuration { get; set; }
        public string ETMEndonInteraction { get; set; }
        public string ETMCanSwitchToNextETM { get; set; }
        public string SupressDefault { get; set; }
        public Nullable<int> EventTriggerId { get; set; }
        public string Status { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual EventTrigger EventTrigger { get; set; }
    }
}
