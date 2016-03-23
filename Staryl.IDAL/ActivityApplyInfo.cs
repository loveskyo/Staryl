using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层ActivityApply
    /// </summary>
    public partial interface IActivityApplyDAL
    {
      int Create(ActivityApplyInfo model);
      bool Update(ActivityApplyInfo model);
      bool Delete(ActivityApplyInfo model);
      bool Deletes(string ids);
      ActivityApplyInfo Get(int Id );
      List<ActivityApplyInfo>  GetList();
      List<ActivityApplyInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<ActivityApplyInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<ActivityApplyInfo> list);
      ActivityApplyInfo GetByActivityId_StarId(int ActivityId,int StarId);
   } 
}
