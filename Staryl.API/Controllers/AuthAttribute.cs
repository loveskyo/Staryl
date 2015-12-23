using Newtonsoft.Json;
using Staryl.BLL;
using Staryl.Entity;
using Staryl.API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;

namespace Staryl.API.Controllers
{
    /// <summary>
    /// 权限验证
    /// </summary>
    public class AuthAttribute : ActionFilterAttribute
    {
        protected SystemMenuManager systemMenubll = new SystemMenuManager();
        protected SystemPrivilegesManager systemPrivilegesbll = new SystemPrivilegesManager();

        /// <summary>
        /// 可匿名访问的控制器
        /// </summary>
        public string[] AnonymousPage
        {
            get
            {
                return ConfigurationManager.AppSettings["AnonymousPage"].ToString().Split(',');
            }
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //if (AnonymousPage.Contains(actionContext.ActionDescriptor.ControllerDescriptor.ControllerName))
                return;

            string v = Convert.ToString(HttpContext.Current.Session["a"]);

            //如果不存在身份信息
            if (CheckLogin)
            {
                MsgInfo msgInfo = new MsgInfo
                {
                    IsError = true,
                    Msg = "您已超时或未登陆,重新登陆",
                    MsgNo = (int)ErrorEnum.超时未登录
                };
                actionContext.Response = msgInfo.toJson();
                //actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
           
        }
        private bool CheckLogin
        {
            get
            {
                string strTicket = CookieHelper.Get(FormsAuthentication.FormsCookieName);
                return string.IsNullOrEmpty(strTicket);
            }
        }

        



    }
}