using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class CardType
    {
        public CardType()
        {
            this.CampaignMainFrames = new List<CampaignMainFrame>();
        }

        public int CardTypeId { get; set; }
        public string CardDescription { get; set; }
        public string Status { get; set; }
        public virtual ICollection<CampaignMainFrame> CampaignMainFrames { get; set; }
    }
}
