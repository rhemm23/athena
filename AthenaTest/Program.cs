using Athena.Attributes;
using Athena;
using System;

namespace AthenaTest {

  class Program {

    static void Main() {
      ConfigurationManager.LoadAllConfigs();
      Console.WriteLine(Config.Port);
      Console.ReadKey();
    }
  }

  [Configuration(FileName = "custom_config.ini")]
  public static class Config {

    public static decimal Port { get; set; }

  }
}
