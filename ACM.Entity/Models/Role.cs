using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class Role
    {
        public Role()
        {
            this.Users = new List<User>();
            this.Users1 = new List<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<User> Users1 { get; set; }
    }
}
