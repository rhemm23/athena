using Athena.Attributes;
using System;

namespace AthenaTest {

  class Program {

    static void Main(string[] args) {
      Athena.ConfigManager.LoadAllConfigs();
      Console.WriteLine(Config.Port);
      Console.ReadKey();
    }
  }

  [Config]
  public static class Config {

    public static decimal Port { get; set; }

  }
}
