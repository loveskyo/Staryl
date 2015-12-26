using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class AlbumInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 相册名称
      /// </summary> 
      public string  AlbumName{get;set;}

      /// <summary>
      /// 会员Id
      /// </summary> 
      public int UserId{get;set;}

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
