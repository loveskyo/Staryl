using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层User
    /// </summary>
    public partial interface IUserDAL
    {
      int Create(UserInfo model);
      bool Update(UserInfo model);
      bool Delete(UserInfo model);
      bool Deletes(string ids);
      UserInfo Get(int Id );
      List<UserInfo>  GetList();
      List<UserInfo>  GetPageList(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount);
      List<UserInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null);
      bool Create(List<UserInfo> list);
      UserInfo GetByEmail(string Email);
      UserInfo GetByMobile(string Mobile);
   } 
}
