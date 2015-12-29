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


    public class ReturnData
    {
        public object Data { get; set; }
        public int CurrPage { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
    }


    public class ViewUndergo : UndergoInfo
    {
        public IEnumerable<string> PhotoList { get; set; }
    }
}