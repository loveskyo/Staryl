using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class TicketInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 券号
      /// </summary> 
      public string TicketNo{get;set;}

      /// <summary>
      /// 所属用户Id
      /// </summary> 
      public int UserId{get;set;}

      /// <summary>
      /// 券开始时间（以0点为准，例：开始时间为23号，则23号可用）
      /// </summary> 
      public DateTime StarDate{get;set;}

      /// <summary>
      /// 券结束时间(到午夜12点为准，例：结束日期为24号，则24号当天可用)
      /// </summary> 
      public DateTime EndDate{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public DateTime CreateDate{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public string CreateIP{get;set;}

      /// <summary>
      /// 券创建者
      /// </summary> 
      public int Creator{get;set;}

      /// <summary>
      /// 券价值
      /// </summary> 
      public int TicketValue{get;set;}

      /// <summary>
      /// 券类型（现金券，一次券）
      /// </summary> 
      public int TicketType{get;set;}

      /// <summary>
      /// 状态，1未使用，2已使用，0已过期，-1无效
      /// </summary> 
      public int Status{get;set;}

    }
}
