using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model;

namespace ACM.Model.CustomModel
{
    public  class CampaignMetaData
    {
        [Required]
        public   string CampaignName { get; set; }
    }
}
