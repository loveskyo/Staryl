using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Transactions;
using System.Collections.Generic;
using System.Configuration;


namespace Staryl.DAL
{
    public class BaseDAL
    {
        #region 短信接口
        /// <summary>
        /// 短信接口账号
        /// </summary>
        public string SMSAccount
        {
            get
            {
                return ConfigurationManager.AppSettings["SMSAccount"].ToString();
            }
        }
        /// <summary>
        /// 短信接口密码
        /// </summary>
        public string SMSPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["SMSPassword"].ToString();
            }
        }
        /// <summary>
        /// 短信接口url
        /// </summary>
        public string SMSUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["SMSUrl"].ToString();
            }
        }
        #endregion


        /// <summary>
        /// 将集合类转换成DataTable
        /// </summary>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public static DataTable ToDataTable(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    var colType = pi.PropertyType;
                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }
                    result.Columns.Add(new DataColumn(pi.Name, colType));
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null) ?? DBNull.Value;
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }




        protected int StepNum = 500;

        protected static Database GetDataBaseConnection()
        {
            //Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("E_Shop");  

            ////
            Database db = DatabaseFactory.CreateDatabase();//();
            return db;
        }


        private static string ConnectionString_ = "";

        protected static string ConnectionString
        {
            get
            {
                if (ConnectionString_.Length < 2)
                {
                    ConnectionString_ = BaseDAL.GetDataBaseConnection().ConnectionString;
                }
                return ConnectionString_;
            }
        }


        #region 使用SqlBulkCopy
        public static bool ExecuteTransactionScopeInsert(DataTable dt, int batchSize, string tableName)
        {
            string connectionString = BaseDAL.ConnectionString;
            int count = dt.Rows.Count;
            // string tableName = "TestTable";
            int copyTimeout = 600;
            bool flag = false;

            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        cn.Open();
                        using (SqlBulkCopy sbc = new SqlBulkCopy(cn))
                        {
                            //服务器上目标表的名称   
                            sbc.DestinationTableName = tableName;
                            sbc.BatchSize = batchSize;
                            sbc.BulkCopyTimeout = copyTimeout;
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                //列映射定义数据源中的列和目标表中的列之间的关系   
                                sbc.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                            }
                            sbc.WriteToServer(dt);
                            flag = true;
                            scope.Complete();//有效的事务   
                        }
                    }
                }
            }
            return flag;
        }
        #endregion

        public long GetNumsRecords(DataSet numsDs)
        {
            if (
                (numsDs == null) || (numsDs.Tables == null)
                  || (numsDs.Tables.Count < 1) || (numsDs.Tables[0].Rows == null)
                    || (numsDs.Tables[0].Rows.Count < 1) || (numsDs.Tables[0].Rows[0][0].ToString().Trim().Length < 1)
              )
            {
                return -(33423);
            }
            else
            {
                return long.Parse(numsDs.Tables[0].Rows[0][0].ToString());
            }
        }

    }


    /// <summary>
    /// 模型对象组装类
    /// </summary>
    public class Fabricate
    {
        /// <summary>
        /// 判断某列是否存在并且有无数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static bool ReaderExists(System.Collections.Hashtable table, IDataReader reader, string columnName)
        {
            if (table.Contains(columnName.ToLower()) && !Convert.IsDBNull(reader[columnName]))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 组装一个模型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static T Fill<T>(IDataReader reader, System.Collections.Hashtable table)
        {
            T t = System.Activator.CreateInstance<T>();

            if (table == null || table.Count == 0)
            {
                table = FillTable(reader);
            }

            System.Reflection.PropertyInfo[] propertys = typeof(T).GetProperties();

            foreach (System.Reflection.PropertyInfo item in propertys)
            {
                if (ReaderExists(table, reader, item.Name))
                {
                    try
                    {
                        item.SetValue(t, Convert.ChangeType(reader[item.Name], item.PropertyType), null);
                    }
                    catch
                    {
                        item.SetValue(t, Enum.Parse(item.PropertyType, Convert.ToString(reader[item.Name])), null);
                    }
                }
            }

            return t;
        }
        /// <summary>
        /// 组装一个模型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static T Fill<T>(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed && reader.Read())
            {
                return Fill<T>(reader, null);
            }
            else
            {
                return default(T);//System.Activator.CreateInstance<T>();
            }

        }
        /// <summary>
        /// 获取模型对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static List<T> FillList<T>(IDataReader reader)
        {
            List<T> list = new List<T>();
            if (reader != null && !reader.IsClosed)
            {
                System.Collections.Hashtable table = FillTable(reader);
                while (reader.Read())
                {
                    list.Add(Fill<T>(reader, table));
                }
                reader.Close();
            }

            return list;
        }
        /// <summary>
        /// 获取reader中列名集合
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static System.Collections.Hashtable FillTable(IDataReader reader)
        {
            System.Collections.Hashtable table = new System.Collections.Hashtable();

            table = new System.Collections.Hashtable();
            int count = reader.FieldCount;
            for (int i = 0; i < count; i++)
            {
                table.Add(reader.GetName(i).ToLower(), null);
            }

            return table;
        }
        /// <summary>
        /// 获取模型对象集合
        /// 自动关闭连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandType"></param>
        /// <param name="sqlText"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(IDataReader reader)
        {
            return FillList<T>(reader);
        }
        /// <summary>
        /// 组装一个模型对象
        /// 自动关闭连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandType"></param>
        /// <param name="sqlText"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T Get<T>(IDataReader reader)
        {
            return Fill<T>(reader);
        }
    }
}
