using ACM.Model;
using ACM.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.Util
{
    public static class Common
    {
        public static IEnumerable<GetDropDownListByValue> GetDropDownListByValue(string MasterTableID, string MasterTableDescription, string MasterTableName)
        {
            List<GetDropDownListByValue> listItems = new List<GetDropDownListByValue>();
            using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
            {
                listItems = (ctx.Database.SqlQuery<GetDropDownListByValue>("exec GetListforDropDown @Param1,@Param2,@Param3",
                   new SqlParameter("Param1", MasterTableID),
                   new SqlParameter("Param2", MasterTableDescription),
                   new SqlParameter("Param3", MasterTableName)

                   )).ToList();
            }
            return listItems;
        }
        public static IEnumerable<GetDropDownListByID> GetDropDownListByID(string MasterTableID, string MasterTableDescription, string MasterTableName)
        {
            List<GetDropDownListByID> listItems = new List<GetDropDownListByID>();
            using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
            {
                listItems = (ctx.Database.SqlQuery<GetDropDownListByID>("exec GetListforDropDown @Param1,@Param2,@Param3",
                  new SqlParameter("Param1", MasterTableID),
                  new SqlParameter("Param2", MasterTableDescription),
                  new SqlParameter("Param3", MasterTableName)

                  )).ToList();
            }
            return listItems;
        }


      
    }

  
}
