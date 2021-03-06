using System;
using System.Text;
using System.Web;

namespace Staryl.API
{
    public class CookieHelper
    {
        #region Check Parameters
        private static void CheckKey(string key)
        {
            if (key == null || key == string.Empty)
            {
                throw new ArgumentNullException("key", "key should never be null or empty.");
            }
        }

        private static void CheckValue(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "value should never be null or empty.");
            }
        }

        #endregion

        #region Add Cookie
        private static void Add(string key, string value, int slidingMinutes, string domainName, string path/*, bool httpOnly, bool ssl*/)
        {
            CheckKey(key);
            CheckValue(value);

            HttpCookie responseCookie = new HttpCookie(key);
            responseCookie.Value = HttpUtility.UrlEncode(value);

            if (slidingMinutes > 0)
                responseCookie.Expires = DateTime.Now.AddMinutes(slidingMinutes);
            else
                responseCookie.Expires = DateTime.Now.AddMonths(1);//DateTime.MaxValue;

            if (!(domainName == null || domainName == string.Empty))
                responseCookie.Domain = domainName;

            HttpContext.Current.Response.Cookies.Add(responseCookie);
        }

        public static void Add(string key, string value, DateTime expirationDate/*, bool isSSL*/)
        {
            CheckKey(key);
            CheckValue(value);

            HttpCookie responseCookie = new HttpCookie(key);
            responseCookie.Value = HttpUtility.UrlEncode(value);

            responseCookie.Expires = expirationDate;

            HttpContext.Current.Response.Cookies.Add(responseCookie);
        }

        public static void Add(string key, string value, int slidingMinutes)
        {
            Add(key, value, slidingMinutes, "", "");
        }

        public static void Add(string key, string value)
        {
            Add(key, value, -1, "", "");
        }

        public static void Add(string key, string value, string domainName)
        {
            Add(key, value, -1, domainName, "/");
        }

        #endregion

        #region Get Cookie Value
        public static string Get(string key)
        {
            CheckKey(key);

            string value = string.Empty;

            HttpCookie requestCookie = HttpContext.Current.Request.Cookies[key];
            if (requestCookie != null)
            {
                value = HttpUtility.UrlDecode(requestCookie.Value);
            }

            return value;
        }
        #endregion

        #region Remove Cookie
        public static void Remove(string key)
        {
            Remove(key, string.Empty);
        }

        public static void Remove(string key, string domainName)
        {
            CheckKey(key);

            if (!string.IsNullOrEmpty(domainName))
            {
                HttpContext.Current.Response.Cookies[key].Domain = domainName;
            }
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-10);
        }

        public static void RemoveAll()
        {
            foreach (string key in HttpContext.Current.Request.Cookies.AllKeys)
            {
                HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-10);
            }
        }
        #endregion

        public static void Resume(string key, int slidingMinutes)
        {
            CheckKey(key);

            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddMinutes(slidingMinutes);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}
