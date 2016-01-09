using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层StarUser
    /// </summary>
    public partial interface IStarUserDAL
    {
      IEnumerable<ViewStarUserInfo> GetByPage(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
   } 
}
