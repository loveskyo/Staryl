
using System;
using System.Data;
using System.Collections.Generic;
using Staryl.Entity;
using Staryl.IDAL;
using Staryl.Factory;
namespace Staryl.BLL
{

    public partial class SystemAccountManager
    {


        public string Login(string account, string password)
        {
            return dal.Login(account, password);
        }
        /// <summary>
        /// 获取数据，带分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="recordCount"></param>
        /// <param name="doCount"></param>
        /// <returns></returns>
        public IEnumerable<ViewAccountInfo> GetByPage(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount)
        {
            return dal.GetByPage(pageIndex, pageSize, where, orderBy, out recordCount, doCount);
        }
    }
}
