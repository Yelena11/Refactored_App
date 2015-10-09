using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class ATMType
    {
        public ATMType()
        {
            this.Ads = new List<Ad>();
            this.MediaFileTypes = new List<MediaFileType>();
            this.RegFileCategories = new List<RegFileCategory>();
        }

        public int ATMTypeId { get; set; }
        public string ATMTypeName { get; set; }
        public string ShortName { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }
        public virtual ICollection<MediaFileType> MediaFileTypes { get; set; }
        public virtual ICollection<RegFileCategory> RegFileCategories { get; set; }
    }
}
