using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层SystemPrivileges
    /// </summary>
    public partial interface ISystemPrivilegesDAL
    {
      int Create(SystemPrivilegesInfo model);
      bool Update(SystemPrivilegesInfo model);
      bool Delete(SystemPrivilegesInfo model);
      bool Deletes(string ids);
      SystemPrivilegesInfo Get(int Id );
      List<SystemPrivilegesInfo>  GetList();
      List<SystemPrivilegesInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<SystemPrivilegesInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<SystemPrivilegesInfo> list);
      List<SystemPrivilegesInfo> GetByRoleId(int RoleId );
   } 
}
