using Staryl.BLL;
using Staryl.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.Manage.Controllers
{
    [AuthAttribute]
    public class ControllerBase : Controller
    {
        protected SystemAccountManager accountMgr = new SystemAccountManager();
        protected SystemRoleManager roleMgr = new SystemRoleManager();
        protected SystemMenuManager menuMgr = new SystemMenuManager();
        protected SystemPrivilegesManager privilegesMgr = new SystemPrivilegesManager();
        protected SystemFunctionManager functionMgr = new SystemFunctionManager();
        protected UserManager userMgr = new UserManager();
        protected SystemAreaManager mSystemAreaMgr = new SystemAreaManager();
        protected StarUserManager starUserMgr = new StarUserManager();
        protected ActivityManager activityMgr = new ActivityManager();

        /// <summary>
        /// 获取客户端的 IP地址
        /// </summary>
        protected string GetIP
        {
            get
            {
                return Request.UserHostAddress.ToString();// + "___" + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] + "___" + clientIPAddress;
            }
        }
        /// <summary>
        /// 静态资源 访问地址
        /// </summary>
        public static string StaticDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["StaticDomain"];
            }
        }


        /// <summary>
        /// 角色
        /// </summary>
        protected int Roles
        {
            get
            {
                if (Session["userinfo"] == null)
                {
                    return 0;
                }
                return Convert.ToInt32(Session["userinfo"].ToString().Split('$')[3]);
            }
        }
        /// <summary>
        /// 站点域名
        /// </summary>
        protected string RootDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["RootDomain"];
            }
        }



        /// <summary>
        /// 上传的根目录
        /// </summary>
        protected string UploadRoot
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadRoot"];
            }
        }

        /// <summary>
        /// 上传根目录虚拟路径，用于URL读取
        /// </summary>
        protected string UploadDomainRoot
        {
            get {
                return UploadRoot.Split('\\').Last();
            }
        }

        #region 上传图片文件夹
        /// <summary>
        /// 头像
        /// </summary>
        protected string AvatrUrl
        {
            get
            {
                return "Avatr";
            }
        }

        /// <summary>
        /// 相片
        /// </summary>
        protected string PhotoUrl
        {
            get
            {
                return "Photo";
            }
        }

        /// <summary>
        /// 经历图片
        /// </summary>
        protected string UndergoUrl
        {
            get
            {
                return "Undergo";
            }
        }
        /// <summary>
        /// 活动图片
        /// </summary>
        protected string ActivityUrl
        {
            get {
                return "Activity";
            }
        }

        /// <summary>
        /// 编辑器图片
        /// </summary>
        protected string CKEditUrl
        {
            get {
                return "CKEdit";
            }
        }

        #endregion


        public string SaveImg(int accountId, string subpath, Stream stream)
        {
            string filePathName = string.Empty;
            string urlPath = this.UploadRoot;
            string localPath = this.UploadRoot;

            string upPath = localPath + "/" + subpath + (accountId > 0 ? "/" + accountId : "");

            if (!Directory.Exists(upPath))
            {
                Directory.CreateDirectory(upPath);
            }

            string fileName = string.Empty;
            string fileNames = string.Empty;
            if (stream.Length > 0)
            {
                int round = new Random(Guid.NewGuid().GetHashCode()).Next(10000, 99999);
                fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + round + ".jpg";
                filePathName = localPath + "/" + subpath + (accountId > 0 ? "/" + accountId : "") + "/" + fileName;//"/App_Upload/" + fileInfo.FileName;//自行处理保存
                System.Drawing.Image ResourceImage = System.Drawing.Image.FromStream(stream);
                ResourceImage.Save(filePathName);
                if (string.IsNullOrEmpty(fileNames))
                {
                    fileNames = fileName;
                }
                else
                    fileNames += "," + fileName;

            }
            return fileNames;//返回路径以备后用
        }

    }
}