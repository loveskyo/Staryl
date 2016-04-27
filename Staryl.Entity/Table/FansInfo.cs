using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class FansInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 被关注者Id
      /// </summary> 
      public int StarId{get;set;}

      /// <summary>
      /// 关注者Id
      /// </summary> 
      public int FansId{get;set;}

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
