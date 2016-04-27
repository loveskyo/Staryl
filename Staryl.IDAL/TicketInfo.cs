using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层Ticket
    /// </summary>
    public partial interface ITicketDAL
    {
      int Create(TicketInfo model);
      bool Update(TicketInfo model);
      bool Delete(TicketInfo model);
      bool Deletes(string ids);
      TicketInfo Get(int Id );
      List<TicketInfo>  GetList();
      List<TicketInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<TicketInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<TicketInfo> list);
      TicketInfo GetByTicketNo(string TicketNo);
   } 
}
