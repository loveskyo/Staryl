using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class ActivityApplyInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 活动Id
      /// </summary> 
      public int ActivityId{get;set;}

      /// <summary>
      /// 会员Id
      /// </summary> 
      public int UserId{get;set;}

      /// <summary>
      /// 小朋友Id
      /// </summary> 
      public int StarId{get;set;}

      /// <summary>
      /// 状态（正常，取消，未参加，已参加）
      /// </summary> 
      public int Status{get;set;}

      /// <summary>
      /// 报名时间
      /// </summary> 
      public DateTime CreateDate{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public string CreateIP{get;set;}

    }
}
