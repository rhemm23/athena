using Athena.Attributes;
using System;

namespace AthenaTest {

  class Program {

    static void Main(string[] args) {
      Athena.ConfigurationManager.LoadAllConfigs();
      Console.WriteLine(Config.Port);
      Console.ReadKey();
    }
  }

  [Configuration]
  public static class Config {

    public static decimal Port { get; set; }

  }
}
