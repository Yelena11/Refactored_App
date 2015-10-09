using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class FollowUp
    {
        public FollowUp()
        {
            this.CampaignFollowUps = new List<CampaignFollowUp>();
        }

        public int FollowUpId { get; set; }
        public string FollowUpDescription { get; set; }
        public string Status { get; set; }
        public virtual ICollection<CampaignFollowUp> CampaignFollowUps { get; set; }
    }
}
