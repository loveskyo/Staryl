using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staryl.Entity
{
    public class IndexQueue
    {
        public string IndexName { get; set; }
        public int Id { get; set; }

        public string KeyWords { get; set; }

        public IndexType IT { get; set; }
    }

    //操作类型枚举
    public enum IndexType {
        Insert,
        Modify,
        Delete
    }

}
