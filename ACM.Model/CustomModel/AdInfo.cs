using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ACM.Model.CustomModel
{

    public class AdInfo
    {
        public virtual AdInfo_Result Ad { get; set; }
        public virtual List<AdRestrictions> AdRestriction { get; set; }
    }

    public partial class AdInfo_Result
    {
        public int AdId { get; set; }
        public string AdName { get; set; }
        public int CampaignId { get; set; }
        public string AdStatus { get; set; }
        public Nullable<int> AdProductTypeId { get; set; }
        public Nullable<int> DNSScrubLevel { get; set; }
        public Nullable<int> ATMTypeId { get; set; }
        public Nullable<int> MediaVendorId { get; set; }
        public string AdLocationCode { get; set; }
        public Nullable<int> MediaFileIndex { get; set; }
        public string MediaFileTagWeb { get; set; }
        public string MediaFileTagMx { get; set; }
        public string MediaType { get; set; }
        public Nullable<int> AdRestrictionId { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public Nullable<int> Field8 { get; set; }
        public Nullable<int> Field9 { get; set; }
        public Nullable<int> Field10 { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string AdGuid { get; set; }
        public string RestrictionNames { get; set; }
        public string AdLocationDesc { get; set; }
    }

    public enum AdStatus
    {
        Active = 1,
        Cancelled = 2
    }

    public class GetRestrictionFlag
    {
        public int CategoryID { get; set; }
        public int RestrictionID { get; set; }
    }
}