using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class Language
    {
        public Language()
        {
            this.AdLocations = new List<AdLocation>();
        }

        public int LanguageId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AdLocation> AdLocations { get; set; }
    }
}
