using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class PhotoInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 图片地址 不含路径
      /// </summary> 
      public string PhotoImage{get;set;}

      /// <summary>
      /// 相册Id
      /// </summary> 
      public int AlbumId{get;set;}

      /// <summary>
      /// 用户Id
      /// </summary> 
      public int UserId{get;set;}

      /// <summary>
      /// 创建时间
      /// </summary> 
      public DateTime CreateDate{get;set;}

      /// <summary>
      /// 创建IP
      /// </summary> 
      public string CreateIP{get;set;}

      /// <summary>
      /// 是否默认图
      /// </summary> 
      public bool IsDefault{get;set;}

    }
}
