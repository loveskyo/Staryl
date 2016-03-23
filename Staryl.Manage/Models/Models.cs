using Staryl.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Staryl.Manage.Models
{
    public class ViewModels
    {
        public  IEnumerable<ViewAccountInfo> AccountList { get; set; }

        public IEnumerable<SystemRoleInfo> RoleList{get;set;}

        public SystemAccountInfo AccountInfo { get; set; }

        public SystemRoleInfo RoleInfo { get; set; }

        public IEnumerable<ViewMenuInfo> MenuList { get; set; }

        public IEnumerable<SystemMenuInfo> SystemMenuList { get; set; }

        public SystemMenuInfo MenuInfo { get; set; }
        public IEnumerable<SystemPrivilegesInfo> PrivilegesList { get; set; }

        public IEnumerable<SystemFunctionInfo> FunctionList{get;set;}

        public UserInfo UserInfo { get; set; }

        public StarUserInfo StarUser { get; set; }

        public ActivityInfo Activity { get; set; }

        public PageControl PageHtml { get; set; }
    }

    public class Select2Info {
        public int id { get; set; }
        public string text { get; set; }
    }

    public class ReturnData
    {
        public object Data { get; set; }
        public int CurrPage { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
    }
    /// <summary>
    /// 验证返回值
    /// </summary>
    public class Remote
    {
        public bool valid { get; set; }
        public string message { get; set; }
    }


    /// <summary>
    /// 登录用户信息
    /// </summary>
    public class LoginUsers
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
    }

    public class PrivilegesInfo : SystemPrivilegesInfo
    {
        public string MenuAddr { get; set; }
    }

    public class PageControl
    {
        int showpagecount = 0;
        int pageindex = 0;
        /// <summary>
        /// 每页记录数
        /// </summary>
        [Localizable(true)]
        [Description("每页记录数")]
        public int PageSize { get; set; }
        /// <summary>
        /// 需要显示的页码数量
        /// </summary>
        [Localizable(true)]
        [Description("需要显示的页码数量")]
        public int ShowPageCount
        {
            get
            {
                if (showpagecount <= 0)
                {
                    showpagecount = 10;
                }
                return showpagecount;
            }
            set
            {
                if (value > 0)
                {
                    showpagecount = value;
                }
            }

        }
        /// <summary>
        /// 当前页码
        /// </summary>
        [Localizable(true)]
        [Description("当前页码, \n 页码 < 1 时, 默认设为第一页, \n 页码 > 总页数 时,设为最后一页.")]
        public int PageIndex
        {
            get
            {
                if (pageindex <= 0)
                {
                    pageindex = 1;
                }
                return pageindex;
            }
            set
            {
                if (value > 0)
                {
                    pageindex = value;
                }
            }
        }
        /// <summary>
        /// 记录总数
        /// </summary>
        [Localizable(true)]
        [Description("记录总数")]
        public int RowsCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        [Localizable(true)]
        [Description("总页数")]
        public int PageCount
        {
            get
            {
                int s = 0;
                try
                {
                    if (this.RowsCount % this.PageSize == 0)
                    {
                        s = this.RowsCount / this.PageSize;
                    }
                    else
                    {
                        s = this.RowsCount / this.PageSize + 1;
                    }
                }
                catch
                {
                    s = 0;
                }
                return s;
            }
        }
        /// <summary>
        /// 跳转URL
        /// </summary>
        [Localizable(true)]
        [Description("跳转URL")]
        public string ToPageUrl { get; set; }
    }

}