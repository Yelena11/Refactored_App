using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class StateAdDisplayRule
    {
        public int ID { get; set; }
        public int DeploymentPeriodId { get; set; }
        public int AdId { get; set; }
        public string AdLocationCode { get; set; }
        public int Ixclude { get; set; }
        public string StateCode { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Ad Ad { get; set; }
        public virtual DeploymentPeriod DeploymentPeriod { get; set; }
        public virtual State State { get; set; }
    }
}
