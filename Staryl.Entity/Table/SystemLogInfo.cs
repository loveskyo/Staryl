using System;


namespace Staryl.Entity
{

    [Serializable]
    public partial class SystemLogInfo
    {
      /// <summary>
      /// 
      /// </summary> 
      public int Id{get;set;}

      /// <summary>
      /// 方法名称
      /// </summary> 
      public string  MethodName{get;set;}

      /// <summary>
      /// 方法签名
      /// </summary> 
      public string  MethodSignature{get;set;}

      /// <summary>
      /// 类型名称
      /// </summary> 
      public string  TypeName{get;set;}

      /// <summary>
      /// 执行上下文
      /// </summary> 
      public string  CallContext{get;set;}

      /// <summary>
      /// 系统名称
      /// </summary> 
      public string SystemName{get;set;}

      /// <summary>
      /// 执行时长
      /// </summary> 
      public int UseTime{get;set;}

      /// <summary>
      /// 参数
      /// </summary> 
      public string  Args{get;set;}

      /// <summary>
      /// 开始时间
      /// </summary> 
      public DateTime CreateDate{get;set;}

      /// <summary>
      /// IP
      /// </summary> 
      public string  CreateIP{get;set;}

      /// <summary>
      /// 返回值
      /// </summary> 
      public string  ReturnValue{get;set;}

      /// <summary>
      /// 日志类型
      /// </summary> 
      public int LogType{get;set;}

    }
}
