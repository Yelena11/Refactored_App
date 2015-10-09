using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.DAO.Admin
{
    public class UsersDAO
    {
        private ACM_Redesign2014Context ACMContex = new ACM_Redesign2014Context();

        public List<User> GetUserDetails(string loginId)
        {
            try
            {
                ACMContex.Configuration.LazyLoadingEnabled = true;

                List<User> userDetails = ACMContex.Users.ToList();
                List<User> userDetailsByLoginId = userDetails.Where(x => x.LoginId.Contains(loginId)).ToList();


                ACMContex.Configuration.ProxyCreationEnabled = false;
                ACMContex.Users.Include("LOB").ToList();
                ACMContex.Users.Include("Role").ToList();
                ACMContex.Configuration.ProxyCreationEnabled = true;

                return userDetailsByLoginId;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetUserDetails");
                throw;
            }
        }

        public User GetUserDetail(string loginId)
        {

            ACMContex.Configuration.LazyLoadingEnabled = true;
            try
            {
                var userDetails = ACMContex.Users.Where(x => x.LoginId.Contains(loginId));
                User user = new User();
                foreach (var item in userDetails)
                {
                    user.UserId = item.UserId;
                    user.LoginId = item.LoginId;
                    user.FirstName = item.FirstName;
                    user.LastName = item.LastName;
                    user.CreatedBy = item.CreatedBy;
                    user.CreatedDate = item.CreatedDate;
                    user.LOBId = item.LOBId;
                    user.Status = item.Status;
                }
                return user;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetUserDetail");
                throw;
            }
        }
    }
}
