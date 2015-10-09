using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class CampaignMainFrame
    {
        public int CampaignId { get; set; }
        public Nullable<int> CardTypeId { get; set; }
        public Nullable<int> TargetListTypeId { get; set; }
        public Nullable<int> CustomerTypeId { get; set; }
        public string BusinessProductCode { get; set; }
        public string ConsumerProductCode { get; set; }
        public string TargetYearPeriod { get; set; }
        public string EmployeeWashOut { get; set; }
        public string HV_WashOut { get; set; }
        public string TrustWashOut { get; set; }
        public string PCS_WashOut { get; set; }
        public string Sourced_From { get; set; }
        public string Sourced_LOB { get; set; }
        public Nullable<int> SpecialProcessId { get; set; }
        public string CCLR_Channel { get; set; }
        public string Status { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public Nullable<int> Filed4 { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual CardType CardType { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual SpecialProcessType SpecialProcessType { get; set; }
        public virtual TargetListType TargetListType { get; set; }
    }
}
