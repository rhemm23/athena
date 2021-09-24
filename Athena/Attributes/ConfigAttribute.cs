using System;

namespace Athena.Attributes {

  [AttributeUsage(AttributeTargets.Class)]
  public class ConfigAttribute : Attribute {

    public string FileName { get; set; }
  }
}
