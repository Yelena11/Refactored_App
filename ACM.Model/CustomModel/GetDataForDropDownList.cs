using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.Model.CustomModel
{
   public partial  class GetDataForDropDownList
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
   public class GetDropDownListByID
   {
       public int ID { get; set; }
       public string Name { get; set; }
   }
   public  class GetDropDownListByValue
   {
       public string ID { get; set; }
       public string Name { get; set; }
   }
}
