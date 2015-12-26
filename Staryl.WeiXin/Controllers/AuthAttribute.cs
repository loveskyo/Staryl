using Newtonsoft.Json;
using Staryl.BLL;
using Staryl.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace Staryl.WeiXin.Controllers
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
        /// <summary>
        /// 返回值类型 json/view
        /// </summary>
        public string ReturnType
        {
            get;
            set;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AnonymousPage.Contains(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName))
                return;
            //如果不存在身份信息
            if (CheckLogin)
            {



                if (ReturnType == "json")
                {
                    JsonResult jsonRes = new JsonResult();
                    MsgInfo msgInfo = new MsgInfo
                    {
                        IsError = true,
                        Msg = "您已超时或未登陆,重新登陆",
                        MsgNo = (int)ErrorEnum.超时未登录
                    };
                    jsonRes.Data = JsonConvert.SerializeObject(msgInfo);
                }
                else
                {
                    ContentResult Content = new ContentResult();
                    Content.Content = string.Format("<script type='text/javascript'>window.location.href='{0}';</script>", "/login");
                    filterContext.Result = Content;
                }




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