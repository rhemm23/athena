using System;

namespace Athena.Exceptions {

  public class MissingConfigurationFileException : Exception {

    public MissingConfigurationFileException(string fileName) : base(fileName) { }
  }
}
