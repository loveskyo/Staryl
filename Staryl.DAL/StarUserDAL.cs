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
             
    public partial class StarUserDAL:BaseDAL, IStarUserDAL
    {
        
public int Create(StarUserInfo model)
        {         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("insert into StarUser(");
         sb.Append("Gender,RealName,Birthday,City,Province,Area,Avatar,Height,Weight,Hobby,Greeting,CreateDate,CreateIP,NickName,ParentId,IsRecommend,FansNumber,LikeNumber");
         sb.Append(") values(");
         sb.Append("@Gender,@RealName,@Birthday,@City,@Province,@Area,@Avatar,@Height,@Weight,@Hobby,@Greeting,@CreateDate,@CreateIP,@NickName,@ParentId,@IsRecommend,@FansNumber,@LikeNumber);SELECT @@IDENTITY;");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Gender", DbType.Int32, model.Gender);
            db.AddInParameter(dbCommand, "@RealName", DbType.String, model.RealName);
            db.AddInParameter(dbCommand, "@Birthday", DbType.DateTime, model.Birthday);
            db.AddInParameter(dbCommand, "@City", DbType.Int32, model.City);
            db.AddInParameter(dbCommand, "@Province", DbType.Int32, model.Province);
            db.AddInParameter(dbCommand, "@Area", DbType.Int32, model.Area);
            db.AddInParameter(dbCommand, "@Avatar", DbType.String, model.Avatar);
            db.AddInParameter(dbCommand, "@Height", DbType.Int32, model.Height);
            db.AddInParameter(dbCommand, "@Weight", DbType.Int32, model.Weight);
            db.AddInParameter(dbCommand, "@Hobby", DbType.String, model.Hobby);
            db.AddInParameter(dbCommand, "@Greeting", DbType.String, model.Greeting);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
            db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
            db.AddInParameter(dbCommand, "@NickName", DbType.String, model.NickName);
            db.AddInParameter(dbCommand, "@ParentId", DbType.Int32, model.ParentId);
            db.AddInParameter(dbCommand, "@IsRecommend", DbType.Boolean, model.IsRecommend);
            db.AddInParameter(dbCommand, "@FansNumber", DbType.Int32, model.FansNumber);
            db.AddInParameter(dbCommand, "@LikeNumber", DbType.Int32, model.LikeNumber);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));  
            return id; 
      }


      public bool Update(StarUserInfo model) 
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("update StarUser set ");
         sb.Append("Gender=@Gender,RealName=@RealName,Birthday=@Birthday,City=@City,Province=@Province,Area=@Area,Avatar=@Avatar,Height=@Height,Weight=@Weight,Hobby=@Hobby,Greeting=@Greeting,CreateDate=@CreateDate,CreateIP=@CreateIP,NickName=@NickName,ParentId=@ParentId,IsRecommend=@IsRecommend,FansNumber=@FansNumber,LikeNumber=@LikeNumber");
         sb.Append(" where Id=@Id");
         DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
         db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id);
         db.AddInParameter(dbCommand, "@Gender", DbType.Int32, model.Gender);
         db.AddInParameter(dbCommand, "@RealName", DbType.String, model.RealName);
         db.AddInParameter(dbCommand, "@Birthday", DbType.DateTime, model.Birthday);
         db.AddInParameter(dbCommand, "@City", DbType.Int32, model.City);
         db.AddInParameter(dbCommand, "@Province", DbType.Int32, model.Province);
         db.AddInParameter(dbCommand, "@Area", DbType.Int32, model.Area);
         db.AddInParameter(dbCommand, "@Avatar", DbType.String, model.Avatar);
         db.AddInParameter(dbCommand, "@Height", DbType.Int32, model.Height);
         db.AddInParameter(dbCommand, "@Weight", DbType.Int32, model.Weight);
         db.AddInParameter(dbCommand, "@Hobby", DbType.String, model.Hobby);
         db.AddInParameter(dbCommand, "@Greeting", DbType.String, model.Greeting);
         db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, model.CreateDate);
         db.AddInParameter(dbCommand, "@CreateIP", DbType.String, model.CreateIP);
         db.AddInParameter(dbCommand, "@NickName", DbType.String, model.NickName);
         db.AddInParameter(dbCommand, "@ParentId", DbType.Int32, model.ParentId);
         db.AddInParameter(dbCommand, "@IsRecommend", DbType.Boolean, model.IsRecommend);
         db.AddInParameter(dbCommand, "@FansNumber", DbType.Int32, model.FansNumber);
         db.AddInParameter(dbCommand, "@LikeNumber", DbType.Int32, model.LikeNumber);
         return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public bool Delete(StarUserInfo model)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from StarUser");
         sb.Append(" where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id", DbType.Int32, model.Id); 
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }
      public bool Deletes(string ids)
      { 
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("delete from StarUser");
         sb.Append(" where ID in(" + ids + ")");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            return db.ExecuteNonQuery(dbCommand) < 1 ? false : true; 
      }

      public StarUserInfo  Get( int  Id ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from StarUser where Id=@Id");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@Id",  DbType.Int32,  Id); 

           StarUserInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = FillList(dataReader);
                }
            }
            return model; 
      }


      public  List<StarUserInfo>  GetList(  ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from StarUser order by Id desc");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<StarUserInfo> list =  new List<StarUserInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      public  List<StarUserInfo>  GetPageList( int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount  ) 
      {
         Database db = DBHelper.CreateDataBase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager2005");  
            db.AddInParameter(dbCommand, "tblName", DbType.String, "StarUser");
             db.AddInParameter(dbCommand, "strGetFields", DbType.String, "*");
            db.AddInParameter(dbCommand, "strOrder", DbType.String, orderBy);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, where.Trim());
            db.AddInParameter(dbCommand, "pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "pageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbCommand, "recordCount", DbType.Int32, 8);
            db.AddInParameter(dbCommand, "doCount", DbType.Boolean, doCount); 
            List<StarUserInfo> list =  new List<StarUserInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
     
            recordCount = (int)db.GetParameterValue(dbCommand, "recordCount"); return  list;
      }


      public  List<StarUserInfo>  GetListByWhere(int count, string where=null, string fields=null, string orderBy = null ) 
      {
         Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         string top = string.Empty;
         if(count>0) top=" top " + count + "";
         if(string.IsNullOrEmpty(fields)) fields="*";
         if(string.IsNullOrEmpty(orderBy)) orderBy=" order by Id desc";
         if(!string.IsNullOrEmpty(where)) where=" where " + where + "";
         sb.Append("select"+top+" "+fields+" from StarUser"+where+""+orderBy+"");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            List<StarUserInfo> list =  new List<StarUserInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add( FillList(dataReader) );
                }
            }
            return  list;
      }


      private StarUserInfo  FillList(  IDataReader dataReader  )
      { 
            StarUserInfo model = new StarUserInfo();
            object ojb;
            ojb = dataReader["Id"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = ( int)(ojb);
            }
            ojb = dataReader["Gender"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Gender = ( int)(ojb);
            }
            ojb = dataReader["RealName"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RealName = ( string)(ojb);
            }
            ojb = dataReader["Birthday"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Birthday = ( DateTime)(ojb);
            }
            ojb = dataReader["City"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.City = ( int)(ojb);
            }
            ojb = dataReader["Province"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Province = ( int)(ojb);
            }
            ojb = dataReader["Area"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Area = ( int)(ojb);
            }
            ojb = dataReader["Avatar"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Avatar = ( string)(ojb);
            }
            ojb = dataReader["Height"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Height = ( int)(ojb);
            }
            ojb = dataReader["Weight"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Weight = ( int)(ojb);
            }
            ojb = dataReader["Hobby"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Hobby = ( string)(ojb);
            }
            ojb = dataReader["Greeting"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Greeting = ( string)(ojb);
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
            ojb = dataReader["NickName"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.NickName = ( string)(ojb);
            }
            ojb = dataReader["ParentId"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ParentId = ( int)(ojb);
            }
            ojb = dataReader["IsRecommend"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsRecommend = ( bool)(ojb);
            }
            ojb = dataReader["FansNumber"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.FansNumber = ( int)(ojb);
            }
            ojb = dataReader["LikeNumber"]; 
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LikeNumber = ( int)(ojb);
            }

            return model;
        }


        public  bool Create(List<StarUserInfo> list)
        { 
bool suc = BaseDAL.ExecuteTransactionScopeInsert(this.ToDataTable(list), 250, "StarUser"); return suc; }



         private    DataTable  ToDataTable(List<StarUserInfo> list)
        { 
            if (list == null || list.Count <1)
            {
                return null;
            }
            DataTable result = new DataTable();
            if (list.Count > 0)
            {

                string columnNameList = "?Id??Gender??RealName??Birthday??City??Province??Area??Avatar??Height??Weight??Hobby??Greeting??CreateDate??CreateIP??NickName??ParentId??IsRecommend??FansNumber??LikeNumber?"; 

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
                dr["Gender"] = list[i].Gender; 
                dr["RealName"] = list[i].RealName; 
                dr["Birthday"] = list[i].Birthday; 
                dr["City"] = list[i].City; 
                dr["Province"] = list[i].Province; 
                dr["Area"] = list[i].Area; 
                dr["Avatar"] = list[i].Avatar; 

                if( ! list[i].Height.HasValue ) 
                    dr["Height"] =  DBNull.Value; 
                 else 
                    dr["Height"] = list[i].Height; 

                if( ! list[i].Weight.HasValue ) 
                    dr["Weight"] =  DBNull.Value; 
                 else 
                    dr["Weight"] = list[i].Weight; 
                dr["Hobby"] = list[i].Hobby; 
                dr["Greeting"] = list[i].Greeting; 
                dr["CreateDate"] = list[i].CreateDate; 
                dr["CreateIP"] = list[i].CreateIP; 
                dr["NickName"] = list[i].NickName; 
                dr["ParentId"] = list[i].ParentId; 
                dr["IsRecommend"] = list[i].IsRecommend; 
                dr["FansNumber"] = list[i].FansNumber; 
                dr["LikeNumber"] = list[i].LikeNumber; 

                result.Rows.Add(dr );
            }
            #endregion
            result.AcceptChanges(); 
            return result;
        }
    



public List<StarUserInfo>  GetByParentId( int  ParentId )
        {          Database db = DBHelper.CreateDataBase();
         StringBuilder sb = new StringBuilder();
         sb.Append("select * from StarUser where ParentId=@ParentId");
            DbCommand dbCommand = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(dbCommand, "@ParentId",  DbType.Int32,  ParentId); 

            List<StarUserInfo>   list =  new List<StarUserInfo> ();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                     list.Add( FillList(dataReader));
                }
            }
            return  list;
        }

             
    }


}

