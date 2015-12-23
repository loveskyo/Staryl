
using System;
using System.Data;
using System.Collections.Generic;
using Staryl.Entity;
using Staryl.IDAL;
using Staryl.Factory;
namespace Staryl.BLL
{

    public partial class UserManager
    {

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">手机/邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public string Login(string mobileOrEmail, string password)
        {
            return dal.Login(mobileOrEmail, password);
        }
    }
}
