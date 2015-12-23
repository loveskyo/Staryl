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
            HttpFileCollectionBase uploadedFiles = Request.Files;
            if (uploadedFiles == null || uploadedFiles.Count <= 0)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "保存失败" }, id = "id" });
            }

            string imgurl = string.Empty;
            try
            {
                imgurl = SaveImg(this.AccountId, this.AvatrUrl, uploadedFiles);
            }
            catch (Exception ex)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 103, message = "保存失败" }, id = "id" });
            }
            return Json(new { jsonrpc = 2.0, filepath = imgurl, id = "id" });
        }

        public string SaveImg(int accountId, string subpath, HttpFileCollectionBase uploadedFiles)
        {
            string filePathName = string.Empty;
            string urlPath = this.UploadRoot;
            string localPath = this.UploadRoot;

            string upPath = localPath + "/" + subpath + "/" + accountId;
            if (!Directory.Exists(upPath))
            {
                Directory.CreateDirectory(upPath);
            }
            string fileName = string.Empty;
            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                HttpPostedFileBase fileInfo = uploadedFiles[i];

                if (fileInfo != null && fileInfo.ContentLength > 0)
                {
                    fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    filePathName = localPath + "/" + subpath + "/" + accountId + "/" + fileName;//"/App_Upload/" + fileInfo.FileName;//自行处理保存
                    fileInfo.SaveAs(filePathName);

                }

            }
            return fileName;//返回路径以备后用
        }


    }
}