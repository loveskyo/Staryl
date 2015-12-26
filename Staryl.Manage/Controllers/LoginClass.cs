using Newtonsoft.Json;
using Staryl.Manage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Staryl.Manage.Controllers
{
    public class LoginClass
    {

        /// <summary>
        /// 角色
        /// </summary>
        public static int Roles
        {
            get
            {
                if (UserInfo == null)
                {
                    return 0;
                }
                return UserInfo.RoleId;
            }
        }


        private static LoginUsers UserInfo
        {
            get
            {
                if (HttpContext.Current.Request.IsAuthenticated)//是否通过身份验证
                {
                    string authCookie = CookieHelper.Get(FormsAuthentication.FormsCookieName);
                    FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookie);//解密
                    return JsonConvert.DeserializeObject<LoginUsers>(Ticket.UserData);
                }
                return null;
            }
        }

    }
}