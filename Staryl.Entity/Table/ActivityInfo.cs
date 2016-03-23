using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class ActivityInfo
    {
      /// <summary>
      /// 会员活动
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 活动主题
      /// </summary> 
      public string Title{get;set;}

      /// <summary>
      /// 简介
      /// </summary> 
      public string  BriefIntroduction{get;set;}

      /// <summary>
      /// 活动内容
      /// </summary> 
      public string Content{get;set;}

      /// <summary>
      /// 活动类型
      /// </summary> 
      public int TypeId{get;set;}

      /// <summary>
      /// 收费级别（免费，会员免费..）
      /// </summary> 
      public int ChargeLevel{get;set;}

      /// <summary>
      /// 排序
      /// </summary> 
      public int OrderBy{get;set;}

      /// <summary>
      /// 活动状态
      /// </summary> 
      public int Status{get;set;}

      /// <summary>
      /// 是否发布
      /// </summary> 
      public bool IsActive{get;set;}

      /// <summary>
      /// 创建时间
      /// </summary> 
      public DateTime CreateDate{get;set;}

      /// <summary>
      /// 创建IP
      /// </summary> 
      public string CreateIP{get;set;}

    }
}
