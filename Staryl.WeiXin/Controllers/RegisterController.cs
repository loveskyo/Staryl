using Newtonsoft.Json;
using Staryl.BLL;
using Staryl.Entity;
using Staryl.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Staryl.WeiXin.Controllers
{
    public class RegisterController : ControllerBase
    {
        //
        // GET: /Register/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Register value)
        {
            MsgInfo returnMsg = new MsgInfo
            {
                IsError = false,
                Msg = "",
                MsgNo = (int)ErrorEnum.成功
            };

            string code = Convert.ToString( CacheHelper.GetCache("code_" + Session.SessionID));
            if (code != value.MobileYzm)
            {
                returnMsg.IsError = true;
                returnMsg.Msg = "手机验证码错误";
                returnMsg.MsgNo = (int)ErrorEnum.失败;
                return Json(returnMsg);
            }


            UserInfo user = new UserInfo
            {
                CreateDate = DateTime.Now,
                CreateIP = this.GetIP,
                Mobile = value.Mobile,
                Email = Guid.NewGuid().ToString(),
                Birthday = DateTime.Parse("1900/01/01"),
                Status = (int)UserStatusEnum.正常,
                UserType = value.UserType,
                Password = Security.DESEncrypt(value.Password)
            };

            UserManager userMgr = new UserManager();
            int id = userMgr.Create(user);
            if (id > 0)
            {
                LoginUsers loginUser = new LoginUsers
                {
                    Avatar = string.Empty,
                    Email = string.Empty,
                    Id = id,
                    IsVIP = false,
                    Mobile = value.Mobile
                };
                string strUserData = JsonConvert.SerializeObject(loginUser);
                //保存身份信息
                FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, loginUser.Mobile, DateTime.Now, DateTime.Now.AddHours(12), false, strUserData);
                CookieHelper.Add(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(Ticket), RootDomain);//加密身份信息，保存至Cookie
                returnMsg.Msg = "成功";
            }
            else
                returnMsg.Msg = "失败";
            return Json(returnMsg);

        }

        [HttpPost]
        public ActionResult CheckMobile()
        {
            UserManager userMgr = new UserManager();
            string value = Request["Mobile"];
            if (value.Length < 11)
                return Content(JsonConvert.SerializeObject(new Remote { valid = true }));
            bool res = true;
            UserInfo userInfo = null;
            userInfo = userMgr.GetByMobile(value);

            if (userInfo != null)
            {
                res = false;
            }
            return Content(JsonConvert.SerializeObject(new Remote { valid = res }));
        }

        public ActionResult SendMsg(string mobile)
        {
            if (Convert.ToString(CacheHelper.GetCache("yz_" + Session.SessionID)) == "1")
            {
                return Json(false);
            }
            CacheHelper.Add2("yz_"+Session.SessionID, "1", new TimeSpan(0, 1, 0));
            
            SMSHelperManager smsHelperMgr = new SMSHelperManager();
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            int code = rd.Next(100000, 999999);
            string msgConten = "尊敬的用户，您的验证码是：" + code + "，请在10分钟内输入【小童星】";
            CacheHelper.Add2("code_" + Session.SessionID, code, new TimeSpan(0, 10, 0));
            //smsHelperMgr.SendSMS(mobile, msgConten);
            return Json(true);
        }
    }
}