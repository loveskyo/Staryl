using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层SystemMenu
    /// </summary>
    public partial interface ISystemMenuDAL
    {
      int Create(SystemMenuInfo model);
      bool Update(SystemMenuInfo model);
      bool Delete(SystemMenuInfo model);
      bool Deletes(string ids);
      SystemMenuInfo Get(int Id );
      List<SystemMenuInfo>  GetList();
      List<SystemMenuInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<SystemMenuInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<SystemMenuInfo> list);
      SystemMenuInfo GetByMenuAddr(string MenuAddr);
   } 
}
