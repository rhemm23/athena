using System;

namespace Athena.Exceptions {

  class InvalidConfigFileNameException : Exception {

    public InvalidConfigFileNameException(string name) : base(name) { }
  }
}
