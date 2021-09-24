using System;

namespace Athena.Exceptions {

  public class InvalidConfigEntryException : Exception {
  
    public InvalidConfigEntryException(string line) : base(line) { }
  }
}
