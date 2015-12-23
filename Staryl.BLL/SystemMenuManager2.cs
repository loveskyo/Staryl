
using System;
using System.Data;
using System.Collections.Generic;
using Staryl.Entity;
using Staryl.IDAL;
using Staryl.Factory;
namespace Staryl.BLL
{

    public partial class SystemMenuManager
    {
        public IList<ViewMenuInfo> GetViewMenu()
        {
            return dal.GetViewMenu();
        }
        /// <summary>
        /// 根据parendId获取栏目
        /// </summary>
        /// <param name="parentId">父级栏目Id</param>
        /// <returns></returns>
        public IEnumerable<SystemMenuInfo> GetMenuByParentId(int parentId)
        {
            return dal.GetMenuByParentId(parentId);
        }
    }
}
