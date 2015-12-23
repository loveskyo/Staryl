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
        /// ��¼
        /// </summary>
        /// <param name="account">�ֻ�/����</param>
        /// <param name="password">����</param>
        /// <returns></returns>
        public string Login(string mobileOrEmail, string password)
        {
            MsgInfo msgInfo = new MsgInfo { Msg = "��¼�ɹ�", MsgNo = 0, IsError = false };
            UserInfo userInfo = null;
            if (mobileOrEmail.IndexOf('@') > 0)
                this.GetByEmail(mobileOrEmail);
            else
                userInfo = this.GetByMobile(mobileOrEmail);

            if (userInfo == null)
            {
                msgInfo.Msg = "�û������������";
                msgInfo.MsgNo = -1;
                msgInfo.IsError = true;
                return JsonConvert.SerializeObject(msgInfo);
            }
            if (userInfo.Password != Security.DESEncrypt(password))
            {
                msgInfo.Msg = "�û������������";
                msgInfo.MsgNo = -1;
                msgInfo.IsError = true;
                return JsonConvert.SerializeObject(msgInfo);
            }
            if (userInfo.Status == (int)UserStatusEnum.����)
            {
                msgInfo.Msg = "�����˺��ѱ����ã�����ϵ����Ա";
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

