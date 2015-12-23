using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层Undergo
    /// </summary>
    public partial interface IUndergoDAL
    {
      int Create(UndergoInfo model);
      bool Update(UndergoInfo model);
      bool Delete(UndergoInfo model);
      bool Deletes(string ids);
      UndergoInfo Get(int Id );
      List<UndergoInfo>  GetList();
      List<UndergoInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<UndergoInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<UndergoInfo> list);
      List<UndergoInfo> GetByStarUserId(int StarUserId );
   } 
}
