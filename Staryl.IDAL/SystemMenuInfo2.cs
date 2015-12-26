using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层SystemMenu
    /// </summary>
    public partial interface ISystemMenuDAL
    {
        IList<ViewMenuInfo> GetViewMenu();

        IList<SystemMenuInfo> GetMenuByParentId(int parentId);
    }
}
