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
             
    public partial class PhotoDAL:BaseDAL, IPhotoDAL
    {
        
public int Create(PhotoInfo model)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("insert into Photo(");
         sb.Append("PhotoImage,AlbumId,UserId,CreateDate,CreateIP,IsDefault");
         sb.Append(") values(");
         sb.Append("@PhotoImage,@AlbumId,@UserId,@CreateDate,@CreateIP,@IsDefault);SELECT @@IDENTITY;");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@PhotoImage", DbType.String, model.PhotoImage);
            db.AddInParameter(dbCommand, "@AlbumId", DbType.Int32, model.AlbumId);
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, model.UserId);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
            db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
            db.AddInParameter(dbCommand, "@IsDefault", DbType.Boolean, model.IsDefault);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));  
            return id; 
      }


      public bool Update(PhotoInfo model) 
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("update Photo set ");
         sb.Append("PhotoImage=@PhotoImage,AlbumId=@AlbumId,UserId=@UserId,CreateDate=@CreateDate,CreateIP=@CreateIP,IsDefault=@IsDefault");
         sb.Append(" where Id=@Id");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
         db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id);
         db.AddInParameter(dbCommand, "@PhotoImage", DbType.String, model.PhotoImage);
         db.AddInParameter(dbCommand, "@AlbumId", DbType.Int32, model.AlbumId);
         db.AddInParameter(dbCommand, "@UserId", DbType.Int32, model.UserId);
         db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
         db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
         db.AddInParameter(dbCommand, "@IsDefault", DbType.Boolean, model.IsDefault);
         return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public bool Delete(PhotoInfo model)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from Photo");
         sb.Append(" where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id); 
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }
      public bool Deletes(string ids)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from Photo");
         sb.Append(" where ID in(" + ids + ")");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public PhotoInfo  Get( int  Id ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from Photo where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id",  DbType.Int32,  Id); 

           PhotoInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = FillList(dataReader);
                }
            }
            return model; 
      }


      public  List<PhotoInfo>  GetList(  ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from Photo order by Id desc");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<PhotoInfo> list =  new List<PhotoInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      public  List<PhotoInfo>  GetPageList( int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount  ) 
      {
         Database db = DBHelper.CreateDataBase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager2005");  
            db.AddInParameter(dbCommand, "tblName", DbType.String, "Photo");
             db.AddInParameter(dbCommand, "strGetFields", DbType.String, "*");
            db.AddInParameter(dbCommand, "strOrder", DbType.String, orderBy);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, where.Trim());
            db.AddInParameter(dbCommand, "pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "pageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbCommand, "recordCount", DbType.Int32, 8);
            db.AddInParameter(dbCommand, "doCount", DbType.Boolean, doCount); 
            List<PhotoInfo> list =  new List<PhotoInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
     
            recordCount = (int)db.GetParameterValue(dbCommand, "recordCount"); return  list;
      }


      public  List<PhotoInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         string top = string.Empty;
         if(count>0) top=" top " + count + "";
         if(string.IsNullOrEmpty(fields)) fields="*";
         if(string.IsNullOrEmpty(orderBy)) orderBy=" order by Id desc";
         if(!string.IsNullOrEmpty(where)) where=" where " + where + "";
         sb.Append("select"+top+" "+fields+" from Photo"+where+""+orderBy+"");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<PhotoInfo> list =  new List<PhotoInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      private PhotoInfo  FillList(  IDataReader dataReader  )
      { 
            PhotoInfo model = new PhotoInfo();
            object ojb;
            ojb = dataReader["Id"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = ( int)(ojb);
            }
            ojb = dataReader["PhotoImage"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PhotoImage = ( string)(ojb);
            }
            ojb = dataReader["AlbumId"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AlbumId = ( int)(ojb);
            }
            ojb = dataReader["UserId"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserId = ( int)(ojb);
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
            ojb = dataReader["IsDefault"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsDefault = ( bool)(ojb);
            }

            return model;
        }


        public  bool Create(List<PhotoInfo> list)
        { 
bool suc = BaseDAL.ExecuteTransactionScopeInsert(this.ToDataTable(list), 250, "Photo"); return suc; }



         private    DataTable  ToDataTable(List<PhotoInfo> list)
        { 
            if (list == null || list.Count <1)
            {
                return null;
            }
            DataTable result = new DataTable();
            if (list.Count > 0)
            {

                string columnNameList = "?Id??PhotoImage??AlbumId??UserId??CreateDate??CreateIP??IsDefault?"; 

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
                dr["PhotoImage"] = list[i].PhotoImage; 
                dr["AlbumId"] = list[i].AlbumId; 
                dr["UserId"] = list[i].UserId; 
                dr["CreateDate"] = list[i].CreateDate; 
                dr["CreateIP"] = list[i].CreateIP; 
                dr["IsDefault"] = list[i].IsDefault; 

                result.Rows.Add(dr );
            }
            #endregion
            result.AcceptChanges(); 
            return result;
        }
    


             
    }


}

