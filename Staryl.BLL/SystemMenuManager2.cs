
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
        /// ����parendId��ȡ��Ŀ
        /// </summary>
        /// <param name="parentId">������ĿId</param>
        /// <returns></returns>
        public IEnumerable<SystemMenuInfo> GetMenuByParentId(int parentId)
        {
            return dal.GetMenuByParentId(parentId);
        }
    }
}
