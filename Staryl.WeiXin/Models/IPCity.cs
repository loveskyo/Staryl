using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staryl.WeiXin
{
    public class IPCity
    {
        public int code{get;set;}
        public CityInfo data { get; set; }
    }

    public class CityInfo
    {
        public string country{get;set;}
        public string area{get;set;}
        public string region{get;set;}

        public string city{get;set;}
        public string county{get;set;}
        public string isp{get;set;}
    }

    
}