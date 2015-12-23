using Staryl.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.Manage.Controllers
{
    [AuthAttribute]
    public class ControllerBase : Controller
    {
        protected SystemAccountManager accountMgr = new SystemAccountManager();
        protected SystemRoleManager roleMgr = new SystemRoleManager();
        protected SystemMenuManager menuMgr = new SystemMenuManager();
        protected SystemPrivilegesManager privilegesMgr = new SystemPrivilegesManager();
        protected SystemFunctionManager functionMgr = new SystemFunctionManager();
        protected UserManager userMgr = new UserManager();

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
        /// 角色
        /// </summary>
        protected int Roles
        {
            get
            {
                if (Session["userinfo"] == null)
                {
                    return 0;
                }
                return Convert.ToInt32(Session["userinfo"].ToString().Split('$')[3]);
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

    }
}