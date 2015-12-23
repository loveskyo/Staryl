using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层SystemArea
    /// </summary>
    public partial interface ISystemAreaDAL
    {
      int Create(SystemAreaInfo model);
      bool Update(SystemAreaInfo model);
      bool Delete(SystemAreaInfo model);
      bool Deletes(string ids);
      SystemAreaInfo Get(int Id );
      List<SystemAreaInfo>  GetList();
      List<SystemAreaInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<SystemAreaInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<SystemAreaInfo> list);
   } 
}
