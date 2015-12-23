using System;
using System.Data;
using System.Text;
using System.Collections.Generic; 
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Staryl.DAL;
using Staryl.IDAL;
using Staryl.Entity;

namespace Staryl.DAL
{
             
    public partial class SystemMenuDAL
    {
        public IList<ViewMenuInfo> GetViewMenu()
        {
            List<SystemMenuInfo> list = this.GetList();
           List<ViewMenuInfo> viewMenuList = new List<ViewMenuInfo>();
            if (list != null)
            {
                SystemFunctionDAL functionDal = new SystemFunctionDAL();
                foreach (var info in list)
                {
                    viewMenuList.Add(new ViewMenuInfo
                    {
                        Id = info.Id,
                        MenuName = info.MenuName,
                        MenuAddr = info.MenuAddr,
                        FunctionList = functionDal.GetByCodes(info.Functions.Split(','))
                    });
                }
            }
            return viewMenuList;
        }
        /// <summary>
        /// 根据parendId获取栏目
        /// </summary>
        /// <param name="parentId">父级栏目Id</param>
        /// <returns></returns>
        public IList<SystemMenuInfo> GetMenuByParentId(int parentId)
        {
            string where = "ParentId=" + parentId;
            List<SystemMenuInfo> list = this.GetListByWhere(0, where);
            return list;
        }
    }


}

