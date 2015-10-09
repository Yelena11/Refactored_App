using ACM.Model;
using ACM.Model.CustomModel;
using ACM.Service.Client.AdServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.Service.Client
{
    public class Ad
    {
        AdServiceClient adProxy = new AdServiceClient();
        public Restrictions GetAdRestrictionCategory()
        {
            return adProxy.GetAdRestrictionCategory();
        }


        public List<AdOutStandingTask> GetOutstandingTask(ACM.Model.Ad request)
        {
            return adProxy.GetOutstandingTask(request);
        }

        public List<ACM.Model.Ad> AdInfo(ACM.Model.Ad request)
        {
            try
            {
                return adProxy.AdInfo(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "AdInfo");
                throw;
            }
        }

        public ACM.Model.Ad AdInq(ACM.Model.Ad request)
        {
            return adProxy.AdInq(request);
        }


        public ACM.Model.Ad AdAdd(ACM.Model.Ad request)
        {
            return adProxy.AdAdd(request);
        }


        public string AdMod(ACM.Model.Ad request)
        {
            return adProxy.AdMod(request);
        }

        public string AdDel(ACM.Model.Ad request)
        {
            return adProxy.AdDel(request);
        }
        public string UpdateAdRestriction(ACM.Model.Ad request)
        {
            //return adProxy.UpdateAdRestriction(request);
            return string.Empty;
        }
    }
}