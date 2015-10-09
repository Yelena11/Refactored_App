/*
 
 
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ACM.Util.WCFUtil
{
    public class WCFUtility
    {
        public static void CloseClient(ICommunicationObject client)
        {
            if (client != null && client.State == CommunicationState.Faulted)
            {
                client.Abort();
            }
            else
            {
                client.Close();
            }
        }
    }
}
