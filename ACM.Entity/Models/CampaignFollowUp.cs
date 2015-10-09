using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class CampaignFollowUp
    {
        public int CampaignId { get; set; }
        public string FollowUpRequirements { get; set; }
        public Nullable<int> FollowUpId { get; set; }
        public Nullable<int> FollowUpSystem { get; set; }
        public string FollowUpSystemName { get; set; }
        public string Business { get; set; }
        public string Status { get; set; }
        public int CreateBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual FollowUp FollowUp { get; set; }
    }
}
