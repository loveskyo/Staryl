using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层SystemFunction
    /// </summary>
    public partial interface ISystemFunctionDAL
    {
      int Create(SystemFunctionInfo model);
      bool Update(SystemFunctionInfo model);
      bool Delete(SystemFunctionInfo model);
      bool Deletes(string ids);
      SystemFunctionInfo Get(int Id );
      List<SystemFunctionInfo>  GetList();
      List<SystemFunctionInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<SystemFunctionInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<SystemFunctionInfo> list);
      SystemFunctionInfo GetByFunctionCode(string FunctionCode);
   } 
}
