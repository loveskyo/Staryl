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
             
    public partial class UserDAL:BaseDAL, IUserDAL
    {
        
public int Create(UserInfo model)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("insert into [User](");
         sb.Append("Email,Mobile,UserType,RecommendUser,RealName,Avatar,CreateDate,CreateIP,IsVIP,Password,Status,IsLogin");
         sb.Append(") values(");
         sb.Append("@Email,@Mobile,@UserType,@RecommendUser,@RealName,@Avatar,@CreateDate,@CreateIP,@IsVIP,@Password,@Status,@IsLogin);SELECT @@IDENTITY;");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Email", DbType.String, model.Email);
            db.AddInParameter(dbCommand, "@Mobile", DbType.String, model.Mobile);
            db.AddInParameter(dbCommand, "@UserType", DbType.Int32, model.UserType);
            db.AddInParameter(dbCommand, "@RecommendUser", DbType.String, model.RecommendUser);
            db.AddInParameter(dbCommand, "@RealName", DbType.String, model.RealName);
            db.AddInParameter(dbCommand, "@Avatar", DbType.String, model.Avatar);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
            db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
            db.AddInParameter(dbCommand, "@IsVIP", DbType.Boolean, model.IsVIP);
            db.AddInParameter(dbCommand, "@Password", DbType.String, model.Password);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, model.Status);
            db.AddInParameter(dbCommand, "@IsLogin", DbType.Boolean, model.IsLogin);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));  
            return id; 
      }


      public bool Update(UserInfo model) 
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("update [User] set ");
         sb.Append("Email=@Email,Mobile=@Mobile,UserType=@UserType,RecommendUser=@RecommendUser,RealName=@RealName,Avatar=@Avatar,CreateDate=@CreateDate,CreateIP=@CreateIP,IsVIP=@IsVIP,Password=@Password,Status=@Status,IsLogin=@IsLogin");
         sb.Append(" where Id=@Id");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
         db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id);
         db.AddInParameter(dbCommand, "@Email", DbType.String, model.Email);
         db.AddInParameter(dbCommand, "@Mobile", DbType.String, model.Mobile);
         db.AddInParameter(dbCommand, "@UserType", DbType.Int32, model.UserType);
         db.AddInParameter(dbCommand, "@RecommendUser", DbType.String, model.RecommendUser);
         db.AddInParameter(dbCommand, "@RealName", DbType.String, model.RealName);
         db.AddInParameter(dbCommand, "@Avatar", DbType.String, model.Avatar);
         db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
         db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
         db.AddInParameter(dbCommand, "@IsVIP", DbType.Boolean, model.IsVIP);
         db.AddInParameter(dbCommand, "@Password", DbType.String, model.Password);
         db.AddInParameter(dbCommand, "@Status", DbType.Int32, model.Status);
         db.AddInParameter(dbCommand, "@IsLogin", DbType.Boolean, model.IsLogin);
         return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public bool Delete(UserInfo model)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from [User]");
         sb.Append(" where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id); 
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }
      public bool Deletes(string ids)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from [User]");
         sb.Append(" where Id in(" + ids + ")");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public UserInfo  Get( int  Id ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from [User] where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id",  DbType.Int32,  Id); 

           UserInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = FillList(dataReader);
                }
            }
            return model; 
      }


      public  List<UserInfo>  GetList(  ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from [User] order by Id desc");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<UserInfo> list =  new List<UserInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      public  List<UserInfo>  GetPageList( int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount  ) 
      {
         Database db = DBHelper.CreateDataBase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager2005");  
            db.AddInParameter(dbCommand, "tblName", DbType.String, "User");
             db.AddInParameter(dbCommand, "strGetFields", DbType.String, "*");
            db.AddInParameter(dbCommand, "strOrder", DbType.String, orderBy);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, where.Trim());
            db.AddInParameter(dbCommand, "pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "pageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbCommand, "recordCount", DbType.Int32, 8);
            db.AddInParameter(dbCommand, "doCount", DbType.Boolean, doCount); 
            List<UserInfo> list =  new List<UserInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
     
            recordCount = (int)db.GetParameterValue(dbCommand, "recordCount"); return  list;
      }


      public  List<UserInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         string top = string.Empty;
         if(count>0) top=" top " + count + "";
         if(string.IsNullOrEmpty(fields)) fields="*";
         if(string.IsNullOrEmpty(orderBy)) orderBy=" order by Id desc";
         if(!string.IsNullOrEmpty(where)) where=" where " + where + "";
         sb.Append("select"+top+" "+fields+" from User"+where+""+orderBy+"");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<UserInfo> list =  new List<UserInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      private UserInfo  FillList(  IDataReader dataReader  )
      { 
            UserInfo model = new UserInfo();
            object ojb;
            ojb = dataReader["Id"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = ( int)(ojb);
            }
            ojb = dataReader["Email"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Email = ( string)(ojb);
            }
            ojb = dataReader["Mobile"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Mobile = ( string)(ojb);
            }
            ojb = dataReader["UserType"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserType = ( int)(ojb);
            }
            ojb = dataReader["RecommendUser"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RecommendUser = ( string)(ojb);
            }
            ojb = dataReader["RealName"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RealName = ( string)(ojb);
            }
            ojb = dataReader["Avatar"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Avatar = ( string)(ojb);
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
            ojb = dataReader["IsVIP"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsVIP = ( bool)(ojb);
            }
            ojb = dataReader["Password"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Password = ( string)(ojb);
            }
            ojb = dataReader["Status"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = ( int)(ojb);
            }
            ojb = dataReader["IsLogin"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsLogin = ( bool)(ojb);
            }

            return model;
        }


        public  bool Create(List<UserInfo> list)
        { 
bool suc = BaseDAL.ExecuteTransactionScopeInsert(this.ToDataTable(list), 250, "User"); return suc; }



         private    DataTable  ToDataTable(List<UserInfo> list)
        { 
            if (list == null || list.Count <1)
            {
                return null;
            }
            DataTable result = new DataTable();
            if (list.Count > 0)
            {

                string columnNameList = "?Id??Email??Mobile??UserType??RecommendUser??RealName??Avatar??CreateDate??CreateIP??IsVIP??Password??Status??IsLogin?"; 

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
                dr["Email"] = list[i].Email; 
                dr["Mobile"] = list[i].Mobile; 
                dr["UserType"] = list[i].UserType; 
                dr["RecommendUser"] = list[i].RecommendUser; 
                dr["RealName"] = list[i].RealName; 
                dr["Avatar"] = list[i].Avatar; 
                dr["CreateDate"] = list[i].CreateDate; 
                dr["CreateIP"] = list[i].CreateIP; 
                dr["IsVIP"] = list[i].IsVIP; 
                dr["Password"] = list[i].Password; 
                dr["Status"] = list[i].Status; 
                dr["IsLogin"] = list[i].IsLogin; 

                result.Rows.Add(dr );
            }
            #endregion
            result.AcceptChanges(); 
            return result;
        }
    



        public UserInfo  GetByEmail(string Email)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from User where Email=@Email");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Email",  DbType.String,  Email); 
            UserInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = FillList(dataReader);
                }
            }
            return model; 
      }



        public UserInfo  GetByMobile(string Mobile)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from User where Mobile=@Mobile");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Mobile",  DbType.String,  Mobile); 
            UserInfo model = null;
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

