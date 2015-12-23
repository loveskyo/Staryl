using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层SystemAccount
    /// </summary>
    public partial interface ISystemAccountDAL
    {
      int Create(SystemAccountInfo model);
      bool Update(SystemAccountInfo model);
      bool Delete(SystemAccountInfo model);
      bool Deletes(string ids);
      SystemAccountInfo Get(int Id );
      List<SystemAccountInfo>  GetList();
      List<SystemAccountInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<SystemAccountInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<SystemAccountInfo> list);
   } 
}
