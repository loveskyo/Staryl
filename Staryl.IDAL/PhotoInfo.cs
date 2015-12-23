using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层Photo
    /// </summary>
    public partial interface IPhotoDAL
    {
      int Create(PhotoInfo model);
      bool Update(PhotoInfo model);
      bool Delete(PhotoInfo model);
      bool Deletes(string ids);
      PhotoInfo Get(int Id );
      List<PhotoInfo>  GetList();
      List<PhotoInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<PhotoInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<PhotoInfo> list);
   } 
}
