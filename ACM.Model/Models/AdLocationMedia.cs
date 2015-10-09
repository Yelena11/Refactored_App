using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class AdLocationMedia
    {
        public int Id { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string AdLocationCode { get; set; }
        public string MediaSufix { get; set; }
        public int MediaFileTypeMask { get; set; }
        public int DuplicateMask { get; set; }
        public string FileSpec640 { get; set; }
        public string FileSpec800 { get; set; }
        public string Status { get; set; }
        public virtual AdLocation AdLocation { get; set; }
    }
}
