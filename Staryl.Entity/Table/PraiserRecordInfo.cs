using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class PraiserRecordInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 被点赞者
      /// </summary> 
      public int StarId{get;set;}

      /// <summary>
      /// 点赞者(可能是游客)
      /// </summary> 
      public int ? PraiserId{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public DateTime CreateDate{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public string CreateIP{get;set;}

    }
}
