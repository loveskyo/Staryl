using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class SystemPrivilegesInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 角色Id
      /// </summary> 
      public int RoleId{get;set;}

      /// <summary>
      /// 栏目Id
      /// </summary> 
      public int MenuId{get;set;}

      /// <summary>
      /// 具有功能
      /// </summary> 
      public string FunctionCodes{get;set;}

    }
}
