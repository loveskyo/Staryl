using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staryl.Entity
{
    /// <summary>
    /// 前端展示栏目信息
    /// </summary>
    public class ViewMenuInfo : SystemMenuInfo
    {
        public List<SystemFunctionInfo> FunctionList { get; set; }
    }

}
