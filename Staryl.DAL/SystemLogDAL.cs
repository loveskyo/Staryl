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
             
    public partial class SystemLogDAL:BaseDAL, ISystemLogDAL
    {
        
public int Create(SystemLogInfo model)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("insert into SystemLog(");
         sb.Append("MethodName,MethodSignature,TypeName,CallContext,SystemName,UseTime,Args,CreateDate,CreateIP,ReturnValue,LogType");
         sb.Append(") values(");
         sb.Append("@MethodName,@MethodSignature,@TypeName,@CallContext,@SystemName,@UseTime,@Args,@CreateDate,@CreateIP,@ReturnValue,@LogType);SELECT @@IDENTITY;");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@MethodName", DbType.String, model.MethodName);
            db.AddInParameter(dbCommand, "@MethodSignature", DbType.String, model.MethodSignature);
            db.AddInParameter(dbCommand, "@TypeName", DbType.String, model.TypeName);
            db.AddInParameter(dbCommand, "@CallContext", DbType.String, model.CallContext);
            db.AddInParameter(dbCommand, "@SystemName", DbType.String, model.SystemName);
            db.AddInParameter(dbCommand, "@UseTime", DbType.Int32, model.UseTime);
            db.AddInParameter(dbCommand, "@Args", DbType.String, model.Args);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
            db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
            db.AddInParameter(dbCommand, "@ReturnValue", DbType.String, model.ReturnValue);
            db.AddInParameter(dbCommand, "@LogType", DbType.Int32, model.LogType);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));  
            return id; 
      }


      public bool Update(SystemLogInfo model) 
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("update SystemLog set ");
         sb.Append("MethodName=@MethodName,MethodSignature=@MethodSignature,TypeName=@TypeName,CallContext=@CallContext,SystemName=@SystemName,UseTime=@UseTime,Args=@Args,CreateDate=@CreateDate,CreateIP=@CreateIP,ReturnValue=@ReturnValue,LogType=@LogType");
         sb.Append(" where Id=@Id");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
         db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id);
         db.AddInParameter(dbCommand, "@MethodName", DbType.String, model.MethodName);
         db.AddInParameter(dbCommand, "@MethodSignature", DbType.String, model.MethodSignature);
         db.AddInParameter(dbCommand, "@TypeName", DbType.String, model.TypeName);
         db.AddInParameter(dbCommand, "@CallContext", DbType.String, model.CallContext);
         db.AddInParameter(dbCommand, "@SystemName", DbType.String, model.SystemName);
         db.AddInParameter(dbCommand, "@UseTime", DbType.Int32, model.UseTime);
         db.AddInParameter(dbCommand, "@Args", DbType.String, model.Args);
         db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
         db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
         db.AddInParameter(dbCommand, "@ReturnValue", DbType.String, model.ReturnValue);
         db.AddInParameter(dbCommand, "@LogType", DbType.Int32, model.LogType);
         return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public bool Delete(SystemLogInfo model)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from SystemLog");
         sb.Append(" where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id); 
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }
      public bool Deletes(string ids)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from SystemLog");
         sb.Append(" where ID in(" + ids + ")");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public SystemLogInfo  Get( int  Id ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from SystemLog where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id",  DbType.Int32,  Id); 

           SystemLogInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = FillList(dataReader);
                }
            }
            return model; 
      }


      public  List<SystemLogInfo>  GetList(  ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from SystemLog order by Id desc");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<SystemLogInfo> list =  new List<SystemLogInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      public  List<SystemLogInfo>  GetPageList( int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount  ) 
      {
         Database db = DBHelper.CreateDataBase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager2005");  
            db.AddInParameter(dbCommand, "tblName", DbType.String, "SystemLog");
             db.AddInParameter(dbCommand, "strGetFields", DbType.String, "*");
            db.AddInParameter(dbCommand, "strOrder", DbType.String, orderBy);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, where.Trim());
            db.AddInParameter(dbCommand, "pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "pageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbCommand, "recordCount", DbType.Int32, 8);
            db.AddInParameter(dbCommand, "doCount", DbType.Boolean, doCount); 
            List<SystemLogInfo> list =  new List<SystemLogInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
     
            recordCount = (int)db.GetParameterValue(dbCommand, "recordCount"); return  list;
      }


      public  List<SystemLogInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         string top = string.Empty;
         if(count>0) top=" top " + count + "";
         if(string.IsNullOrEmpty(fields)) fields="*";
         if(string.IsNullOrEmpty(orderBy)) orderBy=" order by Id desc";
         if(!string.IsNullOrEmpty(where)) where=" where " + where + "";
         sb.Append("select"+top+" "+fields+" from SystemLog"+where+""+orderBy+"");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<SystemLogInfo> list =  new List<SystemLogInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      private SystemLogInfo  FillList(  IDataReader dataReader  )
      { 
            SystemLogInfo model = new SystemLogInfo();
            object ojb;
            ojb = dataReader["Id"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = ( int)(ojb);
            }
            ojb = dataReader["MethodName"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MethodName = ( string)(ojb);
            }
            ojb = dataReader["MethodSignature"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MethodSignature = ( string)(ojb);
            }
            ojb = dataReader["TypeName"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TypeName = ( string)(ojb);
            }
            ojb = dataReader["CallContext"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CallContext = ( string)(ojb);
            }
            ojb = dataReader["SystemName"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SystemName = ( string)(ojb);
            }
            ojb = dataReader["UseTime"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UseTime = ( int)(ojb);
            }
            ojb = dataReader["Args"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Args = ( string)(ojb);
            }
            ojb = dataReader["CreateDate"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = ( DateTime)(ojb);
            }
            ojb = dataReader["CreateIP"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateIP = ( string)(ojb);
            }
            ojb = dataReader["ReturnValue"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ReturnValue = ( string)(ojb);
            }
            ojb = dataReader["LogType"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LogType = ( int)(ojb);
            }

            return model;
        }


        public  bool Create(List<SystemLogInfo> list)
        { 
bool suc = BaseDAL.ExecuteTransactionScopeInsert(this.ToDataTable(list), 250, "SystemLog"); return suc; }



         private    DataTable  ToDataTable(List<SystemLogInfo> list)
        { 
            if (list == null || list.Count <1)
            {
                return null;
            }
            DataTable result = new DataTable();
            if (list.Count > 0)
            {

                string columnNameList = "?Id??MethodName??MethodSignature??TypeName??CallContext??SystemName??UseTime??Args??CreateDate??CreateIP??ReturnValue??LogType?"; 

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
                dr["MethodName"] = list[i].MethodName; 
                dr["MethodSignature"] = list[i].MethodSignature; 
                dr["TypeName"] = list[i].TypeName; 
                dr["CallContext"] = list[i].CallContext; 
                dr["SystemName"] = list[i].SystemName; 
                dr["UseTime"] = list[i].UseTime; 
                dr["Args"] = list[i].Args; 
                dr["CreateDate"] = list[i].CreateDate; 
                dr["CreateIP"] = list[i].CreateIP; 
                dr["ReturnValue"] = list[i].ReturnValue; 
                dr["LogType"] = list[i].LogType; 

                result.Rows.Add(dr );
            }
            #endregion
            result.AcceptChanges(); 
            return result;
        }
    


             
    }


}

