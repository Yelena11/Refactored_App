using ACM.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Util.ApplicationException;
using ACM.Model;
using System.Diagnostics;

namespace ACM.DAO.Util
{
  public static class Common
    {
      public static IEnumerable<GetDataForDropDownList> GetMasterDropDownDataforMasterTables(string MasterTableID, string MasterTableDescription, string MasterTableName)
      {
          ACM_Redesign2014Context ctx = new ACM_Redesign2014Context();
          try
          {
              var listItems = (ctx.Database.SqlQuery<GetDataForDropDownList>("exec GetListforDropDown @Param1,@Param2,@Param3",
                 new SqlParameter("Param1", MasterTableID),
                 new SqlParameter("Param2", MasterTableDescription),
                 new SqlParameter("Param3", MasterTableName)

                 )).ToList();
              return listItems;
          }
          catch (Exception ex)
          {
              Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetMasterDropDownDataforMasterTables");
              throw;
          }
      }
    }
}
