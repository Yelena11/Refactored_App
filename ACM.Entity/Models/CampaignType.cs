using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class CampaignType
    {
        public CampaignType()
        {
            this.Campaigns = new List<Campaign>();
        }

        public int CampaignTypeId { get; set; }
        public string CampaignTypeName { get; set; }
        public string CampaignTypeStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
