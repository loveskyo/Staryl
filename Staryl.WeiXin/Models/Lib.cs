using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staryl.WeiXin
{
    public class Lib
    {
        /// <summary>
        /// 获得生肖
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static string GetShengXiao(DateTime birthday)
        {
            System.Globalization.ChineseLunisolarCalendar chinseCaleander = new System.Globalization.ChineseLunisolarCalendar();

            string TreeYear = "鼠牛虎兔龙蛇马羊猴鸡狗猪";

            int intYear = chinseCaleander.GetSexagenaryYear(birthday);

            string Tree = TreeYear.Substring(chinseCaleander.GetTerrestrialBranch(intYear) - 1, 1);

            return Tree;
        }

        /// <summary>
        /// 根据生日获取星座
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static string GetAtomFromBirthday(DateTime birthday)
        {
            float birthdayF = 0.00F;

            if (birthday.Month == 1 && birthday.Day < 20)
            {
                birthdayF = float.Parse(string.Format("13.{0}", birthday.Day));
            }
            else
            {
                birthdayF = float.Parse(string.Format("{0}.{1}", birthday.Month, birthday.Day));
            }
            float[] atomBound = { 1.20F, 2.20F, 3.21F, 4.21F, 5.21F, 6.22F, 7.23F, 8.23F, 9.23F, 10.23F, 11.21F, 12.22F, 13.20F };
            string[] atoms = { "水瓶座", "双鱼座", "白羊座", "金牛座", "双子座", "巨蟹座", "狮子座", "处女座", "天秤座", "天蝎座", "射手座", "魔羯座" };

            string ret = "靠！外星人啊。";
            for (int i = 0; i < atomBound.Length - 1; i++)
            {
                if (atomBound[i] <= birthdayF && atomBound[i + 1] > birthdayF)
                {
                    ret = atoms[i];
                    break;
                }
            }
            return ret;
        }
    }
}