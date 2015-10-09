using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class AdSchedulingCondition
    {
        public int ID { get; set; }
        public int DeploymentPeriodID { get; set; }
        public int AdId { get; set; }
        public string AdLocationCode { get; set; }
        public Nullable<int> AllRegionsFlag { get; set; }
        public Nullable<int> AllStateFlag { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Ad Ad { get; set; }
        public virtual AdLocation AdLocation { get; set; }
        public virtual DeploymentPeriod DeploymentPeriod { get; set; }
    }
}
