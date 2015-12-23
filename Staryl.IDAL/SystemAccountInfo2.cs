using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层SystemAccount
    /// </summary>
    public partial interface ISystemAccountDAL
    {
        string Login(string account, string password);
        IEnumerable<ViewAccountInfo> GetByPage(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
    }
}
