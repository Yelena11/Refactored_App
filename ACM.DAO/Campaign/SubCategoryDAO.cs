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
   public class SubCategoryDAO
    {

        private ACM_Redesign2014Context ctx = new ACM_Redesign2014Context();

        public List<ACM.Model.SubCategory> GetSubCategoryById(int CategoryID)
        {
            try
            {
                ctx.Configuration.ProxyCreationEnabled = false;

                List<ACM.Model.SubCategory> subcategory = (from SubCategories in ctx.SubCategories
                                                           where SubCategories.CategoryID == CategoryID
                                                           select SubCategories).ToList();
                ctx.Configuration.ProxyCreationEnabled = true;
                return subcategory;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetCategoryById");
                throw;
            }
        }
    }
}
