using Newtonsoft.Json;
using Staryl.BLL;
using Staryl.Entity;
using Staryl.Manage.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Staryl.Manage.Controllers
{
    /// <summary>
    /// 权限验证
    /// </summary>
    public class AuthAttribute : ActionFilterAttribute
    {
        protected SystemMenuManager systemMenubll = new SystemMenuManager();
        protected SystemPrivilegesManager systemPrivilegesbll = new SystemPrivilegesManager();
        /// <summary>
        /// 权限值
        /// </summary>
        protected List<PrivilegesInfo> UserPrivilegesInfo
        {
            get
            {
                return GetPrivileges();
            }
        }
        /// <summary>
        /// 功能Code
        /// </summary>
        public string FunCode
        {
            get;
            set;
        }
        /// <summary>
        /// 返回值类型 json/view
        /// </summary>
        public string ReturnType
        {
            get;
            set;
        }
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

        public bool OpenPrivileges
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["OpenPrivileges"]);
            }
        }

        /// <summary>
        /// 验证权限（action执行前会先执行这里）
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AnonymousPage.Contains( filterContext.ActionDescriptor.ControllerDescriptor.ControllerName))
                return;
            //如果存在身份信息
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
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
                    Content.Content = string.Format("<script type='text/javascript'>window.location.href='{0}';</script>", "/login/unlogin");
                    filterContext.Result = Content;
                }
            }
            else if (OpenPrivileges)
            {
                if (!IsPrevilege(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, FunCode))//验证权限
                {
                    if (ReturnType == "json")
                    {
                        JsonResult jsonRes = new JsonResult();
                        MsgInfo msgInfo = new MsgInfo
                        {
                            IsError = true,
                            Msg = "没有访问权限,请联系管理员",
                            MsgNo = (int)ErrorEnum.没有权限
                        };
                        jsonRes.Data = JsonConvert.SerializeObject(msgInfo);
                    }
                    else
                    {

                        //验证不通过
                        ContentResult Content = new ContentResult();
                        Content.Content = "<script type='text/javascript'>alert('权限验证不通过！');history.go(-1);</script>";
                        filterContext.Result = Content;
                    }
                }
            }
        }
        /// <summary>
        /// 判断角色对应某个栏目、功能是否具有权限
        /// </summary>
        /// <param name="MenuAddr">栏目地址</param>
        /// <param name="FunCode">栏目功能</param>
        /// <returns></returns>
        public bool IsPrevilege(string MenuAddr, string FunCode = "")
        {
            if (string.IsNullOrEmpty(FunCode))
                return UserPrivilegesInfo.Any(p => p.MenuAddr == MenuAddr);
            else
                return UserPrivilegesInfo.Any(p => p.MenuAddr == MenuAddr && p.FunctionCodes.Contains(FunCode));
        }
        /// <summary>
        /// 获取特定角色的所有权限
        /// </summary>
        /// <returns></returns>
        public List<PrivilegesInfo> GetPrivileges()
        {

            List<SystemPrivilegesInfo> list = systemPrivilegesbll.GetByRoleId(LoginClass.Roles);
            IEnumerable<int> menuids = list.Select(p => p.MenuId);
            List<SystemMenuInfo> UserMenuList = systemMenubll.GetListByWhere(0, "Id in(" + string.Join(",", menuids) + ")");
            List<PrivilegesInfo> UserPrivilegesList = new List<PrivilegesInfo>();
            foreach (var info in list)
            {
                UserPrivilegesList.Add(new PrivilegesInfo
                {
                    FunctionCodes = info.FunctionCodes,
                    Id = info.Id,
                    MenuAddr = UserMenuList.First(p => p.Id == info.MenuId).MenuAddr,
                    MenuId = info.MenuId,
                    RoleId = info.RoleId
                });
            }
            return UserPrivilegesList;
        }




    }
}