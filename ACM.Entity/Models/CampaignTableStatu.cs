using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class CampaignTableStatu
    {
        public CampaignTableStatu()
        {
            this.Campaigns = new List<Campaign>();
        }

        public int CampaignTableStatusId { get; set; }
        public string CampaignTableStatusDescription { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
