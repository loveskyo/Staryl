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

namespace Staryl.DAL
{
             
    public partial class SystemFunctionDAL
    {

        public List<string> GetNamesByCodes(string[] codes)
        {
            List<string> res = new List<string>();
            SystemFunctionInfo model = null;
            foreach (string code in codes)
            {
                model = this.GetByFunctionCode(code);
                if (model != null)
                    res.Add(model.FunctionName);
            }
            return res;
        }
        public List<SystemFunctionInfo> GetByCodes(string[] codes)
        {
            List<SystemFunctionInfo> res = new List<SystemFunctionInfo>();
            SystemFunctionInfo model = null;
            foreach (string code in codes)
            {
                model = this.GetByFunctionCode(code);
                if (model != null)
                    res.Add(model);
            }
            return res;
        }
        public bool CheckFunCode(string code)
        {
            SystemFunctionInfo model = this.GetByFunctionCode(code);
            if (model == null)
                return false;
            return true;
        }
    }


}

