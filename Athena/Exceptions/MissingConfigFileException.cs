using System;

namespace Athena.Exceptions {

  public class MissingConfigFileException : Exception {

    public MissingConfigFileException(string fileName) : base(fileName) { }
  }
}
