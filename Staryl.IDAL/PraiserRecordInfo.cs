using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层PraiserRecord
    /// </summary>
    public partial interface IPraiserRecordDAL
    {
      int Create(PraiserRecordInfo model);
      bool Update(PraiserRecordInfo model);
      bool Delete(PraiserRecordInfo model);
      bool Deletes(string ids);
      PraiserRecordInfo Get(int Id );
      List<PraiserRecordInfo>  GetList();
      List<PraiserRecordInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<PraiserRecordInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<PraiserRecordInfo> list);
   } 
}
