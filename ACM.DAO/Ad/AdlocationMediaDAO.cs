using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.DAO.Ad
{
   public class AdlocationMediaDAO
    {
       private ACM_Redesign2014Context ctx = new ACM_Redesign2014Context();
       public ACM.Model.AdLocationMedia  CheckMediaFileTypes(string AdlocationCode)

       {
           ACM.Model.AdLocationMedia adMediaType = new AdLocationMedia();
           try
           {
               ctx.Configuration.ProxyCreationEnabled = false;
              adMediaType = (from res in ctx.AdLocationMedias
                                                        where res.AdLocationCode==AdlocationCode
                                                        select res).SingleOrDefault();
               // ctx.AdLocationMedias.Find(AdlocationCode);Ytr_1261
               ctx.Configuration.ProxyCreationEnabled = true;
           }
           catch (Exception ex)
           {
               Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetCategoryById");
               throw;
           }
           return adMediaType;
       
       }
    }
}
