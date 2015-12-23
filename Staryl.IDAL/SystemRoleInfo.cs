using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层SystemRole
    /// </summary>
    public partial interface ISystemRoleDAL
    {
      int Create(SystemRoleInfo model);
      bool Update(SystemRoleInfo model);
      bool Delete(SystemRoleInfo model);
      bool Deletes(string ids);
      SystemRoleInfo Get(int Id );
      List<SystemRoleInfo>  GetList();
      List<SystemRoleInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<SystemRoleInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<SystemRoleInfo> list);
   } 
}
