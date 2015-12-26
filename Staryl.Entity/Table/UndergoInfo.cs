using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class UndergoInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 童星Id
      /// </summary> 
      public int StarUserId{get;set;}

      /// <summary>
      /// 照片 最多9张
      /// </summary> 
      public string  Photos{get;set;}

      /// <summary>
      /// 说明
      /// </summary> 
      public string  Content{get;set;}

      /// <summary>
      /// 创建时间
      /// </summary> 
      public DateTime CreateDate{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public string CreateIP{get;set;}

      /// <summary>
      /// 经历类型
      /// </summary> 
      public int UndergoType{get;set;}

    }
}
