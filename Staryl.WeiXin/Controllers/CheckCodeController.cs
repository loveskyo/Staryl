using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.WeiXin.Controllers
{
    public class CheckCodeController : Controller
    {
        //
        // GET: /CheckCode/
        public ActionResult Index()
        {
            //将生成的随机数保存在session中 
            string strNum = RandomNum(5);
            Session["CheckCode"] = strNum;
            byte[] graphic = CreatePic(strNum);
            return File(graphic, @"image/jpeg");
        }

        /// <summary> 
        /// 生成随机数 
        /// </summary> 
        /// <param name="Len">控制生成随机数的位数</param> 
        /// <returns></returns> 
        public string RandomNum(int Len)
        {
            string str = "0,1,2,3,4,5,6,7,8,9,";
            str += "a,b,c,d,e,f,g,h,i,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z,";
            //str += "A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";

            string[] s = str.Split(new char[] { ',' });//将字符串才分成字符串数组; 
            string strNum = String.Empty;
            int tag = -1;//用于记录上一个随机数的值，避免产生2个重复值; 
            Random rnd = new Random();
            //产生一个长为Len的随机字符串; 
            for (int i = 1; i <= Len; i++)
            {
                if (tag == -1)
                {
                    rnd = new Random(i * tag * unchecked((int)DateTime.Now.Ticks));//初始化一个随机数实例; 
                }
                int rndNum = rnd.Next(0, 33);//返回小于24个字符的非负随机数 
                if (tag != -1 && tag == rndNum)
                {
                    return RandomNum(Len);//返回该方法 
                }
                tag = rndNum;
                strNum += s[rndNum];
            }
            return strNum;
        }
        /// <summary> 
        /// 为图片添加干扰 
        /// </summary> 
        /// <param name="checkCode">绘制验证码</param> 
        private byte[] CreatePic(string checkCode)
        {
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return null;
            Bitmap image = new Bitmap(checkCode.Length * 12 + 10, 30);//定义图像 
            Graphics g = Graphics.FromImage(image);//创建新的image绘图对象 
            try
            {
                //随机生成器 
                Random random = new Random();
                //清空图片背景颜色; 
                g.Clear(Color.AliceBlue);
                //画图片的背景噪音线 
                for (int i = 0; i < 50; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    //获取系统的颜色画曲线 
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                //画图片字体和字号 
                Font font = new Font("Arial", 14, (FontStyle.Bold | FontStyle.Italic | FontStyle.Strikeout));
                //初始画刷 
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.BlueViolet, Color.Crimson, 12f, true);
                g.DrawString(checkCode, font, brush, 3, 4);//绘制指定文本的字符串 
                //图片前的噪音点 
                for (int i = 0; i < 50; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));//获取指定的颜色 
                }
                //画图片的边框线 
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //输出图像 
                MemoryStream ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);//将图片保存到指定流 
                //Response.ClearContent();//清楚缓冲区的流 
                //Response.ContentType = "imge.Gif";//配置输出类型 
                //Response.BinaryWrite(ms.ToArray());//输出内容 
                return ms.ToArray();
            }
            finally
            {
                //清空不需要的资源 
                g.Dispose();
                image.Dispose();
            }
        }

	}
}