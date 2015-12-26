using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staryl.Manage.Models
{
    public enum enumbase
    {

    }

    public enum UserTypeEnum
    {
        个人用户 = 1,
        机构用户 = 2
    }

    public enum ErrorEnum
    {
        成功 = 1,
        失败 = 0,
        超时未登录 = -1,
        没有权限 = -2
    }
}