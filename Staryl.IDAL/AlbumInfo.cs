using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层Album
    /// </summary>
    public partial interface IAlbumDAL
    {
      int Create(AlbumInfo model);
      bool Update(AlbumInfo model);
      bool Delete(AlbumInfo model);
      bool Deletes(string ids);
      AlbumInfo Get(int Id );
      List<AlbumInfo>  GetList();
      List<AlbumInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<AlbumInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<AlbumInfo> list);
      List<AlbumInfo> GetByUserId(int UserId );
   } 
}
