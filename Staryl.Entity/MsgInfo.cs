using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staryl.Entity
{
    /// <summary>
    /// 返回信息
    /// </summary>
    public class MsgInfo
    {
        /// <summary>
        /// 信息内容
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 信息编号
        /// </summary>
        public int MsgNo { get; set; }
        /// <summary>
        /// 是否错误
        /// </summary>
        public bool IsError { get; set; }
    }

}
