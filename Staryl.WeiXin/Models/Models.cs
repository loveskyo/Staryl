using Staryl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staryl.WeiXin
{
    public class ViewModels
    {
        public UserInfo userInfo { get; set; }

        public StarUserInfo starUserInfo { get; set; }

        public SystemAreaInfo systemArea { get; set; }
        public List<SystemAreaInfo> systemAreaList { get; set; }
    }
}