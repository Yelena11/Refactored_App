using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class CampaignTargetFileProvider
    {
        public int CampaignId { get; set; }
        public string IWillProvideTargetFile { get; set; }
        public string OPRProvideTargetFile { get; set; }
        public string Frequency { get; set; }
        public string ECNCardNumber { get; set; }
        public string TargetFileCompleted { get; set; }
        public string OPRCriteria { get; set; }
        public string OPR { get; set; }
        public string FollowUPNeeded { get; set; }
        public string Status { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public Nullable<int> Filed4 { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}
