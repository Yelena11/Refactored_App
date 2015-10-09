using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class State
    {
        public State()
        {
            this.CampaignLocations = new List<CampaignLocation>();
            this.RegionAdDisplayRules = new List<RegionAdDisplayRule>();
            this.RegionCampaignDisplayRules = new List<RegionCampaignDisplayRule>();
            this.StateAdDisplayRules = new List<StateAdDisplayRule>();
            this.StateCampaignDisplayRules = new List<StateCampaignDisplayRule>();
        }

        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string Status { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<CampaignLocation> CampaignLocations { get; set; }
        public virtual ICollection<RegionAdDisplayRule> RegionAdDisplayRules { get; set; }
        public virtual ICollection<RegionCampaignDisplayRule> RegionCampaignDisplayRules { get; set; }
        public virtual ICollection<StateAdDisplayRule> StateAdDisplayRules { get; set; }
        public virtual ICollection<StateCampaignDisplayRule> StateCampaignDisplayRules { get; set; }
    }
}
