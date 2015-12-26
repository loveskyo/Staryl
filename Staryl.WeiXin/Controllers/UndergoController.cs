using Staryl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.WeiXin.Controllers
{
    public class UndergoController : ControllerBase
    {
        // GET: Undergo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int starUserId)
        {
            HttpFileCollectionBase uploadedFiles = Request.Files;
            string imgurls = string.Empty;

            if (uploadedFiles == null || uploadedFiles.Count <= 0)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "保存失败" }, id = "id" });
            }
            string imgurl = string.Empty;
            try
            {
                imgurl = SaveImg(starUserId, this.UndergoUrl, uploadedFiles);
            }
            catch (Exception ex)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 103, message = "保存失败" }, id = "id" });
            }
            return Json(new { jsonrpc = 2.0, filepath = imgurl, id = "id" });
        }

        public ActionResult Create()
        {
            ViewModels viewmodels = new ViewModels();
            
            IList<StarUserInfo> starUserList = mStarUserMgr.GetByParentId(this.AccountId);
            if (starUserList != null && starUserList.Count > 0)
            {
                viewmodels.starUserInfo = starUserList.FirstOrDefault();    
            }
            return View(viewmodels);
        }


        [HttpPost]
        public ActionResult Create(UndergoInfo model)
        {
            model.CreateDate = DateTime.Now;
            model.CreateIP = this.GetIP;
            int id = mUndergoMgr.Create(model);
            if (id > 0)
            {
                return Json(true);
            }
            return Json(false);
        }


    }
}