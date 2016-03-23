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
             
    public partial class ActivityApplyDAL:BaseDAL, IActivityApplyDAL
    {
        
public int Create(ActivityApplyInfo model)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("insert into ActivityApply(");
         sb.Append("ActivityId,UserId,StarId,Status,CreateDate,CreateIP");
         sb.Append(") values(");
         sb.Append("@ActivityId,@UserId,@StarId,@Status,@CreateDate,@CreateIP);SELECT @@IDENTITY;");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@ActivityId", DbType.Int32, model.ActivityId);
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, model.UserId);
            db.AddInParameter(dbCommand, "@StarId", DbType.Int32, model.StarId);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, model.Status);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
            db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));  
            return id; 
      }


      public bool Update(ActivityApplyInfo model) 
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("update ActivityApply set ");
         sb.Append("ActivityId=@ActivityId,UserId=@UserId,StarId=@StarId,Status=@Status,CreateDate=@CreateDate,CreateIP=@CreateIP");
         sb.Append(" where Id=@Id");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
         db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id);
         db.AddInParameter(dbCommand, "@ActivityId", DbType.Int32, model.ActivityId);
         db.AddInParameter(dbCommand, "@UserId", DbType.Int32, model.UserId);
         db.AddInParameter(dbCommand, "@StarId", DbType.Int32, model.StarId);
         db.AddInParameter(dbCommand, "@Status", DbType.Int32, model.Status);
         db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
         db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
         return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public bool Delete(ActivityApplyInfo model)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from ActivityApply");
         sb.Append(" where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id); 
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }
      public bool Deletes(string ids)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from ActivityApply");
         sb.Append(" where ID in(" + ids + ")");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public ActivityApplyInfo  Get( int  Id ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from ActivityApply where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id",  DbType.Int32,  Id); 

           ActivityApplyInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = FillList(dataReader);
                }
            }
            return model; 
      }


      public  List<ActivityApplyInfo>  GetList(  ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from ActivityApply order by Id desc");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<ActivityApplyInfo> list =  new List<ActivityApplyInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      public  List<ActivityApplyInfo>  GetPageList( int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount  ) 
      {
         Database db = DBHelper.CreateDataBase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager2005");  
            db.AddInParameter(dbCommand, "tblName", DbType.String, "ActivityApply");
             db.AddInParameter(dbCommand, "strGetFields", DbType.String, "*");
            db.AddInParameter(dbCommand, "strOrder", DbType.String, orderBy);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, where.Trim());
            db.AddInParameter(dbCommand, "pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "pageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbCommand, "recordCount", DbType.Int32, 8);
            db.AddInParameter(dbCommand, "doCount", DbType.Boolean, doCount); 
            List<ActivityApplyInfo> list =  new List<ActivityApplyInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
     
            recordCount = (int)db.GetParameterValue(dbCommand, "recordCount"); return  list;
      }


      public  List<ActivityApplyInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         string top = string.Empty;
         if(count>0) top=" top " + count + "";
         if(string.IsNullOrEmpty(fields)) fields="*";
         if(string.IsNullOrEmpty(orderBy)) orderBy=" order by Id desc";
         if(!string.IsNullOrEmpty(where)) where=" where " + where + "";
         sb.Append("select"+top+" "+fields+" from ActivityApply"+where+""+orderBy+"");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<ActivityApplyInfo> list =  new List<ActivityApplyInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      private ActivityApplyInfo  FillList(  IDataReader dataReader  )
      { 
            ActivityApplyInfo model = new ActivityApplyInfo();
            object ojb;
            ojb = dataReader["Id"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = ( int)(ojb);
            }
            ojb = dataReader["ActivityId"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ActivityId = ( int)(ojb);
            }
            ojb = dataReader["UserId"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserId = ( int)(ojb);
            }
            ojb = dataReader["StarId"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.StarId = ( int)(ojb);
            }
            ojb = dataReader["Status"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = ( int)(ojb);
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


        public  bool Create(List<ActivityApplyInfo> list)
        { 
bool suc = BaseDAL.ExecuteTransactionScopeInsert(this.ToDataTable(list), 250, "ActivityApply"); return suc; }



         private    DataTable  ToDataTable(List<ActivityApplyInfo> list)
        { 
            if (list == null || list.Count <1)
            {
                return null;
            }
            DataTable result = new DataTable();
            if (list.Count > 0)
            {

                string columnNameList = "?Id??ActivityId??UserId??StarId??Status??CreateDate??CreateIP?"; 

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
                dr["ActivityId"] = list[i].ActivityId; 
                dr["UserId"] = list[i].UserId; 
                dr["StarId"] = list[i].StarId; 
                dr["Status"] = list[i].Status; 
                dr["CreateDate"] = list[i].CreateDate; 
                dr["CreateIP"] = list[i].CreateIP; 

                result.Rows.Add(dr );
            }
            #endregion
            result.AcceptChanges(); 
            return result;
        }
    



        public ActivityApplyInfo  GetByActivityId_StarId(int ActivityId,int StarId)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from ActivityApply where ActivityId=@ActivityId and StarId=@StarId");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@ActivityId",  DbType.Int32,  ActivityId); 
            db.AddInParameter(dbCommand, "@StarId",  DbType.Int32,  StarId); 
            ActivityApplyInfo model = null;
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

