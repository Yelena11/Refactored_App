using System;
using System.Collections.Generic;

namespace ACM.Entity.Models
{
    public partial class EventTrigger
    {
        public EventTrigger()
        {
            this.ETMConfigurations = new List<ETMConfiguration>();
        }

        public int EventTriggerId { get; set; }
        public string EventTriggerName { get; set; }
        public string RegisterEntry { get; set; }
        public string Status { get; set; }
        public virtual ICollection<ETMConfiguration> ETMConfigurations { get; set; }
    }
}
