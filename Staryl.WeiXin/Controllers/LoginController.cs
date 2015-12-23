using Newtonsoft.Json;
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
    public class LoginController : ControllerBase
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            ViewBag.City = this.GetCity;
            return View();
        }

        [HttpPost]
        public ActionResult Sign(LoginParameter loginPara)
        {
            string res = mUserMgr.Login(loginPara.MobileOrEmail, loginPara.Password);
            MsgInfo loginMsg = JsonConvert.DeserializeObject<MsgInfo>(res);
            if (!loginMsg.IsError)
            {
                LoginUsers loginUser = JsonConvert.DeserializeObject<LoginUsers>(loginMsg.Msg);
                string strUserData = JsonConvert.SerializeObject(loginUser);

                //保存身份信息
                FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, loginUser.Mobile, DateTime.Now, DateTime.Now.AddHours(12), false, strUserData);
                CookieHelper.Add(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(Ticket), RootDomain);//加密身份信息，保存至Cookie
                loginMsg.Msg = loginPara.ReturnUrl;
                if (loginPara.IsRemember)
                    CookieHelper.Add("remember", loginUser.Mobile + "$" + Security.DESEncrypt(loginPara.Password), RootDomain);
                else
                    CookieHelper.Remove("remember");
            }
            return Json(loginMsg);

        }
	}
}