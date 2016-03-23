using Staryl.API.Models;
using Staryl.BLL;
using Staryl.Entity;
using Staryl.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Staryl.API.Controllers
{
    public class RegisterController : BaseController
    {
        // POST api/login
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Register value)
        {
            UserInfo user = new UserInfo
            {
                CreateDate = DateTime.Now,
                CreateIP = "",
                Mobile = value.Mobile,
                Email = Guid.NewGuid().ToString(),
                Status = (int)UserStatusEnum.正常,
                Password = Security.DESEncrypt(value.Password)
            };
            MsgInfo returnMsg = new MsgInfo {
            IsError=false,
            Msg="",
            MsgNo = (int)ErrorEnum.成功
            };

            UserManager userMgr = new UserManager();
            int id = userMgr.Create(user);
            if (id > 0)
                returnMsg.Msg = "成功";
            else
                returnMsg.Msg = "失败";
            return returnMsg.toJson();

        }

    }
}

