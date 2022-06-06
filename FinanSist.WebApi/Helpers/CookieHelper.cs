using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanSist.WebApi.Helpers
{
    public class CookieHelper
    {
        public static void ClearCookie(HttpResponse respose)
        {
            respose.Cookies.Append("tk_Finansist", "false", new CookieOptions() { Domain = Environment.GetEnvironmentVariable("DomainCookie"), Expires = DateTime.Now.AddDays(-1) });
        }
        public static void SetCookie(HttpResponse response, string? token)
        {
            response.Cookies.Append("tk_Finansist", token ?? "", new CookieOptions() { Domain = Environment.GetEnvironmentVariable("DomainCookie"), HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true, MaxAge = TimeSpan.FromHours(2) });

        }
    }
}