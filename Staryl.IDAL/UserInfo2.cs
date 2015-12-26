using Staryl.Entity;
using System.Collections.Generic;
namespace Staryl.IDAL
{
    /// <summary>
    /// 接口层User
    /// </summary>
    public partial interface IUserDAL
    {
        string Login(string mobileOrEmail, string password);
   } 
}
