
using System;
using System.Data;
using System.Collections.Generic;
using Staryl.Entity;
using Staryl.IDAL;
using Staryl.Factory;
namespace Staryl.BLL
{

    public partial class SMSHelperManager : BaseManager
    {
        private static readonly ISMSHelper dal = DataAccess<ISMSHelper>.CreateObject("SMSHelper");

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="message">短信内容</param>
        /// <returns></returns>
        public string SendSMS(string mobile, string message)
        {
            return dal.SendSMS(mobile, message);
        }
    }
}
