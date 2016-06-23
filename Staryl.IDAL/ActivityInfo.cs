using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层Activity
    /// </summary>
    public partial interface IActivityDAL
    {
      int Create(ActivityInfo model);
      bool Update(ActivityInfo model);
      bool Delete(ActivityInfo model);
      bool Deletes(string ids);
      ActivityInfo Get(int Id );
      List<ActivityInfo>  GetList();
      List<ActivityInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<ActivityInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<ActivityInfo> list);
   } 
}
