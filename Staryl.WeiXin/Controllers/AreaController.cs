using Staryl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.WeiXin.Controllers
{
    public class AreaController : ControllerBase
    {
        //
        // GET: /Area/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAreaByParentId(int parentId)
        {
            List<SystemAreaInfo> list = mSystemAreaMgr.GetListByWhere(0, "ParentId=" + parentId);
            return Json(list);
        }

        public ActionResult GetNameById(int pid,int cid,int aid)
        {
            SystemAreaInfo pinfo = mSystemAreaMgr.Get(pid);
            SystemAreaInfo cinfo = mSystemAreaMgr.Get(cid);
            SystemAreaInfo ainfo = mSystemAreaMgr.Get(aid);
            string addr = pinfo.Display + "-" + cinfo.Display + "-" + ainfo.Display;
            return Content(addr);
        }
	}
}