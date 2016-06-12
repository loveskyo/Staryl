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
             
    public partial class TicketDAL:BaseDAL, ITicketDAL
    {
        
public int Create(TicketInfo model)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("insert into Ticket(");
         sb.Append("TicketNo,UserId,StarDate,EndDate,CreateDate,CreateIP,Creator,TicketValue,TicketType,Status");
         sb.Append(") values(");
         sb.Append("@TicketNo,@UserId,@StarDate,@EndDate,@CreateDate,@CreateIP,@Creator,@TicketValue,@TicketType,@Status);SELECT @@IDENTITY;");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@TicketNo", DbType.String, model.TicketNo);
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, model.UserId);
            db.AddInParameter(dbCommand, "@StarDate", DbType.DateTime, model.StarDate);
            db.AddInParameter(dbCommand, "@EndDate", DbType.DateTime, model.EndDate);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
            db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
            db.AddInParameter(dbCommand, "@Creator", DbType.Int32, model.Creator);
            db.AddInParameter(dbCommand, "@TicketValue", DbType.Int32, model.TicketValue);
            db.AddInParameter(dbCommand, "@TicketType", DbType.Int32, model.TicketType);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, model.Status);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));  
            return id; 
      }


      public bool Update(TicketInfo model) 
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("update Ticket set ");
         sb.Append("TicketNo=@TicketNo,UserId=@UserId,StarDate=@StarDate,EndDate=@EndDate,CreateDate=@CreateDate,CreateIP=@CreateIP,Creator=@Creator,TicketValue=@TicketValue,TicketType=@TicketType,Status=@Status");
         sb.Append(" where Id=@Id");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
         db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id);
         db.AddInParameter(dbCommand, "@TicketNo", DbType.String, model.TicketNo);
         db.AddInParameter(dbCommand, "@UserId", DbType.Int32, model.UserId);
         db.AddInParameter(dbCommand, "@StarDate", DbType.DateTime, model.StarDate);
         db.AddInParameter(dbCommand, "@EndDate", DbType.DateTime, model.EndDate);
         db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
         db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
         db.AddInParameter(dbCommand, "@Creator", DbType.Int32, model.Creator);
         db.AddInParameter(dbCommand, "@TicketValue", DbType.Int32, model.TicketValue);
         db.AddInParameter(dbCommand, "@TicketType", DbType.Int32, model.TicketType);
         db.AddInParameter(dbCommand, "@Status", DbType.Int32, model.Status);
         return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public bool Delete(TicketInfo model)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from Ticket");
         sb.Append(" where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id); 
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }
      public bool Deletes(string ids)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from Ticket");
         sb.Append(" where ID in(" + ids + ")");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public TicketInfo  Get( int  Id ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from Ticket where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id",  DbType.Int32,  Id); 

           TicketInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = FillList(dataReader);
                }
            }
            return model; 
      }


      public  List<TicketInfo>  GetList(  ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from Ticket order by Id desc");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<TicketInfo> list =  new List<TicketInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      public  List<TicketInfo>  GetPageList( int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount  ) 
      {
         Database db = DBHelper.CreateDataBase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager2005");  
            db.AddInParameter(dbCommand, "tblName", DbType.String, "Ticket");
             db.AddInParameter(dbCommand, "strGetFields", DbType.String, "*");
            db.AddInParameter(dbCommand, "strOrder", DbType.String, orderBy);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, where.Trim());
            db.AddInParameter(dbCommand, "pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "pageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbCommand, "recordCount", DbType.Int32, 8);
            db.AddInParameter(dbCommand, "doCount", DbType.Boolean, doCount); 
            List<TicketInfo> list =  new List<TicketInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
     
            recordCount = (int)db.GetParameterValue(dbCommand, "recordCount"); return  list;
      }


      public  List<TicketInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         string top = string.Empty;
         if(count>0) top=" top " + count + "";
         if(string.IsNullOrEmpty(fields)) fields="*";
         if(string.IsNullOrEmpty(orderBy)) orderBy=" order by Id desc";
         if(!string.IsNullOrEmpty(where)) where=" where " + where + "";
         sb.Append("select"+top+" "+fields+" from Ticket"+where+""+orderBy+"");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<TicketInfo> list =  new List<TicketInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      private TicketInfo  FillList(  IDataReader dataReader  )
      { 
            TicketInfo model = new TicketInfo();
            object ojb;
            ojb = dataReader["Id"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = ( int)(ojb);
            }
            ojb = dataReader["TicketNo"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TicketNo = ( string)(ojb);
            }
            ojb = dataReader["UserId"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserId = ( int)(ojb);
            }
            ojb = dataReader["StarDate"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.StarDate = ( DateTime)(ojb);
            }
            ojb = dataReader["EndDate"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EndDate = ( DateTime)(ojb);
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
            ojb = dataReader["Creator"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Creator = ( int)(ojb);
            }
            ojb = dataReader["TicketValue"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TicketValue = ( int)(ojb);
            }
            ojb = dataReader["TicketType"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TicketType = ( int)(ojb);
            }
            ojb = dataReader["Status"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = ( int)(ojb);
            }

            return model;
        }


        public  bool Create(List<TicketInfo> list)
        { 
bool suc = BaseDAL.ExecuteTransactionScopeInsert(this.ToDataTable(list), 250, "Ticket"); return suc; }



         private    DataTable  ToDataTable(List<TicketInfo> list)
        { 
            if (list == null || list.Count <1)
            {
                return null;
            }
            DataTable result = new DataTable();
            if (list.Count > 0)
            {

                string columnNameList = "?Id??TicketNo??UserId??StarDate??EndDate??CreateDate??CreateIP??Creator??TicketValue??TicketType??Status?"; 

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
                dr["TicketNo"] = list[i].TicketNo; 
                dr["UserId"] = list[i].UserId; 
                dr["StarDate"] = list[i].StarDate; 
                dr["EndDate"] = list[i].EndDate; 
                dr["CreateDate"] = list[i].CreateDate; 
                dr["CreateIP"] = list[i].CreateIP; 
                dr["Creator"] = list[i].Creator; 
                dr["TicketValue"] = list[i].TicketValue; 
                dr["TicketType"] = list[i].TicketType; 
                dr["Status"] = list[i].Status; 

                result.Rows.Add(dr );
            }
            #endregion
            result.AcceptChanges(); 
            return result;
        }
    



        public TicketInfo  GetByTicketNo(string TicketNo)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from Ticket where TicketNo=@TicketNo");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@TicketNo",  DbType.String,  TicketNo); 
            TicketInfo model = null;
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

