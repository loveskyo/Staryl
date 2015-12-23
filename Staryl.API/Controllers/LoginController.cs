using Newtonsoft.Json;
using Staryl.API.Models;
using Staryl.BLL;
using Staryl.Entity;
using Staryl.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Staryl.API.Controllers
{
    public class LoginController : BaseController
    {
        // GET api/login
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string[] values =  new string[] { "value1", "value2" };
            return values.toJson();  
        }

        // GET api/login/5
        [HttpGet]
        public HttpResponseMessage SignOut()
        {
            CookieHelper.Remove(FormsAuthentication.FormsCookieName, RootDomain);//移除Cookie
            MsgInfo msgInfo = new MsgInfo { 
                IsError=false,
                Msg="/Login.html",
                MsgNo=1
            };
            return msgInfo.toJson();
        }

        //Post api/login
        [HttpPost]
        public HttpResponseMessage Sign([FromBody]LoginParameter loginPara)
        {
            string res = mUserMgr.Login(loginPara.MobileOrEmail, loginPara.Password);
            MsgInfo loginMsg = JsonConvert.DeserializeObject<MsgInfo>(res);
            if (!loginMsg.IsError)
            {
                LoginUsers loginUser = JsonConvert.DeserializeObject<LoginUsers>(loginMsg.Msg);
                string strUserData = JsonConvert.SerializeObject(loginUser);


                //保存身份信息
                FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, loginUser.Mobile, DateTime.Now, DateTime.Now.AddHours(12), false, strUserData);

                CacheHelper.Add("LoginKey_"+Guid.NewGuid(),FormsAuthentication.Encrypt(Ticket));

                
                
                
                //CookieHelper.Add(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(Ticket), RootDomain);//加密身份信息，保存至Cookie
                loginMsg.Msg = loginPara.ReturnUrl;
                if (loginPara.IsRemember)
                    CookieHelper.Add("remember", loginUser.Mobile + "$" + Security.DESEncrypt(loginPara.Password), RootDomain);
                else
                    CookieHelper.Remove("remember");
            }
            return loginMsg.toJson();
        }
    }
}
