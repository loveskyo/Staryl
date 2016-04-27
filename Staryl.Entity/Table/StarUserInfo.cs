using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class StarUserInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 性别 1男 2女
      /// </summary> 
      public int Gender{get;set;}

      /// <summary>
      /// 真实性名
      /// </summary> 
      public string RealName{get;set;}

      /// <summary>
      /// 出生年月
      /// </summary> 
      public DateTime Birthday{get;set;}

      /// <summary>
      /// 市
      /// </summary> 
      public int City{get;set;}

      /// <summary>
      /// 省
      /// </summary> 
      public int Province{get;set;}

      /// <summary>
      /// 区县
      /// </summary> 
      public int Area{get;set;}

      /// <summary>
      /// 头像
      /// </summary> 
      public string Avatar{get;set;}

      /// <summary>
      /// 身高 cm
      /// </summary> 
      public int ? Height{get;set;}

      /// <summary>
      /// 体重 kg
      /// </summary> 
      public int ? Weight{get;set;}

      /// <summary>
      /// 兴趣爱好
      /// </summary> 
      public string  Hobby{get;set;}

      /// <summary>
      /// 个性签名
      /// </summary> 
      public string  Greeting{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public DateTime CreateDate{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public string CreateIP{get;set;}

      /// <summary>
      /// 昵称
      /// </summary> 
      public string  NickName{get;set;}

      /// <summary>
      /// 父账号Id
      /// </summary> 
      public int ParentId{get;set;}

      /// <summary>
      /// 是否推荐
      /// </summary> 
      public bool IsRecommend{get;set;}

      /// <summary>
      /// 粉丝数（关注数）
      /// </summary> 
      public int FansNumber{get;set;}

      /// <summary>
      /// 点赞数
      /// </summary> 
      public int LikeNumber{get;set;}

    }
}
