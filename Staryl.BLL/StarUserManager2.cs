
using System;
using System.Data;
using System.Collections.Generic;
using Staryl.Entity;
using Staryl.IDAL;
using Staryl.Factory;
namespace Staryl.BLL
{

    public partial class StarUserManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex">1,2,3开始，以此类推</param>    
        /// <param name="pageSize"></param>  
        /// <param name="where">''表示无条件; 查询条件(注意:不要加where)如:'xname like ''%222name%'''</param>  
        /// <param name="orderBy">必须有值 : 例 order by ID DESC </param>  
        /// <param name="recordCount"></param>  
        /// <param name="doCount">  1则统计,为0则不统计(统计会影响效率),使用范例之一：在前台调用时候，针对同样的查询，在1分钟内就第一次，调用查询所有的记录数</param>  
        public IEnumerable<ViewStarUserInfo> GetByPage(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount)
        {
            return dal.GetByPage(pageIndex, pageSize, where, orderBy, out   recordCount, doCount);
        }
    }
}
