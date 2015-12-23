using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staryl.WeiXin
{
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
        /// 登录手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 是否VIP
        /// </summary>
        public bool IsVIP { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string Avatar { get; set; }
    }
}