using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.DAO.Ad;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.BO.Ad
{
    public class AdLocationMediaBO
    {
        public Dictionary<string, string> CheckMediaFileTypes(string AdlocationCode)
        {
            try
            {
                AdlocationMediaDAO adlocationDAO = new AdlocationMediaDAO();
                ACM.Model.AdLocationMedia adLocationMedia = new Model.AdLocationMedia();

                adLocationMedia = adlocationDAO.CheckMediaFileTypes(AdlocationCode);
                int bitmask = adLocationMedia.MediaFileTypeMask;


                // List<string> lst = new List<string>();
                Dictionary<string, string> lst = new Dictionary<string, string>();


                if ((bitmask & 527) > 0)
                    lst.Add("Static", "Static");

                if ((bitmask & 60) > 0)
                    lst.Add("Animated", "Animated");
                if ((bitmask & 64) > 0)
                    lst.Add("Flash", "Flash");


                if ((bitmask & 2048) > 0)
                    lst.Add("Interactive", "Interactive");
                if ((bitmask & 4096) > 0)
                    lst.Add("PNG", "PNG");

                if ((bitmask & 8192) > 0)
                    lst.Add("TXT", "TXT");
                return lst;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CheckMediaFileTypes-BO");
                throw;
            }
        }
    }
}