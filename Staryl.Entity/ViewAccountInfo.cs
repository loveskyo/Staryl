﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staryl.Entity
{
    /// <summary>
    /// 前端展示用户信息
    /// </summary>
    public class ViewAccountInfo : SystemAccountInfo
    {
        public string RoleName { get; set; }
    }
}
