using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class PromoButton
    {
        public PromoButton()
        {
            this.Campaigns = new List<Campaign>();
        }

        public int PromoButtonTypeId { get; set; }
        public string PromoButtonName { get; set; }
        public string RegisterEntry { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
