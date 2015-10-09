using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BO.Campaign
{
    public class SubCategoryBO
    {
        public List<ACM.Model.SubCategory> GetSubCategoryById(int CategoryId)
        {
            ACM.DAO.Campaign.SubCategoryDAO subcategoryDAO = new DAO.Campaign.SubCategoryDAO();
            return subcategoryDAO.GetSubCategoryById(CategoryId);
        }
    }
}
