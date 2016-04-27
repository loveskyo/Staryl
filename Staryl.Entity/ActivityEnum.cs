using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staryl.Entity
{
    /// <summary>
    /// 活动状态枚举
    /// </summary>
    public enum ActivityStatusEnum
    {
        已结束 = 0,
        报名中 = 1,
        进行中 = 2
    }

    /// <summary>
    /// 活动类型枚举
    /// </summary>
    public enum ActivityTypeEnum
    {
        其他 = 0,
        演出通告 = 1,
        公益活动 = 2,
        亲子活动 = 3,
        第三方活动 = 4
    }

    /// <summary>
    /// 活动收费级别枚举
    /// </summary>
    public enum ActivityChargeLevelEnum
    {
        全部免费 = 0,
        会员免费 = 1,
        VIP免费 = 2,
        全部收费 = 3
    }
}
