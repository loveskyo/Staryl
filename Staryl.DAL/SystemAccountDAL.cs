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
             
    public partial class SystemAccountDAL:BaseDAL, ISystemAccountDAL
    {
        
public int Create(SystemAccountInfo model)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("insert into SystemAccount(");
         sb.Append("Account,Password,UserName,NickName,RoleId,Department,IsEnable,IsCanDelete,CreateIP,CreateDate,Remarks");
         sb.Append(") values(");
         sb.Append("@Account,@Password,@UserName,@NickName,@RoleId,@Department,@IsEnable,@IsCanDelete,@CreateIP,@CreateDate,@Remarks);SELECT @@IDENTITY;");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Account", DbType.String, model.Account);
            db.AddInParameter(dbCommand, "@Password", DbType.String, model.Password);
            db.AddInParameter(dbCommand, "@UserName", DbType.String, model.UserName);
            db.AddInParameter(dbCommand, "@NickName", DbType.String, model.NickName);
            db.AddInParameter(dbCommand, "@RoleId", DbType.Int32, model.RoleId);
            db.AddInParameter(dbCommand, "@Department", DbType.Int32, model.Department);
            db.AddInParameter(dbCommand, "@IsEnable", DbType.Boolean, model.IsEnable);
            db.AddInParameter(dbCommand, "@IsCanDelete", DbType.Boolean, model.IsCanDelete);
            db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
            db.AddInParameter(dbCommand, "@Remarks", DbType.String, model.Remarks);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));  
            return id; 
      }


      public bool Update(SystemAccountInfo model) 
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("update SystemAccount set ");
         sb.Append("Account=@Account,Password=@Password,UserName=@UserName,NickName=@NickName,RoleId=@RoleId,Department=@Department,IsEnable=@IsEnable,IsCanDelete=@IsCanDelete,CreateIP=@CreateIP,CreateDate=@CreateDate,Remarks=@Remarks");
         sb.Append(" where Id=@Id");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
         db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id);
         db.AddInParameter(dbCommand, "@Account", DbType.String, model.Account);
         db.AddInParameter(dbCommand, "@Password", DbType.String, model.Password);
         db.AddInParameter(dbCommand, "@UserName", DbType.String, model.UserName);
         db.AddInParameter(dbCommand, "@NickName", DbType.String, model.NickName);
         db.AddInParameter(dbCommand, "@RoleId", DbType.Int32, model.RoleId);
         db.AddInParameter(dbCommand, "@Department", DbType.Int32, model.Department);
         db.AddInParameter(dbCommand, "@IsEnable", DbType.Boolean, model.IsEnable);
         db.AddInParameter(dbCommand, "@IsCanDelete", DbType.Boolean, model.IsCanDelete);
         db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
         db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
         db.AddInParameter(dbCommand, "@Remarks", DbType.String, model.Remarks);
         return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public bool Delete(SystemAccountInfo model)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from SystemAccount");
         sb.Append(" where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id); 
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }
      public bool Deletes(string ids)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from SystemAccount");
         sb.Append(" where ID in(" + ids + ")");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public SystemAccountInfo  Get( int  Id ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from SystemAccount where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id",  DbType.Int32,  Id); 

           SystemAccountInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = FillList(dataReader);
                }
            }
            return model; 
      }


      public  List<SystemAccountInfo>  GetList(  ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from SystemAccount order by Id desc");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<SystemAccountInfo> list =  new List<SystemAccountInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      public  List<SystemAccountInfo>  GetPageList( int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount  ) 
      {
         Database db = DBHelper.CreateDataBase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager2005");  
            db.AddInParameter(dbCommand, "tblName", DbType.String, "SystemAccount");
             db.AddInParameter(dbCommand, "strGetFields", DbType.String, "*");
            db.AddInParameter(dbCommand, "strOrder", DbType.String, orderBy);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, where.Trim());
            db.AddInParameter(dbCommand, "pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "pageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbCommand, "recordCount", DbType.Int32, 8);
            db.AddInParameter(dbCommand, "doCount", DbType.Boolean, doCount); 
            List<SystemAccountInfo> list =  new List<SystemAccountInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
     
            recordCount = (int)db.GetParameterValue(dbCommand, "recordCount"); return  list;
      }


      public  List<SystemAccountInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         string top = string.Empty;
         if(count>0) top=" top " + count + "";
         if(string.IsNullOrEmpty(fields)) fields="*";
         if(string.IsNullOrEmpty(orderBy)) orderBy=" order by Id desc";
         if(!string.IsNullOrEmpty(where)) where=" where " + where + "";
         sb.Append("select"+top+" "+fields+" from SystemAccount"+where+""+orderBy+"");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<SystemAccountInfo> list =  new List<SystemAccountInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      private SystemAccountInfo  FillList(  IDataReader dataReader  )
      { 
            SystemAccountInfo model = new SystemAccountInfo();
            object ojb;
            ojb = dataReader["Id"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = ( int)(ojb);
            }
            ojb = dataReader["Account"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Account = ( string)(ojb);
            }
            ojb = dataReader["Password"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Password = ( string)(ojb);
            }
            ojb = dataReader["UserName"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserName = ( string)(ojb);
            }
            ojb = dataReader["NickName"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.NickName = ( string)(ojb);
            }
            ojb = dataReader["RoleId"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RoleId = ( int)(ojb);
            }
            ojb = dataReader["Department"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Department = ( int)(ojb);
            }
            ojb = dataReader["IsEnable"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsEnable = ( bool)(ojb);
            }
            ojb = dataReader["IsCanDelete"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsCanDelete = ( bool)(ojb);
            }
            ojb = dataReader["CreateIP"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateIP = ( string)(ojb);
            }
            ojb = dataReader["CreateDate"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = ( DateTime)(ojb);
            }
            ojb = dataReader["Remarks"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Remarks = ( string)(ojb);
            }

            return model;
        }


        public  bool Create(List<SystemAccountInfo> list)
        { 
bool suc = BaseDAL.ExecuteTransactionScopeInsert(this.ToDataTable(list), 250, "SystemAccount"); return suc; }



         private    DataTable  ToDataTable(List<SystemAccountInfo> list)
        { 
            if (list == null || list.Count <1)
            {
                return null;
            }
            DataTable result = new DataTable();
            if (list.Count > 0)
            {

                string columnNameList = "?Id??Account??Password??UserName??NickName??RoleId??Department??IsEnable??IsCanDelete??CreateIP??CreateDate??Remarks?"; 

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
                dr["Account"] = list[i].Account; 
                dr["Password"] = list[i].Password; 
                dr["UserName"] = list[i].UserName; 
                dr["NickName"] = list[i].NickName; 
                dr["RoleId"] = list[i].RoleId; 
                dr["Department"] = list[i].Department; 
                dr["IsEnable"] = list[i].IsEnable; 
                dr["IsCanDelete"] = list[i].IsCanDelete; 
                dr["CreateIP"] = list[i].CreateIP; 
                dr["CreateDate"] = list[i].CreateDate; 
                dr["Remarks"] = list[i].Remarks; 

                result.Rows.Add(dr );
            }
            #endregion
            result.AcceptChanges(); 
            return result;
        }
    


             
    }


}

