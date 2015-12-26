using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Staryl.Library;
using System.Reflection;

namespace Staryl.Factory
{
    public static class DataAccess<T>
    {
        private static readonly string assemblyString = ConfigurationManager.AppSettings["DAL"];

        /// <summary>
        /// 通用对象反射(包含缓存)
        /// </summary>
        /// <param name="className">要反射的类名</param>
        /// <returns></returns>
        public static T CreateObject(string className)
        {
            var typeName = assemblyString + "." + className;
            //判断对象是否被缓存,如果已经缓存则直接从缓存中读取,反之则直接反射并缓存
            var obj = (T)CacheHelper.GetCache(typeName);
            if (obj == null)
            {
                obj = (T)Assembly.Load(assemblyString).CreateInstance(typeName, true);
                CacheHelper.Add(typeName, obj, true);
            }
            return obj;
        }
    }

}
