using Staryl.API.Models;
using Staryl.BLL;
using Staryl.Entity;
using Staryl.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Staryl.API.Controllers
{
    //[AuthAttribute]
    public class BaseController : ApiController
    {
        protected UserManager mUserMgr = new UserManager();


        /// <summary>
        /// 站点域名
        /// </summary>
        protected string RootDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["RootDomain"];
            }
        }

    }
}

