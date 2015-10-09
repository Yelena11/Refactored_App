using System;
using System.Collections.Generic;

namespace ACM.Model
{
    public partial class MediaFileType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileExt { get; set; }
        public int GroupCode { get; set; }
        public string GroupName { get; set; }
        public string IsStaticImage { get; set; }
        public string IsAnimated { get; set; }
        public int ATMTypeId { get; set; }
        public int FileSpecSize { get; set; }
        public string IsFlash { get; set; }
        public virtual ATMType ATMType { get; set; }
    }
}
