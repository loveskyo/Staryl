using Newtonsoft.Json;
using Staryl.Entity;
using Staryl.Manage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.Manage.Controllers
{
    public class RoleController : ControllerBase
    {
        //
        // GET: /Role/
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
            where += string.IsNullOrEmpty(key) ? string.Empty : " and RoleName like'%" + key + "%'";
            string orderBy = "order by Id desc";
            int recordCount = 0;
            IEnumerable<SystemRoleInfo> accountList = roleMgr.GetPageList(pageIndex, pageSize, where, orderBy, out recordCount, true);
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

        [AuthAttribute(FunCode = "Add")]
        public ActionResult Create()
        {
            ViewModels viewmodels = new ViewModels();
            viewmodels.PrivilegesList = new List<SystemPrivilegesInfo>();// privilegesMgr.GetByRoleId(Id);

            viewmodels.MenuList = menuMgr.GetViewMenu();
            return View(viewmodels);
        }

        [AuthAttribute(FunCode = "Add", ReturnType = "json")]
        [HttpPost]
        public ActionResult Create(SystemRoleInfo model)
        {

            bool issuc = false;
            model.CreateDate = DateTime.Now;
            model.CreateIP = this.GetIP;
            model.IsCanDelete = true;
            int id = roleMgr.Create(model);
            if (id > 0)
            {
                issuc = true;
            }
            MsgInfo msgInfo = new MsgInfo();
            if (issuc)
            {
                msgInfo.IsError = false;
                msgInfo.Msg = "操作成功！";
                msgInfo.MsgNo = (int)ErrorEnum.成功;
            }
            else
            {
                msgInfo.IsError = true;
                msgInfo.Msg = "操作失败！";
                msgInfo.MsgNo = (int)ErrorEnum.失败;
            }
            return Content(JsonConvert.SerializeObject(msgInfo));
        }

        [AuthAttribute(FunCode = "Modify")]
        public ActionResult Modify(int id)
        {
            ViewModels viewmodels = new ViewModels();
            viewmodels.RoleInfo = roleMgr.Get(id);
            return View(viewmodels);
        }

        [AuthAttribute(FunCode = "Modify", ReturnType = "json")]
        [HttpPost]
        public ActionResult Modify(SystemRoleInfo model)
        {
            bool issuc = false;
            SystemRoleInfo _model = roleMgr.Get(model.Id);
            if (_model != null)
            {
                _model.RoleName = model.RoleName;

                issuc = roleMgr.Update(_model);
            }
            MsgInfo msgInfo = new MsgInfo();
            if (issuc)
            {
                msgInfo.IsError = false;
                msgInfo.Msg = "操作成功！";
                msgInfo.MsgNo = (int)ErrorEnum.成功;
            }
            else
            {
                msgInfo.IsError = true;
                msgInfo.Msg = "操作失败！";
                msgInfo.MsgNo = (int)ErrorEnum.失败;
            }
            return Content(JsonConvert.SerializeObject(msgInfo));
        }


        [AuthAttribute(FunCode = "Delete", ReturnType = "json")]
        [HttpPost]
        public ActionResult Destroy(FormCollection col)
        {
            string id = col["Id"];
            SystemRoleInfo model = roleMgr.Get(int.Parse(id));
            if (model != null && !model.IsCanDelete)
                return Content("false");
            bool res = roleMgr.Delete(new SystemRoleInfo { Id = int.Parse(id) });
            MsgInfo msgInfo = new MsgInfo();
            if (res)
            {
                msgInfo.IsError = false;
                msgInfo.Msg = "删除成功！";
                msgInfo.MsgNo = (int)ErrorEnum.成功;
            }
            else
            {
                msgInfo.IsError = true;
                msgInfo.Msg = "删除失败！";
                msgInfo.MsgNo = (int)ErrorEnum.失败;
            }
            return Content(JsonConvert.SerializeObject(msgInfo));
        }

        [AuthAttribute(FunCode = "Delete", ReturnType = "json")]
        [HttpPost]
        public ActionResult Destroys(FormCollection col)
        {
            string Ids = col["Ids"];

            string[] _Ids = Ids.Split(',');
            List<string> ids = new List<string>();
            SystemRoleInfo model = null;
            foreach (string id in _Ids)
            {
                model = roleMgr.Get(int.Parse(id));
                if (model != null && model.IsCanDelete)
                    ids.Add(model.Id.ToString());
            }

            bool res = roleMgr.Deletes(string.Join(",", ids));
            MsgInfo msgInfo = new MsgInfo();
            if (res)
            {
                msgInfo.IsError = false;
                msgInfo.Msg = "删除成功！";
                msgInfo.MsgNo = (int)ErrorEnum.成功;
            }
            else
            {
                msgInfo.IsError = true;
                msgInfo.Msg = "删除失败！";
                msgInfo.MsgNo = (int)ErrorEnum.失败;
            }
            return Content(JsonConvert.SerializeObject(msgInfo));
        }
    }
}