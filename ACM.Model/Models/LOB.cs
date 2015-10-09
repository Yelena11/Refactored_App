using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class LOB
    {
        public LOB()
        {
            this.Users = new List<User>();
        }

        public int LOBId { get; set; }
        public string LOBName { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
