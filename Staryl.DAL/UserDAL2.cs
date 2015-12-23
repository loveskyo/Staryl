using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Staryl.Library;
using Staryl.IDAL;
using Staryl.Entity;
using Newtonsoft.Json;

namespace Staryl.DAL
{

    public partial class UserDAL : BaseDAL, IUserDAL
    {


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">手机/邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public string Login(string mobileOrEmail, string password)
        {
            MsgInfo msgInfo = new MsgInfo { Msg = "登录成功", MsgNo = 0, IsError = false };
            UserInfo userInfo = null;
            if (mobileOrEmail.IndexOf('@') > 0)
                this.GetByEmail(mobileOrEmail);
            else
                userInfo = this.GetByMobile(mobileOrEmail);

            if (userInfo == null)
            {
                msgInfo.Msg = "用户名或密码错误";
                msgInfo.MsgNo = -1;
                msgInfo.IsError = true;
                return JsonConvert.SerializeObject(msgInfo);
            }
            if (userInfo.Password != Security.DESEncrypt(password))
            {
                msgInfo.Msg = "用户名或密码错误";
                msgInfo.MsgNo = -1;
                msgInfo.IsError = true;
                return JsonConvert.SerializeObject(msgInfo);
            }
            if (userInfo.Status == (int)UserStatusEnum.禁用)
            {
                msgInfo.Msg = "您的账号已被禁用，请联系管理员";
                msgInfo.MsgNo = -1;
                msgInfo.IsError = true;
                return JsonConvert.SerializeObject(msgInfo);
            }
            msgInfo.Msg = JsonConvert.SerializeObject(userInfo);
            msgInfo.IsError = false;
            return JsonConvert.SerializeObject(msgInfo);
        }




    }


}

