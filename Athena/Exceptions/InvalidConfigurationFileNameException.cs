using System;

namespace Athena.Exceptions {

  class InvalidConfigurationFileNameException : Exception {

    public InvalidConfigurationFileNameException(string name) : base(name) { }
  }
}
