using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class RegFileCategory
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public string IsDeployable { get; set; }
        public string IsTargeted { get; set; }
        public Nullable<int> ATMTypeID { get; set; }
        public string VendorGroup { get; set; }
        public Nullable<int> CategoryIndex { get; set; }
        public virtual ATMType ATMType { get; set; }
    }
}
