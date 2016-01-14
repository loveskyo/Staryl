using Staryl.Entity;
using Staryl.Manage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.Manage.Controllers
{
    public class AreaController : ControllerBase
    {
        // GET: Area
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAreaByParentId(int parentId)
        {
            List<SystemAreaInfo> list = mSystemAreaMgr.GetListByWhere(0, "ParentId=" + parentId);
            List<Select2Info> _list = new List<Select2Info>();
            if (list != null && list.Count > 0)
                foreach (var info in list)
                    _list.Add(new Select2Info
                    {
                        id = info.Id,
                        text = info.Display
                    });
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(_list));
        }

    }
}