using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model;
using ACM.Model.CustomModel;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.DAO.Campaign
{
    
    public class CategoryDAO
    {
        private ACM_Redesign2014Context ctx = new ACM_Redesign2014Context();

        public List<ACM.Model.Category> GetCategoryById(int SuperCategoryId)
        {
            try
            {
                ctx.Configuration.ProxyCreationEnabled = false;

                List<ACM.Model.Category> category = (from Categories in ctx.Categories
                                                     where Categories.SuperCategoryID == SuperCategoryId
                                                     select Categories).ToList();
                ctx.Configuration.ProxyCreationEnabled = true;
                return category;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetCategoryById");
                throw;
            }
        }

    }
}
