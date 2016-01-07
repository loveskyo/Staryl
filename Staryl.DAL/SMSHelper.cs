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
        /// ���Ͷ���
        /// </summary>
        /// <param name="mobile">�ֻ���</param>
        /// <param name="message">��������</param>
        /// <returns></returns>
        public string SendSMS(string mobile, string message)
        {
            string name = this.SMSAccount;
            string pwd = this.SMSPassword;
            string sign = "Сͯ�Ǿ��ֲ�";
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
            //    //�ύ�ɹ�
            //}
            //else
            //{
            //    //�ύʧ�ܣ��������㣬�������дʻ�ȵ�
            //}

            return resp;//��һ�� �Զ��Ÿ������ַ������Ķ��ĵ��鿴��Ӧ����˼
        }

        /// 

        /// HTTP POST��ʽ
        /// 

        /// POST������ַ
        /// POST�Ĳ���������ֵ
        /// ���뷽ʽ
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

            //���շ�����Ϣ��
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader aspx = new StreamReader(response.GetResponseStream(), encode);
            return aspx.ReadToEnd();
        }







        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <param name="SmtpSection">������Ϣ</param>
        /// <param name="userMail">Ҫ���͵��������ַ</param>
        /// <param name="message">�ʼ�����</param>
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
            //    m_smtpClient.EnableSsl = true;    //ע����һ��,gmail��������Ҫ����SSL���������Ҫ������ᱨ��
            m_smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            m_smtpClient.Credentials = new System.Net.NetworkCredential(smtpSec.Network.UserName, smtpSec.Network.Password);
            m_smtpClient.Send(m_message);
        }
    }
}

