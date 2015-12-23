using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Staryl.DAL;
using Staryl.IDAL;
using Staryl.Entity;
using Newtonsoft.Json;
using Staryl.Library;

namespace Staryl.DAL
{

    public partial class SystemAccountDAL
    {



        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public string Login(string account, string password)
        {
            MsgInfo msgInfo = new MsgInfo { Msg = "登录成功", MsgNo = 0, IsError = false };
            List<SystemAccountInfo> list = this.GetListByWhere(1, "Account='" + account + "'");
            if (list == null || list.Count <= 0)
            {
                msgInfo.Msg = "用户名或密码错误";
                msgInfo.MsgNo = -1;
                msgInfo.IsError = true;
                return JsonConvert.SerializeObject(msgInfo);
            }
            if (list[0].Password != Security.DESEncrypt(password))
            {
                msgInfo.Msg = "用户名或密码错误";
                msgInfo.MsgNo = -1;
                msgInfo.IsError = true;
                return JsonConvert.SerializeObject(msgInfo);
            }
            if (!list[0].IsEnable)
            {
                msgInfo.Msg = "您的账号已被禁用，请联系管理员";
                msgInfo.MsgNo = -1;
                msgInfo.IsError = true;
                return JsonConvert.SerializeObject(msgInfo);
            }
            msgInfo.Msg = JsonConvert.SerializeObject(list[0]);
            msgInfo.IsError = false;
            return JsonConvert.SerializeObject(msgInfo);
        }

        public IEnumerable<ViewAccountInfo> GetByPage(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount)
        {
            Database db = DBHelper.CreateDataBase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager2005");
            db.AddInParameter(dbCommand, "tblName", DbType.String, "SystemAccountView");
            db.AddInParameter(dbCommand, "strGetFields", DbType.String, "*");
            db.AddInParameter(dbCommand, "strOrder", DbType.String, orderBy);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, where.Trim());
            db.AddInParameter(dbCommand, "pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "pageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbCommand, "recordCount", DbType.Int32, 8);
            db.AddInParameter(dbCommand, "doCount", DbType.Boolean, doCount);
            List<ViewAccountInfo> list = new List<ViewAccountInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                //while (dataReader.Read())
                //{
                // list.Add(FillList(dataReader));
                list = Fabricate.GetList<ViewAccountInfo>(dataReader);
                //}
            }

            recordCount = (int)db.GetParameterValue(dbCommand, "recordCount"); 
            return list;
        }





    }


}

