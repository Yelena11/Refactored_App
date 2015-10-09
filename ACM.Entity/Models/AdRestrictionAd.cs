using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class AdRestrictionAd
    {
        public int Id { get; set; }
        public int AdRestrictionId { get; set; }
        public int AdId { get; set; }
        public int CampaignId { get; set; }
        public virtual Ad Ad { get; set; }
        public virtual AdRestriction AdRestriction { get; set; }
    }
}
