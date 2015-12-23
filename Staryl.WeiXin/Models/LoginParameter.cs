using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staryl.WeiXin
{
    /// <summary>
    /// 登录提交参数
    /// </summary>
    public struct LoginParameter
    {
        /// <summary>
        /// 登录手机号或邮箱
        /// </summary>
        public string MobileOrEmail { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 登录成功跳转地址
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 是否记住密码
        /// </summary>
        public bool IsRemember { get; set; }
    }

}