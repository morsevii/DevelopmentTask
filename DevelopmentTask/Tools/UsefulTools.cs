using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DevelopmentTask.Tools
{
    public static class UsefulTools
    {
        public static string GetBaseURL(string arg = "")
        {
            return string.Format("{0}://{1}/{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, arg);
        }
        public static string ToYMD(this string str)
        {

            return DateTime.Parse(str).ToString("yyyy/MM/dd");
        }
        public static string ToYMDHm(this string str)
        {

            return DateTime.Parse(str).ToString("yyyy/MM/dd HH:mm");
        }
    }
}