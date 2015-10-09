using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.Model
{
    public class CampaignRequestor
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public int RequestorId { get; set; }
        public Nullable<int> LOBId { get; set; }
        public string RequestorFirstName { get; set; }
        public string RequestorLastName { get; set; }
        public string CampaignDetails { get; set; }
        public int CampaignTypeId { get; set; }
        public string TargetAudience { get; set; }
        public string TargetLoadFrequency { get; set; }
        public string FollowUpRequriements { get; set; }
        public System.DateTime CampaignStartDate { get; set; }
        public System.DateTime CampaingEndDate { get; set; }
        public Nullable<int> AssignedPMId { get; set; }
        public string AssignedPMFirstName { get; set; }
        public string AssignedPMLastName { get; set; }
        public string CampaignStatus { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedFirstName { get; set; }
        public string CreatedPMLastName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string ModifiedByFirstName { get; set; }
        public string ModifiedByLastName { get; set; }
        public string Action { get; set; }

    }
}
