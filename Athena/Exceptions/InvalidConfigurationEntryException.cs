using System;

namespace Athena.Exceptions {

  public class InvalidConfigurationEntryException : Exception {
  
    public InvalidConfigurationEntryException(string line) : base(line) { }
  }
}
