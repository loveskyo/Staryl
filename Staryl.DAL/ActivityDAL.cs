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
             
    public partial class ActivityDAL:BaseDAL, IActivityDAL
    {
        
public int Create(ActivityInfo model)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("insert into Activity(");
         sb.Append("Title,BriefIntroduction,Content,TypeId,ChargeLevel,OrderBy,CreateDate,CreateIP");
         sb.Append(") values(");
         sb.Append("@Title,@BriefIntroduction,@Content,@TypeId,@ChargeLevel,@OrderBy,@CreateDate,@CreateIP);SELECT @@IDENTITY;");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Title", DbType.String, model.Title);
            db.AddInParameter(dbCommand, "@BriefIntroduction", DbType.String, model.BriefIntroduction);
            db.AddInParameter(dbCommand, "@Content", DbType.String, model.Content);
            db.AddInParameter(dbCommand, "@TypeId", DbType.Int32, model.TypeId);
            db.AddInParameter(dbCommand, "@ChargeLevel", DbType.Int32, model.ChargeLevel);
            db.AddInParameter(dbCommand, "@OrderBy", DbType.Int32, model.OrderBy);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
            db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));  
            return id; 
      }


      public bool Update(ActivityInfo model) 
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("update Activity set ");
         sb.Append("Title=@Title,BriefIntroduction=@BriefIntroduction,Content=@Content,TypeId=@TypeId,ChargeLevel=@ChargeLevel,OrderBy=@OrderBy,CreateDate=@CreateDate,CreateIP=@CreateIP");
         sb.Append(" where Id=@Id");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
         db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id);
         db.AddInParameter(dbCommand, "@Title", DbType.String, model.Title);
         db.AddInParameter(dbCommand, "@BriefIntroduction", DbType.String, model.BriefIntroduction);
         db.AddInParameter(dbCommand, "@Content", DbType.String, model.Content);
         db.AddInParameter(dbCommand, "@TypeId", DbType.Int32, model.TypeId);
         db.AddInParameter(dbCommand, "@ChargeLevel", DbType.Int32, model.ChargeLevel);
         db.AddInParameter(dbCommand, "@OrderBy", DbType.Int32, model.OrderBy);
         db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
         db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
         return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public bool Delete(ActivityInfo model)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from Activity");
         sb.Append(" where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id); 
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }
      public bool Deletes(string ids)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from Activity");
         sb.Append(" where ID in(" + ids + ")");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public ActivityInfo  Get( int  Id ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from Activity where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id",  DbType.Int32,  Id); 

           ActivityInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = FillList(dataReader);
                }
            }
            return model; 
      }


      public  List<ActivityInfo>  GetList(  ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from Activity order by Id desc");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<ActivityInfo> list =  new List<ActivityInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      public  List<ActivityInfo>  GetPageList( int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount  ) 
      {
         Database db = DBHelper.CreateDataBase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager2005");  
            db.AddInParameter(dbCommand, "tblName", DbType.String, "Activity");
             db.AddInParameter(dbCommand, "strGetFields", DbType.String, "*");
            db.AddInParameter(dbCommand, "strOrder", DbType.String, orderBy);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, where.Trim());
            db.AddInParameter(dbCommand, "pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "pageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbCommand, "recordCount", DbType.Int32, 8);
            db.AddInParameter(dbCommand, "doCount", DbType.Boolean, doCount); 
            List<ActivityInfo> list =  new List<ActivityInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
     
            recordCount = (int)db.GetParameterValue(dbCommand, "recordCount"); return  list;
      }


      public  List<ActivityInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         string top = string.Empty;
         if(count>0) top=" top " + count + "";
         if(string.IsNullOrEmpty(fields)) fields="*";
         if(string.IsNullOrEmpty(orderBy)) orderBy=" order by Id desc";
         if(!string.IsNullOrEmpty(where)) where=" where " + where + "";
         sb.Append("select"+top+" "+fields+" from Activity"+where+""+orderBy+"");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<ActivityInfo> list =  new List<ActivityInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      private ActivityInfo  FillList(  IDataReader dataReader  )
      { 
            ActivityInfo model = new ActivityInfo();
            object ojb;
            ojb = dataReader["Id"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = ( int)(ojb);
            }
            ojb = dataReader["Title"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Title = ( string)(ojb);
            }
            ojb = dataReader["BriefIntroduction"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.BriefIntroduction = ( string)(ojb);
            }
            ojb = dataReader["Content"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Content = ( string)(ojb);
            }
            ojb = dataReader["TypeId"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TypeId = ( int)(ojb);
            }
            ojb = dataReader["ChargeLevel"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ChargeLevel = ( int)(ojb);
            }
            ojb = dataReader["OrderBy"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderBy = ( int)(ojb);
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

            return model;
        }


        public  bool Create(List<ActivityInfo> list)
        { 
bool suc = BaseDAL.ExecuteTransactionScopeInsert(this.ToDataTable(list), 250, "Activity"); return suc; }



         private    DataTable  ToDataTable(List<ActivityInfo> list)
        { 
            if (list == null || list.Count <1)
            {
                return null;
            }
            DataTable result = new DataTable();
            if (list.Count > 0)
            {

                string columnNameList = "?Id??Title??BriefIntroduction??Content??TypeId??ChargeLevel??OrderBy??CreateDate??CreateIP?"; 

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
                dr["Title"] = list[i].Title; 
                dr["BriefIntroduction"] = list[i].BriefIntroduction; 
                dr["Content"] = list[i].Content; 
                dr["TypeId"] = list[i].TypeId; 
                dr["ChargeLevel"] = list[i].ChargeLevel; 
                dr["OrderBy"] = list[i].OrderBy; 
                dr["CreateDate"] = list[i].CreateDate; 
                dr["CreateIP"] = list[i].CreateIP; 

                result.Rows.Add(dr );
            }
            #endregion
            result.AcceptChanges(); 
            return result;
        }
    


             
    }


}

