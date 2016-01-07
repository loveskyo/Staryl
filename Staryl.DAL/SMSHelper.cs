using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Configuration;
using System.Net.Mail;
using Staryl.IDAL;
namespace Staryl.DAL
{

    public class SMSHelper :BaseDAL, ISMSHelper
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="message">短信内容</param>
        /// <returns></returns>
        public string SendSMS(string mobile, string message)
        {
            string name = this.SMSAccount;
            string pwd = this.SMSPassword;
            string sign = "小童星俱乐部";
            StringBuilder arge = new StringBuilder();

            arge.AppendFormat("name={0}", name);
            arge.AppendFormat("&pwd={0}", pwd);
            arge.AppendFormat("&content={0}", message);
            arge.AppendFormat("&mobile={0}", mobile);
            arge.AppendFormat("&sign={0}", sign);
            arge.Append("&type=pt");
            string weburl = this.SMSUrl;

            string resp = PushToWeb(weburl, arge.ToString(), Encoding.UTF8);
            //if (resp.Split(',')[0] == "0")
            //{
            //    //提交成功
            //}
            //else
            //{
            //    //提交失败，可能余额不足，或者敏感词汇等等
            //}

            return resp;//是一串 以逗号隔开的字符串。阅读文档查看响应的意思
        }

        /// 

        /// HTTP POST方式
        /// 

        /// POST到的网址
        /// POST的参数及参数值
        /// 编码方式
        /// 
        public string PushToWeb(string weburl, string data, Encoding encode)
        {
            byte[] byteArray = encode.GetBytes(data);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(weburl));
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;
            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();

            //接收返回信息：
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader aspx = new StreamReader(response.GetResponseStream(), encode);
            return aspx.ReadToEnd();
        }







        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="SmtpSection">配置信息</param>
        /// <param name="userMail">要发送到的邮箱地址</param>
        /// <param name="message">邮件内容</param>
        /// <returns></returns>
        public void SendEmail(SmtpSection smtpSec, string userMail, string message)
        {
          //  SmtpSection smtpSec = NetSectionGroup.GetSectionGroup(WebConfigurationManager.OpenWebConfiguration("~/web.config")).MailSettings.Smtp;        
            string tomailhost = userMail.Split('@')[1];
           // smtpSec.From = "sesameregist@sina.com";// MailInfo.mailaddr;
          //  smtpSec.Network.Host = "smtp.sina.com";// MailInfo.mailhost;
          //  smtpSec.Network.UserName = "sesameregist@sina.com";//MailInfo.mailaddr;
          //  smtpSec.Network.Password = "uth2014";//MailInfo.mailpwd;
            MailMessage m_message = new MailMessage();
            m_message.From = new MailAddress("sesameregist@sina.com", "sesameregister");
            m_message.To.Add(new MailAddress(userMail));
            m_message.Subject = "UTH";
            m_message.SubjectEncoding = System.Text.Encoding.UTF8;
            m_message.Body = message;
            m_message.IsBodyHtml = true;
            SmtpClient m_smtpClient = new SmtpClient("smtp.sina.com", 25);
            //SmtpClient m_smtpClient = new SmtpClient();
            //if (MailInfo.IsSSL)
            //    m_smtpClient.EnableSsl = true;    //注意这一句,gmail这样的需要允许SSL的邮箱必须要，否则会报错
            m_smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            m_smtpClient.Credentials = new System.Net.NetworkCredential(smtpSec.Network.UserName, smtpSec.Network.Password);
            m_smtpClient.Send(m_message);
        }
    }
}

