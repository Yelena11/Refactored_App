using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class AdOutStandingTask
    {
        public int Id { get; set; }
        public int AdId { get; set; }
        public int CampaignId { get; set; }
        public string OutStandingTasks { get; set; }
        public string Status { get; set; }
        public Nullable<int> TasksOrder { get; set; }
        public virtual Ad Ad { get; set; }
    }
}
