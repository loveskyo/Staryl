using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class UserInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 用户名
      /// </summary> 
      public string Email{get;set;}

      /// <summary>
      /// 性别
      /// </summary> 
      public int Gender{get;set;}

      /// <summary>
      /// 手机号码
      /// </summary> 
      public string Mobile{get;set;}

      /// <summary>
      /// 用户类型 1.个人用户 2.机构用户
      /// </summary> 
      public int UserType{get;set;}

      /// <summary>
      /// 推荐者
      /// </summary> 
      public string  RecommendUser{get;set;}

      /// <summary>
      /// 真实性名
      /// </summary> 
      public string  RealName{get;set;}

      /// <summary>
      /// 出生年月
      /// </summary> 
      public DateTime Birthday{get;set;}

      /// <summary>
      /// 头像
      /// </summary> 
      public string  Avatar{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public DateTime CreateDate{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public string CreateIP{get;set;}

      /// <summary>
      /// 是否VIP
      /// </summary> 
      public bool IsVIP{get;set;}

      /// <summary>
      /// 密码
      /// </summary> 
      public string Password{get;set;}

      /// <summary>
      /// 账号状态 UserStatusEnum
      /// </summary> 
      public int Status{get;set;}

      /// <summary>
      /// 是否登录状态
      /// </summary> 
      public bool IsLogin{get;set;}

    }
}
