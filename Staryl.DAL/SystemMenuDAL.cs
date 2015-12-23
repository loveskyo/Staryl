using System;
using System.Data;
using System.Text;
using System.Collections.Generic; 
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Staryl.Library;
using Staryl.IDAL;
using Staryl.Entity;

namespace Staryl.DAL
{
             
    public partial class SystemMenuDAL:BaseDAL, ISystemMenuDAL
    {
        
public int Create(SystemMenuInfo model)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("insert into SystemMenu(");
         sb.Append("MenuName,MenuAddr,ParentId,IsLeft,IsTop,Functions,IsMenu,MenuLevel");
         sb.Append(") values(");
         sb.Append("@MenuName,@MenuAddr,@ParentId,@IsLeft,@IsTop,@Functions,@IsMenu,@MenuLevel);SELECT @@IDENTITY;");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@MenuName", DbType.String, model.MenuName);
            db.AddInParameter(dbCommand, "@MenuAddr", DbType.String, model.MenuAddr);
            db.AddInParameter(dbCommand, "@ParentId", DbType.Int32, model.ParentId);
            db.AddInParameter(dbCommand, "@IsLeft", DbType.Boolean, model.IsLeft);
            db.AddInParameter(dbCommand, "@IsTop", DbType.Boolean, model.IsTop);
            db.AddInParameter(dbCommand, "@Functions", DbType.String, model.Functions);
            db.AddInParameter(dbCommand, "@IsMenu", DbType.Boolean, model.IsMenu);
            db.AddInParameter(dbCommand, "@MenuLevel", DbType.Int32, model.MenuLevel);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));  
            return id; 
      }


      public bool Update(SystemMenuInfo model) 
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("update SystemMenu set ");
         sb.Append("MenuName=@MenuName,MenuAddr=@MenuAddr,ParentId=@ParentId,IsLeft=@IsLeft,IsTop=@IsTop,Functions=@Functions,IsMenu=@IsMenu,MenuLevel=@MenuLevel");
         sb.Append(" where Id=@Id");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
         db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id);
         db.AddInParameter(dbCommand, "@MenuName", DbType.String, model.MenuName);
         db.AddInParameter(dbCommand, "@MenuAddr", DbType.String, model.MenuAddr);
         db.AddInParameter(dbCommand, "@ParentId", DbType.Int32, model.ParentId);
         db.AddInParameter(dbCommand, "@IsLeft", DbType.Boolean, model.IsLeft);
         db.AddInParameter(dbCommand, "@IsTop", DbType.Boolean, model.IsTop);
         db.AddInParameter(dbCommand, "@Functions", DbType.String, model.Functions);
         db.AddInParameter(dbCommand, "@IsMenu", DbType.Boolean, model.IsMenu);
         db.AddInParameter(dbCommand, "@MenuLevel", DbType.Int32, model.MenuLevel);
         return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public bool Delete(SystemMenuInfo model)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from SystemMenu");
         sb.Append(" where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id); 
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }
      public bool Deletes(string ids)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from SystemMenu");
         sb.Append(" where ID in(" + ids + ")");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public SystemMenuInfo  Get( int  Id ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from SystemMenu where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id",  DbType.Int32,  Id); 

           SystemMenuInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = FillList(dataReader);
                }
            }
            return model; 
      }


      public  List<SystemMenuInfo>  GetList(  ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from SystemMenu order by Id desc");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<SystemMenuInfo> list =  new List<SystemMenuInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      public  List<SystemMenuInfo>  GetPageList( int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount  ) 
      {
         Database db = DBHelper.CreateDataBase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager2005");  
            db.AddInParameter(dbCommand, "tblName", DbType.String, "SystemMenu");
             db.AddInParameter(dbCommand, "strGetFields", DbType.String, "*");
            db.AddInParameter(dbCommand, "strOrder", DbType.String, orderBy);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, where.Trim());
            db.AddInParameter(dbCommand, "pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "pageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbCommand, "recordCount", DbType.Int32, 8);
            db.AddInParameter(dbCommand, "doCount", DbType.Boolean, doCount); 
            List<SystemMenuInfo> list =  new List<SystemMenuInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
     
            recordCount = (int)db.GetParameterValue(dbCommand, "recordCount"); return  list;
      }


      public  List<SystemMenuInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         string top = string.Empty;
         if(count>0) top=" top " + count + "";
         if(string.IsNullOrEmpty(fields)) fields="*";
         if(string.IsNullOrEmpty(orderBy)) orderBy=" order by Id desc";
         if(!string.IsNullOrEmpty(where)) where=" where " + where + "";
         sb.Append("select"+top+" "+fields+" from SystemMenu"+where+""+orderBy+"");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<SystemMenuInfo> list =  new List<SystemMenuInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      private SystemMenuInfo  FillList(  IDataReader dataReader  )
      { 
            SystemMenuInfo model = new SystemMenuInfo();
            object ojb;
            ojb = dataReader["Id"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = ( int)(ojb);
            }
            ojb = dataReader["MenuName"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MenuName = ( string)(ojb);
            }
            ojb = dataReader["MenuAddr"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MenuAddr = ( string)(ojb);
            }
            ojb = dataReader["ParentId"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ParentId = ( int)(ojb);
            }
            ojb = dataReader["IsLeft"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsLeft = ( bool)(ojb);
            }
            ojb = dataReader["IsTop"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsTop = ( bool)(ojb);
            }
            ojb = dataReader["Functions"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Functions = ( string)(ojb);
            }
            ojb = dataReader["IsMenu"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsMenu = ( bool)(ojb);
            }
            ojb = dataReader["MenuLevel"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MenuLevel = ( int)(ojb);
            }

            return model;
        }


        public  bool Create(List<SystemMenuInfo> list)
        { 
bool suc = BaseDAL.ExecuteTransactionScopeInsert(this.ToDataTable(list), 250, "SystemMenu"); return suc; }



         private    DataTable  ToDataTable(List<SystemMenuInfo> list)
        { 
            if (list == null || list.Count <1)
            {
                return null;
            }
            DataTable result = new DataTable();
            if (list.Count > 0)
            {

                string columnNameList = "?Id??MenuName??MenuAddr??ParentId??IsLeft??IsTop??Functions??IsMenu??MenuLevel?"; 

                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    var colType = pi.PropertyType;
                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    } 
                if (columnNameList.Contains("?"  + pi.Name + "?") == true) 
                   {
                        result.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                } 
            }
            result.AcceptChanges();
            
             
            #region column name
            for (int i = 0; i < list.Count; i++)
            {
                DataRow dr = result.NewRow();
            
                dr["Id"] = list[i].Id; 
                dr["MenuName"] = list[i].MenuName; 
                dr["MenuAddr"] = list[i].MenuAddr; 
                dr["ParentId"] = list[i].ParentId; 
                dr["IsLeft"] = list[i].IsLeft; 
                dr["IsTop"] = list[i].IsTop; 
                dr["Functions"] = list[i].Functions; 
                dr["IsMenu"] = list[i].IsMenu; 
                dr["MenuLevel"] = list[i].MenuLevel; 

                result.Rows.Add(dr );
            }
            #endregion
            result.AcceptChanges(); 
            return result;
        }
    



        public SystemMenuInfo  GetByMenuAddr(string MenuAddr)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from SystemMenu where MenuAddr=@MenuAddr");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@MenuAddr",  DbType.String,  MenuAddr); 
            SystemMenuInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = FillList(dataReader);
                }
            }
            return model; 
      }


             
    }


}

