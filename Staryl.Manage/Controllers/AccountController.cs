using Newtonsoft.Json;
using Staryl.Entity;
using Staryl.Library;
using Staryl.Manage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.Manage.Controllers
{
    public class AccountController : ControllerBase
    {
        //
        // GET: /Account/
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
            where += string.IsNullOrEmpty(key) ? string.Empty : " and (Account like'%" + key + "%' or UserName like'%" + key + "%')";
            string orderBy = "order by Id desc";
            int recordCount = 0;
            IEnumerable<ViewAccountInfo> accountList = accountMgr.GetByPage(pageIndex, pageSize, where, orderBy, out recordCount, true);
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
            viewmodels.RoleList = roleMgr.GetList();
            return View(viewmodels);
        }

        [AuthAttribute(FunCode = "Add", ReturnType = "json")]
        [HttpPost]
        public ActionResult Create(SystemAccountInfo model)
        {

            bool issuc = false;
            model.Password = Security.DESEncrypt(model.Password);
            model.CreateDate = DateTime.Now;
            model.CreateIP = this.GetIP;
            model.IsCanDelete = true;
            int id = accountMgr.Create(model);
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
            viewmodels.RoleList = roleMgr.GetList();
            viewmodels.AccountInfo = accountMgr.Get(id);
            return View(viewmodels);
        }

        [AuthAttribute(FunCode = "Modify", ReturnType = "json")]
        [HttpPost]
        public ActionResult Modify(SystemAccountInfo model)
        {
            bool issuc = false;
            SystemAccountInfo _model = accountMgr.Get(model.Id);
            if (_model != null)
            {
                _model.UserName = model.UserName;
                _model.RoleId = model.RoleId;
                _model.IsEnable = model.IsEnable;
                _model.Remarks = model.Remarks;
                if (!string.IsNullOrEmpty(model.Password))
                    _model.Password = Security.DESEncrypt(model.Password);
                issuc = accountMgr.Update(_model);
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
            SystemAccountInfo model = accountMgr.Get(int.Parse(id));
            if (model != null && !model.IsCanDelete)
                return Content("false");
            bool res = accountMgr.Delete(new SystemAccountInfo { Id = int.Parse(id) });
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
            SystemAccountInfo model = null;
            foreach (string id in _Ids)
            {
                model = accountMgr.Get(int.Parse(id));
                if (model != null && model.IsCanDelete)
                    ids.Add(model.Id.ToString());
            }

            bool res = accountMgr.Deletes(string.Join(",", ids));
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

        [HttpPost]
        public ActionResult Check()
        {
            string Account = Request["Account"];
            var accounts = accountMgr.GetListByWhere(1, "account='" + Account + "'");
            bool res = true;
            if (accounts != null && accounts.Count > 0)
                res = false;
            return Json(new Remote { valid = res });

        }

    }
}