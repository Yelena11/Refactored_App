using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Utility
{
    public static string LoginId(string loginId)
    {
        if (loginId.Contains("AD-ENT\\"))
            return loginId.Replace("AD-ENT\\", "");
        return loginId;
    }
}