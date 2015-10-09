using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model.CustomModel;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.BO.Util
{
    public class Common
    {

        public IEnumerable<GetDataForDropDownList> GetMasterDropDownDataforMasterTables(string MasterTableID, string MasterTableDescription, string MasterTableName)
        {
            try
            {
                Common common = new Common();
                return common.GetMasterDropDownDataforMasterTables(MasterTableID, MasterTableDescription, MasterTableName);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetMasterDropDownDataforMasterTables-BO");
                throw;
            }
        }
    }
}