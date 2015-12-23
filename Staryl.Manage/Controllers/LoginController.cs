using Newtonsoft.Json;
using Staryl.BLL;
using Staryl.Entity;
using Staryl.Library;
using Staryl.Manage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Staryl.Manage.Controllers
{
    public class LoginController : ControllerBase
    {
        //
        // GET: /Login/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult unlogin()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Sign(string account, string password, string rUrl, string remember)
        {
            string res = (new SystemAccountManager()).Login(account, password);
            MsgInfo loginMsg = JsonConvert.DeserializeObject<MsgInfo>(res);
            if (!loginMsg.IsError)
            {
                LoginUsers loginUser = JsonConvert.DeserializeObject<LoginUsers>(loginMsg.Msg);
                string strUserData = JsonConvert.SerializeObject(loginUser);
                //保存身份信息
                FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, account, DateTime.Now, DateTime.Now.AddHours(12), false, strUserData);
                CookieHelper.Add(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(Ticket), RootDomain);//加密身份信息，保存至Cookie

                loginMsg.Msg = rUrl;
                if (remember == "true")
                    CookieHelper.Add("remember", loginUser.Account + "$" + Security.DESEncrypt(password), RootDomain);
                else
                    CookieHelper.Add("remember", "", RootDomain);
            }
            return Json(loginMsg);
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            CookieHelper.Remove(FormsAuthentication.FormsCookieName, RootDomain);//移除Cookie
            return Redirect("/Login");
        }






	}
}