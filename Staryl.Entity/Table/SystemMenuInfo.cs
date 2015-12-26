using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class SystemMenuInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 栏目名称
      /// </summary> 
      public string MenuName{get;set;}

      /// <summary>
      /// 栏目地址
      /// </summary> 
      public string MenuAddr{get;set;}

      /// <summary>
      /// 父级栏目Id
      /// </summary> 
      public int ParentId{get;set;}

      /// <summary>
      /// 是否左侧
      /// </summary> 
      public bool IsLeft{get;set;}

      /// <summary>
      /// 是否顶部
      /// </summary> 
      public bool IsTop{get;set;}

      /// <summary>
      /// 栏目具有的功能
      /// </summary> 
      public string Functions{get;set;}

      /// <summary>
      /// 是否显示
      /// </summary> 
      public bool IsMenu{get;set;}

      /// <summary>
      /// 栏目等级
      /// </summary> 
      public int MenuLevel{get;set;}

    }
}
