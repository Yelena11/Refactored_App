using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class User
    {
        public User()
        {
            this.Campaigns = new List<Campaign>();
            this.Campaigns1 = new List<Campaign>();
            this.Campaigns2 = new List<Campaign>();
            this.Campaigns3 = new List<Campaign>();
        }

        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phoneno { get; set; }
        public string Email { get; set; }
        public Nullable<int> LOBId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public string ManagerEmail { get; set; }
        public string AU { get; set; }
        public string Status { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Campaign> Campaigns1 { get; set; }
        public virtual ICollection<Campaign> Campaigns2 { get; set; }
        public virtual ICollection<Campaign> Campaigns3 { get; set; }
        public virtual LOB LOB { get; set; }
        public virtual Role Role { get; set; }
        public virtual Role Role1 { get; set; }
    }
}
