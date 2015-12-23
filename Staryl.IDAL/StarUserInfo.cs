using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层StarUser
    /// </summary>
    public partial interface IStarUserDAL
    {
      int Create(StarUserInfo model);
      bool Update(StarUserInfo model);
      bool Delete(StarUserInfo model);
      bool Deletes(string ids);
      StarUserInfo Get(int Id );
      List<StarUserInfo>  GetList();
      List<StarUserInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<StarUserInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<StarUserInfo> list);
      List<StarUserInfo> GetByParentId(int ParentId );
   } 
}
