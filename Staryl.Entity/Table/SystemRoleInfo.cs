using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class SystemRoleInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 角色名称
      /// </summary> 
      public string RoleName{get;set;}

      /// <summary>
      /// 是否可以删除
      /// </summary> 
      public bool IsCanDelete{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public string CreateIP{get;set;}

      /// <summary>
      /// 
      /// </summary> 
      public DateTime CreateDate{get;set;}

    }
}
