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
    public class UserController : ControllerBase
    {
        //
        // GET: /User/
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
            where = "id>0";
            where += string.IsNullOrEmpty(key) ? string.Empty : " and RealName like'%" + key + "%'";
            string orderBy = "order by Id desc";
            int recordCount = 0;
            IEnumerable<UserInfo> accountList = userMgr.GetPageList(pageIndex, pageSize, where, orderBy, out recordCount, true);
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

            return View(viewmodels);
        }

        [AuthAttribute(FunCode = "Add", ReturnType = "json")]
        [HttpPost]
        public ActionResult Create(UserInfo model)
        {
            bool issuc = false;
            model.Password = Security.DESEncrypt(model.Password);
            model.CreateDate = DateTime.Now;
            model.CreateIP = this.GetIP;
            model.Status = (int)UserStatusEnum.正常;
            int id = userMgr.Create(model);
            if (id > 0)
            {
                issuc = true;
            }
            MsgInfo msgInfo = new MsgInfo();
            if (issuc)
            {
                msgInfo.IsError = false;
                msgInfo.Msg = id.ToString();
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

        [AuthAttribute(FunCode = "Add", ReturnType = "json")]
        [HttpPost]
        public ActionResult CreateStarUser(StarUserInfo model)
        {
            bool issuc = false;
            model.Hobby = Request["Hobby"];
            model.CreateDate = DateTime.Now;
            model.CreateIP = this.GetIP;
            model.Avatar = "";
            int id = starUserMgr.Create(model);
            if (id > 0)
            {
                issuc = true;
            }
            MsgInfo msgInfo = new MsgInfo();
            if (issuc)
            {
                msgInfo.IsError = false;
                msgInfo.Msg = id.ToString();
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
            viewmodels.userInfo = userMgr.Get(id);
            return View(viewmodels);
        }

        [AuthAttribute(FunCode = "Modify", ReturnType = "json")]
        [HttpPost]
        public ActionResult Modify(UserInfo model)
        {
            bool issuc = false;
            UserInfo _model = userMgr.Get(model.Id);
            if (_model != null)
            {
                _model.Avatar = model.Avatar;
                _model.IsVIP = model.IsVIP;
                _model.Mobile = model.Mobile;
                _model.RealName = model.RealName;
                _model.RecommendUser = model.RecommendUser;
                _model.UserType = model.UserType;
                if (!string.IsNullOrEmpty(model.Password))
                    _model.Password = Security.DESEncrypt(model.Password);
                issuc = userMgr.Update(_model);
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
            bool res = userMgr.Delete(new UserInfo { Id = int.Parse(id) });
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
            string Account = Request["UserName"];
            var accounts = userMgr.GetListByWhere(1, "UserName='" + Account + "'");
            bool res = true;
            if (accounts != null && accounts.Count > 0)
                res = false;
            return Json(new Remote { valid = res });

        }
        [HttpPost]
        public ActionResult UploadImg()
        {
            string userId = Request["userid"];
            int uid = 0;
            int.TryParse(userId, out uid);
            if (Request.InputStream.Length <= 0)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "保存失败" }, id = "id" });
            }

            string imgurl = string.Empty;
            try
            {
                imgurl = SaveImg(uid, this.AvatrUrl, Request.InputStream);
            }
            catch (Exception ex)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 103, message = "保存失败" }, id = "id" });
            }
            return Json(new { jsonrpc = 2.0, filepath = imgurl, id = "id" });
        }

        [HttpPost]
        public ActionResult CheckMobileOrEmail()
        {
            string value = Request["Mobile"];
            if (string.IsNullOrEmpty(value))
                value = Request["Email"];
            bool res = true;
            UserInfo userInfo = null;
            if (value.IndexOf("@") >= 0)
            {
                userInfo = userMgr.GetByEmail(value);
            }
            else
            {
                userInfo = userMgr.GetByMobile(value);
            }
            if (userInfo != null)
            {
                res = false;
            }
            return Content(JsonConvert.SerializeObject(new Remote { valid = res }));
        }

    }
}