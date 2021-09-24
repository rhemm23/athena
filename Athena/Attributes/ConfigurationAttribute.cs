using System;

namespace Athena.Attributes {

  [AttributeUsage(AttributeTargets.Class)]
  public class ConfigurationAttribute : Attribute {

    public string FileName { get; set; }
  }
}
