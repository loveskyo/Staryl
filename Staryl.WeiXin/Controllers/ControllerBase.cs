using Staryl.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Staryl.WeiXin.Controllers
{
    [AuthAttribute]
    public class ControllerBase : Controller
    {
        protected UserManager mUserMgr = new UserManager();
        protected StarUserManager mStarUserMgr = new StarUserManager();
        protected SystemAreaManager mSystemAreaMgr = new SystemAreaManager();
        /// <summary>
        /// 获取客户端的 IP地址
        /// </summary>
        protected string GetIP
        {
            get
            {
                return Request.UserHostAddress.ToString();// + "___" + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] + "___" + clientIPAddress;
            }
        }

        protected string GetCity
        {
            get { 
                return GetCityByIP(GetIP);
            }
        }

        /// <summary>
        /// 静态资源 访问地址
        /// </summary>
        public static string StaticDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["StaticDomain"];
            }
        }
        /// <summary>
        /// 站点域名
        /// </summary>
        protected string RootDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["RootDomain"];
            }
        }

        /// <summary>
        /// 上传的根目录
        /// </summary>
        protected string UploadRoot
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadRoot"];
            }
        }

        private string GetCityByIP(string ip)
        {
            if (string.IsNullOrEmpty(ip) || ip == "::1")
                return "中国";
            string url = string.Format("http://ip.taobao.com/service/getIpInfo.php?ip={0}", ip);
            string res = GetUrl(url);
            if (string.IsNullOrEmpty(res))
                return "中国";
            IPCity city = Newtonsoft.Json.JsonConvert.DeserializeObject<IPCity>(res);
            return city.data.city;
        }

        public string GetUrl(string url)
        {
            try
            {
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(url);
                // Get the response instance.
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream)
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.Default))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (System.Exception ex)
            {
                //errorMsg = ex.Message;
            }
            return "";
        }

        #region 上传图片文件夹
        /// <summary>
        /// 头像
        /// </summary>
        protected string AvatrUrl
        {
            get
            {
                return "Avatr";
            }
        }

        /// <summary>
        /// 相片
        /// </summary>
        protected string PhotoUrl
        {
            get
            {
                return "Photo";
            }
        }


        #endregion

        #region 登录信息
        private LoginUsers loginInfo = null;
        /// <summary>
        /// 用户Id
        /// </summary>
        protected int AccountId
        {
            get
            {
                if (LoginInfo == null)
                    return 0;
                return LoginInfo.Id;
            }
        }

        /// <summary>
        /// 登录邮箱
        /// </summary>
        protected string Email
        {
            get
            {
                if (LoginInfo == null)
                {
                    return string.Empty;
                }
                return LoginInfo.Email;
            }
        }
        /// <summary>
        /// 登录手机
        /// </summary>
        protected string Mobile
        {
            get
            {
                if (LoginInfo == null)
                {
                    return string.Empty;
                }
                return LoginInfo.Mobile;
            }
        }

        private LoginUsers LoginInfo
        {
            get
            {
                if (loginInfo == null)
                {
                    string strTicket = CookieHelper.Get(FormsAuthentication.FormsCookieName);
                    if (string.IsNullOrEmpty(strTicket))
                        return null;

                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(strTicket);



                    loginInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginUsers>(ticket.UserData);
                }
                return loginInfo;
            }

        }


        #endregion
    }
}