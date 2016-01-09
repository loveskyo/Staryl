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


        public IEnumerable<ViewStarUserInfo> GetByPage(int pageIndex, int pageSize, string where, string orderBy, out int recordCount, bool doCount)
        {
            Database db = DBHelper.CreateDataBase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager2005");
            db.AddInParameter(dbCommand, "tblName", DbType.String, "UserStarUserView");
            db.AddInParameter(dbCommand, "strGetFields", DbType.String, "*");
            db.AddInParameter(dbCommand, "strOrder", DbType.String, orderBy);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, where.Trim());
            db.AddInParameter(dbCommand, "pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "pageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbCommand, "recordCount", DbType.Int32, 8);
            db.AddInParameter(dbCommand, "doCount", DbType.Boolean, doCount);
            List<ViewStarUserInfo> list = new List<ViewStarUserInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                list = Fabricate.GetList<ViewStarUserInfo>(dataReader);
            }
            recordCount = (int)db.GetParameterValue(dbCommand, "recordCount");
            return list;
        }
    }


}

