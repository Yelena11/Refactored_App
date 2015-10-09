using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ACM.Util.ApplicationException
{
    public static class Error
    {
        public static void WriteException(TraceEventType Severity, String ErrorMessage, String MethodName)
        {
            LogEntry entry = new LogEntry();
            entry.Severity = Severity;
            entry.Message = ErrorMessage;
            Logger.Write(entry);
        }
    }
}