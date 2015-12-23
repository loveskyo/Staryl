using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class SystemFunctionInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 功能名称
      /// </summary> 
      public string FunctionName{get;set;}

      /// <summary>
      /// 功能代码
      /// </summary> 
      public string FunctionCode{get;set;}

      /// <summary>
      /// 是否内置 内置不可删除
      /// </summary> 
      public bool IsBuiltin{get;set;}

    }
}
