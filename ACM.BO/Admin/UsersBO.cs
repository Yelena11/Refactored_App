using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.DAO.Admin;
using ACM.Model;

namespace ACM.BO.Admin
{
    public class UsersBO
    {
        public List<User> GetUserDetails(string loginId)
        {
            UsersDAO usersDAO = new UsersDAO();
            return usersDAO.GetUserDetails(loginId);

        }

        public User GetUserDetail(string loginId)
        {
            UsersDAO usersDAO = new UsersDAO();
            return usersDAO.GetUserDetail(loginId);

        }
    }
}
