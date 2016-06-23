using Newtonsoft.Json;
using Staryl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.WeiXin.Controllers
{
    public class ActivityController : ControllerBase
    {
        // GET: Activity
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Gets(FormCollection col)
        {
            int pageIndex = 1;
            int.TryParse(Convert.ToString(RouteData.Values["txtPage"]), out pageIndex);
            if (pageIndex <= 0)
                pageIndex = 1;
            int pageSize = 20;
            int.TryParse(Convert.ToString(RouteData.Values["txtPageSize"]), out pageSize);
            if (pageSize <= 0)
                pageSize = 20;


            string key = Convert.ToString(RouteData.Values["txtKey"]);
            ViewBag.key = key;
            string where = string.Empty;
            where = "1=1";
            where += string.IsNullOrEmpty(key) ? string.Empty : " and ([Title] like'%" + key + "%')";
            string orderBy = "order by Id desc";
            int recordCount = 0;
            IEnumerable<ViewActivityInfo> activityList = activityMgr.GetPageListView(pageIndex, pageSize, where, orderBy, out recordCount, true);
            ReturnData returnData = new ReturnData
            {
                Data = activityList,
                PageSize = pageSize,
                TotalCount = recordCount,
                CurrPage = pageIndex
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnData);
            return Content(json);
        }

        public ActionResult Details()
        {
            ViewModels viewModels = new ViewModels();
            int id = 0;
            int.TryParse(Convert.ToString(RouteData.Values["Id"]), out id);
            ViewActivityInfo info = null;
            if (id > 0)
            {
                var _info = activityMgr.Get(id);
                info = JsonConvert.DeserializeObject<ViewActivityInfo>(JsonConvert.SerializeObject(_info));
                if (_info.City > 0)
                    info.CityName = mSystemAreaMgr.Get(_info.City).Display;
            }
            else
                info = new ViewActivityInfo();
            viewModels.viewActivity = info;
            return View(viewModels);
        }

    }
}