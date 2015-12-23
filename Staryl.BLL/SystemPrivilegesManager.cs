
using System;
using System.Data;
using System.Collections.Generic;
using Staryl.Entity;
using Staryl.IDAL;
using Staryl.Factory;
namespace Staryl.BLL
{

   public partial class SystemPrivilegesManager:BaseManager
   {
   private static readonly ISystemPrivilegesDAL dal = DataAccess<ISystemPrivilegesDAL>.CreateObject("SystemPrivilegesDAL");

                        public int Create(SystemPrivilegesInfo model)
                        {
                            int id = dal.Create( model );
                            return id;
                        }

                    public bool CreateList(List<SystemPrivilegesInfo>  list)
                    { 
                        return dal.Create( list );
                    }

        public bool Update(SystemPrivilegesInfo model)
        {
            return dal.Update(model);
        }

        public bool Delete(SystemPrivilegesInfo model)
        {
            return dal.Delete(model);
        }

        public bool Deletes(string ids)
        {
            return dal.Deletes(ids);
        }

                    public SystemPrivilegesInfo Get( int Id  )
                    {
                        return dal.Get(  Id );
                    }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex">1,2,3开始，以此类推</param>    
        /// <param name="pageSize"></param>  
        /// <param name="where">''表示无条件; 查询条件(注意:不要加where)如:'xname like ''%222name%'''</param>  
        /// <param name="orderBy">必须有值 : 例 order by ID DESC </param>  
        /// <param name="recordCount"></param>  
        /// <param name="doCount">  1则统计,为0则不统计(统计会影响效率),使用范例之一：在前台调用时候，针对同样的查询，在1分钟内就第一次，调用查询所有的记录数</param>  
        public  List<SystemPrivilegesInfo> GetPageList( int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount  )   
        {
           return dal.GetPageList(   pageIndex,   pageSize,   where,   orderBy, out   recordCount,   doCount  ) ;
        }

        public  List<SystemPrivilegesInfo> GetList( )
        {
           return dal.GetList(   );
        }

        public  List<SystemPrivilegesInfo> GetListByWhere(int count, string where=null, string fields=null, string orderBy = null)
        {
           return dal.GetListByWhere( count,  where , fields,  orderBy);
        }

        public List< SystemPrivilegesInfo> GetByRoleId(int RoleId)
        {
            return dal.GetByRoleId(  RoleId);
        }
   }
}
