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
    public class MenuController : ControllerBase
    {
        //
        // GET: /Menu/
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
            where += string.IsNullOrEmpty(key) ? string.Empty : " and MenuName like'%" + key + "%'";
            string orderBy = "order by Id desc";
            int recordCount = 0;
            IEnumerable<SystemMenuInfo> accountList = menuMgr.GetPageList(pageIndex, pageSize, where, orderBy, out recordCount, true);
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
            viewmodels.FunctionList = functionMgr.GetList();
            viewmodels.SystemMenuList = menuMgr.GetMenuByParentId(0);
            return View(viewmodels);
        }

        [AuthAttribute(FunCode = "Add", ReturnType = "json")]
        [HttpPost]
        public ActionResult Create(SystemMenuInfo model)
        {

            bool issuc = false;
            string _funs = Request["Functions"];
            model.Functions = _funs;
            int id = menuMgr.Create(model);
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
            viewmodels.SystemMenuList = menuMgr.GetMenuByParentId(0);
            viewmodels.MenuInfo = menuMgr.Get(id);
            return View(viewmodels);
        }

        [AuthAttribute(FunCode = "Modify", ReturnType = "json")]
        [HttpPost]
        public ActionResult Modify(SystemMenuInfo model)
        {
            bool issuc = false;
            string _funs = Request["Functions"];
            model.Functions = _funs;
            issuc = menuMgr.Update(model);

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
            bool res = menuMgr.Delete(new SystemMenuInfo { Id = int.Parse(id) });
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
            bool res = menuMgr.Deletes(Ids);
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