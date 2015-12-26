using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class SystemAccountInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 登录账号
      /// </summary> 
      public string Account{get;set;}

      /// <summary>
      /// 登录密码
      /// </summary> 
      public string Password{get;set;}

      /// <summary>
      /// 用户姓名
      /// </summary> 
      public string  UserName{get;set;}

      /// <summary>
      /// 用户昵称
      /// </summary> 
      public string  NickName{get;set;}

      /// <summary>
      /// 角色Id
      /// </summary> 
      public int RoleId{get;set;}

      /// <summary>
      /// 部门
      /// </summary> 
      public int Department{get;set;}

      /// <summary>
      /// 是否可用
      /// </summary> 
      public bool IsEnable{get;set;}

      /// <summary>
      /// 是否可以删除
      /// </summary> 
      public bool IsCanDelete{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public string CreateIP{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public DateTime CreateDate{get;set;}

      /// <summary>
      /// 备注说明
      /// </summary> 
      public string  Remarks{get;set;}

    }
}
