using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.Model.CustomModel
{
  
    public class Restrictions
    {
        public Dictionary<int, string> DepositoryType { get; set; }
        public Dictionary<int, string> EFcutoff { get; set; }
        public Dictionary<int, string> Other { get; set; }
    }
   
    public enum AdRestrictionFlag
    {
        DepositoryType = 1,
        EFcutoff = 2,
        Other = 3
    }
}
