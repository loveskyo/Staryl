using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staryl.WeiXin
{
    public enum Enumbase
    {
    }

    public enum ErrorEnum
    {
        成功 = 1,
        失败 = 0,
        超时未登录 = -1,
        没有权限 = -2
    }
}