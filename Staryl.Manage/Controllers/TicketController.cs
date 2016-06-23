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
    public class TicketController : ControllerBase
    {
        // GET: Ticket
        public ActionResult Index()
        {
            string userid = Convert.ToString(RouteData.Values["id"]);
            int uid = 0;
            int.TryParse(userid, out uid);
            UserInfo userinfo = userMgr.Get(uid);
            ViewModels viewmodels = new ViewModels();
            viewmodels.UserInfo = userinfo;

            return View(viewmodels);
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


            string userid = Convert.ToString(RouteData.Values["userid"]);
            string where = string.Empty;
            where = "1=1";
            where += string.IsNullOrEmpty(userid) ? string.Empty : " and UserId=" + userid + "";
            string orderBy = "order by Id desc";
            int recordCount = 0;
            IEnumerable<TicketInfo> activityList = ticketMgr.GetPageList(pageIndex, pageSize, where, orderBy, out recordCount, true);
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

        [AuthAttribute(FunCode = "Add")]
        public ActionResult Create()
        {
            ViewModels viewmodels = new ViewModels();
            return View(viewmodels);
        }

        [AuthAttribute(FunCode = "Add", ReturnType = "json")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(TicketInfo model)
        {

            bool issuc = false;
            model.CreateDate = DateTime.Now;
            model.CreateIP = this.GetIP;
            int id = ticketMgr.Create(model);
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
            viewmodels.ActivityUrl = this.ActivityUrl;
            viewmodels.UploadDomainRoot = this.UploadDomainRoot;
            viewmodels.Ticket = ticketMgr.Get(id);
            return View(viewmodels);
        }

        [AuthAttribute(FunCode = "Modify", ReturnType = "json")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Modify(TicketInfo model)
        {
            bool issuc = false;
            TicketInfo _model = ticketMgr.Get(model.Id);
            if (_model != null)
            {
                //_model.BriefIntroduction = model.BriefIntroduction;
                //_model.ChargeLevel = model.ChargeLevel;
                //_model.Content = model.Content;
                //_model.OrderBy = model.OrderBy;
                //_model.Title = model.Title;
                //_model.TypeId = model.TypeId;
                //_model.Images = model.Images;
                //_model.IsActive = model.IsActive;
                //_model.Province = model.Province;
                //_model.City = model.City;
                //_model.Area = model.Area;
                //_model.Status = model.Status;

                issuc = ticketMgr.Update(_model);
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
            ActivityInfo model = activityMgr.Get(int.Parse(id));

            bool res = ticketMgr.Delete(new TicketInfo { Id = int.Parse(id) });
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
            string ids = col["Ids"];
            bool res = ticketMgr.Deletes(ids);
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