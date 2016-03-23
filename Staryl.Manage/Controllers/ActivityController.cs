﻿using Newtonsoft.Json;
using Staryl.Entity;
using Staryl.Manage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.Manage.Controllers
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
            IEnumerable<ActivityInfo> activityList = activityMgr.GetPageList(pageIndex, pageSize, where, orderBy, out recordCount, true);
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
        [HttpPost]
        public ActionResult Create(ActivityInfo model)
        {

            bool issuc = false;
            model.CreateDate = DateTime.Now;
            model.CreateIP = this.GetIP;
            int id = activityMgr.Create(model);
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
            viewmodels.Activity = activityMgr.Get(id);
            return View(viewmodels);
        }

        [AuthAttribute(FunCode = "Modify", ReturnType = "json")]
        [HttpPost]
        public ActionResult Modify(ActivityInfo model)
        {
            bool issuc = false;
            ActivityInfo _model = activityMgr.Get(model.Id);
            if (_model != null)
            {
                _model.BriefIntroduction = model.BriefIntroduction;
                _model.ChargeLevel = model.ChargeLevel;
                _model.Content = model.Content;
                _model.OrderBy = model.OrderBy;
                _model.Title = model.Title;
                _model.TypeId = model.TypeId;
                issuc = activityMgr.Update(_model);
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

            bool res = activityMgr.Delete(new ActivityInfo { Id = int.Parse(id) });
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
            bool res = activityMgr.Deletes(ids);
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