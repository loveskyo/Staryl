using Staryl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Staryl.WeiXin.Controllers
{
    public class WeixinController : ControllerBase
    {
        //
        // GET: /Weixin/
        public ActionResult Index()
        {
            string token = "xtxclub2015";
            if (string.IsNullOrEmpty(token))
            {
                return Content("");
            }
            string echoString = Request["echoStr"];
            string signature = Request["signature"];
            string timestamp = Request["timestamp"];
            string nonce = Request["nonce"];

            WriteLog(string.Format("token:{0} echoString:{1} signature:{2} timestamp:{3} nonce:{4}", token, echoString, signature, timestamp, nonce));
            List<string> list = new List<string> { token, nonce, timestamp };
            string[] _val = list.OrderBy(p => p).ToArray();

            string val = SHA1(string.Join("", _val));
            if (val == signature)
                return Content(echoString);
            return Content("");
        }

        private static string SHA1(string text)
        {
            byte[] cleanBytes = Encoding.Default.GetBytes(text);
            byte[] hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
        private static void WriteLog(string text)
        {
            //在将文本写入文件前，处理文本行
            //StreamWriter一个参数默认覆盖
            //StreamWriter第二个参数为false覆盖现有文件，为true则把文本追加到文件末尾
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\WeixinLog\" + DateTime.Now.ToString("yyyyHHdd") + ".txt", true))
            {
                file.WriteLine(text);// 直接追加文件末尾，换行   
            }
        }

        [HttpPost]
        public ActionResult Undergo(FormCollection col)
        {
            int pageIndex = int.Parse(col["pageIndex"]);
            int pageSize = int.Parse(col["pageSize"]);
            int StarUserId = int.Parse(col["StarUserId"]);
            string where = "StarUserId=" + StarUserId;
            string orderBy = string.Empty;
            int recordCount = 0;
            List<ViewUndergo> undergoList = null;
            List<UndergoInfo> list = mUndergoMgr.GetPageList(pageIndex, pageSize, where, orderBy, out recordCount, false);
            if (list != null && list.Count > 0)
            {
                undergoList = new List<ViewUndergo>();
                foreach (UndergoInfo info in list)
                {
                    undergoList.Add(new ViewUndergo
                    {
                        Content = info.Content,
                        CreateDate = info.CreateDate.ToUniversalTime(),
                        CreateIP = info.CreateIP,
                        Id = info.Id,
                        StarUserId = info.StarUserId,
                        UndergoType = info.UndergoType,
                        PhotoList = string.IsNullOrEmpty(info.Photos) ? null : info.Photos.Split(',').ToList()
                    });
                }
            }

            ReturnData returnData = new ReturnData
            {
                Data = undergoList,
                PageSize = pageSize,
                TotalCount = recordCount,
                CurrPage = pageIndex
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnData);
            return Content(json);
        }

	}
}