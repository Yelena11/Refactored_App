using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BO.Campaign
{
    public class CategoryBO
    {
        public List<ACM.Model.Category> GetCategoryById(int SuperCategoryId)
        {
            ACM.DAO.Campaign.CategoryDAO categoryDAO = new DAO.Campaign.CategoryDAO();
            return categoryDAO.GetCategoryById(SuperCategoryId);
        }
    }
}
