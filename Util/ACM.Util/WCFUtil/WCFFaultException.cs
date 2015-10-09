using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ACM.Util.WCFUtil
{
    /// <summary>
    /// This clas is to Handle the WCF Exceptions
    /// </summary>
    public class WCFFaultException
    {

        public static Exception GetClientException(Exception exp, string MethodName)
        {
            Exception e;
            String str=null;
            if (exp is FaultException)
            {
                WriteException(exp.ToString(), str);
                return exp;
            }
            if (exp is CommunicationException)
            {

                WriteException(exp.ToString(), str);
                return exp;
            }
            if (exp is EndpointNotFoundException)
            {

                WriteException(exp.ToString(), str);
            }

            else {

                WriteException(exp.ToString(), str);
               
              //  Exception GenException = new GenericException(exp.Message, exp);
            }
            return null;
        
        
        }
        public static void WriteException(string exception, string str)
        { 
        
        }
    }
}
