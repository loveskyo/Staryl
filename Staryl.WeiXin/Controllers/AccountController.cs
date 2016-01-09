using Staryl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.WeiXin.Controllers
{
    public class AccountController : ControllerBase
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            ViewModels viewmodels = new ViewModels();
            UserInfo userInfo = mUserMgr.Get(this.AccountId);
            viewmodels.userInfo = userInfo;
            ViewBag.avatarpath = this.AvatrUrl;
            return View(viewmodels);
        }

        public ActionResult StarInfo()
        {
            ViewModels viewmodels = new ViewModels();
            UserInfo userInfo = mUserMgr.Get(this.AccountId);
            viewmodels.userInfo = userInfo;
            ViewBag.avatarpath = this.AvatrUrl;

            List<StarUserInfo> list = mStarUserMgr.GetByParentId(userInfo.Id);
            viewmodels.starUserInfo = list != null && list.Count > 0 ? list.First() : null;

            viewmodels.systemAreaList = mSystemAreaMgr.GetListByWhere(0, "ParentId=0");
            return View(viewmodels);
        }

        public ActionResult StarView()
        {
            ViewModels viewmodels = new ViewModels();
            UserInfo userInfo = mUserMgr.Get(this.AccountId);
            viewmodels.userInfo = userInfo;
            ViewBag.avatarpath = this.AvatrUrl;
            ViewBag.undergoPath = this.UndergoUrl;
            ViewBag.photoPath = this.PhotoUrl;

            List<StarUserInfo> list = mStarUserMgr.GetByParentId(userInfo.Id);
            viewmodels.starUserInfo = list != null && list.Count > 0 ? list.First() : null;
            if (viewmodels.starUserInfo == null)
                return Redirect("StarInfo");

            return View(viewmodels);
        }
        [HttpPost]
        public ActionResult StarCreate(StarUserInfo model)
        {
            if (model.Id > 0) {
                StarUserInfo _model = mStarUserMgr.Get(model.Id);
                if (_model == null)
                    return Json(-1);
                _model.Avatar = model.Avatar;
                _model.RealName = model.RealName;
                _model.Height = model.Height;
                _model.Hobby = model.Hobby;
                _model.Greeting = model.Greeting;
                _model.Gender = model.Gender;
                _model.Weight = model.Weight;
                _model.Birthday = model.Birthday;
                _model.Province = model.Province;
                _model.City = model.City;
                _model.Area = model.Area;
                bool res = mStarUserMgr.Update(_model);
                if (res)
                    return Json(1);
            }
            else
            {
                model.CreateDate = DateTime.Now;
                model.CreateIP = this.GetIP;
                model.ParentId = this.AccountId;
                int id = mStarUserMgr.Create(model);
                if (id > 0)
                    return Json(1);
            }
            return Json(0);
        }
	}
}