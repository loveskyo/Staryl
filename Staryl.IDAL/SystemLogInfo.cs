using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层SystemLog
    /// </summary>
    public partial interface ISystemLogDAL
    {
      int Create(SystemLogInfo model);
      bool Update(SystemLogInfo model);
      bool Delete(SystemLogInfo model);
      bool Deletes(string ids);
      SystemLogInfo Get(int Id );
      List<SystemLogInfo>  GetList();
      List<SystemLogInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<SystemLogInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<SystemLogInfo> list);
   } 
}
