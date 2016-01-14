using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.WeiXin.Controllers
{
    public class UploadController : ControllerBase
    {
        //
        // GET: /Upload/
        public ActionResult Index()
        {
            //HttpFileCollectionBase uploadedFiles = Request.Files;
           // if (uploadedFiles == null || uploadedFiles.Count <= 0)
            
            if (Request.InputStream.Length <= 0)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "保存失败" }, id = "id" });
            }

            string imgurl = string.Empty;
            try
            {
                imgurl = SaveImg(this.AccountId, this.AvatrUrl, Request.InputStream);
            }
            catch (Exception ex)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 103, message = "保存失败" }, id = "id" });
            }
            return Json(new { jsonrpc = 2.0, filepath = imgurl, id = "id" });
        }



    }
}