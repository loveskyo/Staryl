using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层Fans
    /// </summary>
    public partial interface IFansDAL
    {
      int Create(FansInfo model);
      bool Update(FansInfo model);
      bool Delete(FansInfo model);
      bool Deletes(string ids);
      FansInfo Get(int Id );
      List<FansInfo>  GetList();
      List<FansInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<FansInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<FansInfo> list);
      FansInfo GetByStarId_FansId(int StarId,int FansId);
   } 
}
