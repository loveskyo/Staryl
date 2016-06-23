using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层Activity
    /// </summary>
    public partial interface IActivityDAL
    {
      List<ViewActivityInfo> GetPageListView(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
   } 
}
