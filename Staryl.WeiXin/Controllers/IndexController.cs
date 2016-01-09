using Staryl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.WeiXin.Controllers
{
    public class IndexController : ControllerBase
    {
        // GET: Index
        public ActionResult Index()
        {
            ViewBag.avatarpath = this.AvatrUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Gets(FormCollection col)
        {
            int pageIndex = 1;
            int.TryParse(Convert.ToString(col["txtPage"]), out pageIndex);
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 20;
            int.TryParse(Convert.ToString(col["txtPageSize"]), out pageSize);
            if (pageSize <= 0)
                pageSize = 20;
            int Gender = -1;
            int.TryParse(Convert.ToString(col["txtGender"]), out Gender);

            string where = string.Empty;
            where = "IsVIP=0";
            where += Gender < 0 ? string.Empty : " and Gender=" + Gender + "";
            string orderBy = "order by Id desc";
            int recordCount = 0;
            IEnumerable<ViewStarUserInfo> accountList = mStarUserMgr.GetByPage(pageIndex, pageSize, where, orderBy, out recordCount, true);
            ReturnData returnData = new ReturnData
            {
                Data = accountList,
                PageSize = pageSize,
                TotalCount = recordCount,
                CurrPage = pageIndex
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnData);
            return Content(json);
        }
    }
}